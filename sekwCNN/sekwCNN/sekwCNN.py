from __future__ import print_function

import numpy as np

import cntk as C
from cntk.layers import Convolution, MaxPooling, Dense
from cntk.initializer import glorot_uniform
from cntk.ops import relu, sigmoid, input_variable
from cntk.learners import learning_rate_schedule, UnitType

import matplotlib as mpl
import matplotlib.pyplot as plt
import numpy as np
import os
from scipy import misc
from os.path import join

import time


def reader(loc, locTest):
    print("load train<<")
    first_in=0
    first_in_test = 0

    #for i in range(99):
    #    tfile_in = loc+str(i)+"in.png"
    #    if (os.path.isfile(tfile_in)):
    #        first_in=i
    #        break
    #for i in range(99):
    #    tfile_in_test = locTest+str(i)+"in.png"
    #    if (os.path.isfile(tfile_in_test)):
    #        first_in_test=i
    #        break

    i = first_in
    data_in = []
    data_out = []

    while (i<50): #50000
        tfile_in = loc+str(i)+"in.png"
        tfile_out = loc+str(i)+"out.png"
        #for ti in range(400): #usunac
        if (os.path.isfile(tfile_in) and os.path.isfile(tfile_out)):
            data_in.append(np.expand_dims(misc.imread(tfile_in).astype(np.float32),axis=0)/255)
            data_out.append(np.expand_dims(misc.imread(tfile_out).astype(np.float32),axis=0)/255)
        i=i+1

    data_in = np.asarray(data_in)
    data_out = np.asarray(data_out)

    data_train = (data_in, data_out)
    print("load test<<")
    i = first_in_test
    data_in_test = []
    data_out_test = []

    while (i<20000):
        tfile_in = locTest+str(i)+"in.png"
        tfile_out = locTest+str(i)+"out.png"
        if (os.path.isfile(tfile_in) and os.path.isfile(tfile_out)):
            data_in_test.append(np.expand_dims(misc.imread(tfile_in).astype(np.float32),axis=0)/255)
            data_out_test.append(np.expand_dims(misc.imread(tfile_out).astype(np.float32),axis=0)/255)
        i=i+1

    data_in_test = np.asarray(data_in_test)
    data_out_test = np.asarray(data_out_test)

    data_test = (data_in_test, data_out_test) 
    print("OK loaded")
    print("treing: ", len(data_train[0])," test: ",len(data_test[0]))

    return(data_train, data_test)


def slice_minibatch(data_x, data_y, i, minibatch_size):
    sx = data_x[i * minibatch_size:(i + 1) * minibatch_size]
    sy = data_y[i * minibatch_size:(i + 1) * minibatch_size]

    return sx, sy

def measure_error(data_x, data_y, x, y, trainer, minibatch_size):
    errors = []
    for i in range(0, int(len(data_x) / minibatch_size)):
        data_sx, data_sy = slice_minibatch(data_x, data_y, i, minibatch_size)

        errors.append(trainer.test_minibatch({x: data_sx, y: data_sy}))

    return np.mean(errors)

def UpSampling(x):
    xr = C.reshape(x, (x.shape[0], x.shape[1], 1, x.shape[2], 1))
    xx = C.splice(xr, xr, axis=-1) 
    xy = C.splice(xx, xx, axis=-3) 
    r = C.reshape(xy, (x.shape[0], x.shape[1] * 2, x.shape[2] * 2))

    return r

def create_model(input, num_classes):
    conv1 = Convolution((3,3), 32, init=glorot_uniform(), activation=relu, pad=True)(input)
    conv1 = Convolution((3,3), 32, init=glorot_uniform(), activation=relu, pad=True)(conv1)
    pool1 = MaxPooling((2,2), strides=(2,2))(conv1)

    conv2 = Convolution((3,3), 64, init=glorot_uniform(), activation=relu, pad=True)(pool1)
    conv2 = Convolution((3,3), 64, init=glorot_uniform(), activation=relu, pad=True)(conv2)
    pool2 = MaxPooling((2,2), strides=(2,2))(conv2)

    conv3 = Convolution((3,3), 128, init=glorot_uniform(), activation=relu, pad=True)(pool2)
    conv3 = Convolution((3,3), 128, init=glorot_uniform(), activation=relu, pad=True)(conv3)
    pool3 = MaxPooling((2,2), strides=(2,2))(conv3)

    conv4 = Convolution((3,3), 256, init=glorot_uniform(), activation=relu, pad=True)(pool3)
    conv4 = Convolution((3,3), 256, init=glorot_uniform(), activation=relu, pad=True)(conv4)
    pool4 = MaxPooling((2,2), strides=(2,2))(conv4)

    conv5 = Convolution((3,3), 512, init=glorot_uniform(), activation=relu, pad=True)(pool4)
    conv5 = Convolution((3,3), 512, init=glorot_uniform(), activation=relu, pad=True)(conv5)

    up6 = C.splice(UpSampling(conv5), conv4, axis=0)
    conv6 = Convolution((3,3), 256, init=glorot_uniform(), activation=relu, pad=True)(up6)
    conv6 = Convolution((3,3), 256, init=glorot_uniform(), activation=relu, pad=True)(conv6)

    up7 = C.splice(UpSampling(conv6), conv3, axis=0)
    conv7 = Convolution((3,3), 128, init=glorot_uniform(), activation=relu, pad=True)(up7)
    conv7 = Convolution((3,3), 128, init=glorot_uniform(), activation=relu, pad=True)(conv7)

    up8 = C.splice(UpSampling(conv7), conv2, axis=0)
    conv8 = Convolution((3,3), 64, init=glorot_uniform(), activation=relu, pad=True)(up8)
    conv8 = Convolution((3,3), 64, init=glorot_uniform(), activation=relu, pad=True)(conv8)

    up9 = C.splice(UpSampling(conv8), conv1, axis=0)
    conv9 = Convolution((3,3), 64, init=glorot_uniform(), activation=relu, pad=True)(up9)
    conv9 = Convolution((3,3), 64, init=glorot_uniform(), activation=relu, pad=True)(conv9)

    conv10 = Convolution((1,1), num_classes, init=glorot_uniform(), activation=sigmoid, pad=True)(conv9)

    return conv10

def loss_function(x, y):
    intersection = C.reduce_sum(x * y, axis=(1,2))
    return C.reduce_mean(2.0 * intersection / (C.reduce_sum(x, axis=(1,2)) + C.reduce_sum(y, axis=(1,2)) + 1.0))

def get_last_chechpoint(loc,fname,max_epoch = 88):
    last = False
    l_int = 0
    for i in range(max_epoch):
        if (os.path.isfile(join(loc,fname+str(i)))):
            last = join(loc,fname+str(i))
            l_int = i
    return last, l_int


def train(training_data, test_data, use_existing=False):

    shape = train_data[0][0].shape
    data_size = train_data[0].shape[0]

    x = C.input_variable(shape)
    y = C.input_variable(shape)

    z = create_model(x, 1)
    dice_coef = loss_function(z, y)

    lr = learning_rate_schedule(0.00001, UnitType.sample)
    momentum = C.learners.momentum_as_time_constant_schedule(0.9)
    trainer = C.Trainer(z, (-dice_coef, -dice_coef), C.learners.adam(z.parameters, lr=lr, momentum=momentum))

    # Get minibatches of training data and perform model training
    minibatch_size = 1
    num_epochs = 20
    last_epoch = 0

    training_errors = []
    test_errors = []

     # Load the saved model if specified
    checkpoint_file = "cntk-unet.dnn"
    loc_checkpoint_file = "model"
    if use_existing:
        last, last_epoch = get_last_chechpoint(loc_checkpoint_file,checkpoint_file) #max 88 epoch
        if not(last):
            print("Err 01 - load model")
        else:
            print("Load file model: ", last )
            trainer.restore_from_checkpoint(last)
        #z.load_model(checkpoint_file)

    if last_epoch<num_epochs-1:
        print("Trening ...")
        in_one_ep = int(len(training_data[0]) / minibatch_size)
        #in_one_ep =400
        for e in range(last_epoch, num_epochs):
            for i in range(0, in_one_ep):
                data_x, data_y = slice_minibatch(training_data[0], training_data[1], i, minibatch_size)

                trainer.train_minibatch({x: data_x, y: data_y})

            training_error = measure_error(training_data[0], training_data[1], x, y, trainer, minibatch_size)
            training_errors.append(training_error)

            test_error = measure_error(test_data[0], test_data[1], x, y, trainer, minibatch_size)
            test_errors.append(test_error)

            print("epoch #{}: training_error={}, test_error={}".format(e, training_errors[-1], test_errors[-1]))

            trainer.save_checkpoint(join(loc_checkpoint_file,checkpoint_file+str(e)))

    return trainer, training_errors, test_errors


if __name__ == '__main__':
    
    train_data, test_data = reader(loc="F:/data_sekw/" ,locTest='F:/data_sekw/')
    trainer, training_errors, test_errors = train(train_data, test_data,use_existing=True)
   
    start = time.time()
    print("OK")

    samples = 20
    print("Ilosc przykladow: ",len(test_data[0]))
    for j in range(1,len(test_data[0]),samples):
        
        pred = trainer.model.eval(test_data[0][j:j+samples])
        end = time.time()
        print("Time "+str(samples)+" for: ")
        print(end - start)

        pred = pred * 255
  
        for i in range(len(pred)):
            misc.imsave("output/imagetest"+str(i+j)+"OUT.png",pred[i][0])
            misc.imsave("output/imagetest"+str(i+j)+"IN.png",test_data[0][i+j][0])
            misc.imsave("output/imagetest"+str(i+j)+"Y.png",test_data[1][i+j][0])

        print("OK")


