using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace URL_Pattern
{
    public partial class Form1 : Form
    {




        public Form1()
        {
            InitializeComponent();
        }


        public void ZmniejszRozmiarSekwencji(ref int[] tabDoObciecia, int[] tabElMożliwychDoUsuwania, int DocelowyRozmiarTablicy)
        {



        }
        public int[][][] ArrayOfAllEvents;
        public class WektorUczacy
        {
            public int[] WejsciaSieci;
            public int[] wyjsciaSieci;
            public int idWzorca;
            public int IleRazyW_Wierszu = 0;

            public WektorUczacy(int[] Wejscia, int[] Wyjscia, int IdWzr, int IleRazyWierszu)
            {

                WejsciaSieci = new int[Wejscia.Length];
                wyjsciaSieci = new int[Wyjscia.Length];

                Array.Copy(Wejscia, WejsciaSieci, Wejscia.Length);
                Array.Copy(Wyjscia, wyjsciaSieci, Wyjscia.Length);
                idWzorca = IdWzr;
                IleRazyW_Wierszu = IleRazyWierszu;
            }

        }

        List<WektorUczacy> WektoryUczace = new List<WektorUczacy>();
        List<Wzorzec> Wzorce = new List<Wzorzec>();                                                                   //    Random rnd = new Random();
        public static Random rnd = new Random();
        class Wzorzec
        {
            public int Dlugosc = 0;
            public int[] Values;
            public int IleRazyMaSiePojawic = 3;//minimum 3 razy

            public Wzorzec(int DlugoscWzorca, int LiczbaDopuszczonychSlow, int MaXCountofOccurenceInRecord)
            {
                Dlugosc = DlugoscWzorca;

                Values = new int[Dlugosc];
                for (int i = 0; i < DlugoscWzorca; i++)
                {
                    Values[i] = rnd.Next(2, LiczbaDopuszczonychSlow);
                }
                IleRazyMaSiePojawic = rnd.Next(3, MaXCountofOccurenceInRecord);

            }

            public override string ToString()
            {
                StringBuilder Result = new StringBuilder(Values[0] + "|");
                for (int i = 1; i < Dlugosc; i++)
                    Result.Append(Values[i] + "|");
                return Result.ToString();
            }

        }
        static  void ConvertTo1zN(int[] src, ref bool[,] dst, int RozmiarSlownika)
        {

            for (int i = 0; i < src.Length; i++)
            {
                dst[i, src[i]] = true;
            }//for (int i = 0; i < src.Length; i++)            
        }
        private void button1_Click(object sender, EventArgs e)
        {
     /*       int LiczbaWzorcow = Convert.ToInt32(tBPatternCount.Text);//liczba wzorców
            int LiczbaWszystkichWpisow = Convert.ToInt32(tBallRequests.Text);
            int MaxDlgWzorca = Convert.ToInt32(tBMaxPatterLen.Text);//ile liczb maksymalnie we wzorcu
            int MinDlgWzorca = Convert.ToInt32(tBMinPatterLen.Text);//ile liczb minimalnie we wzorcu
            int LiczbaDopuszczonychSlow = Convert.ToInt32(tBMaxWordCount.Text);// liczba słów jakie mogą się pojawić (liczba różnych adresów URL
            textBox1.SuspendLayout();
            textBox1.AppendText("wzorce "+System.Environment.NewLine);
            for (int aa = 0; aa < LiczbaWzorcow; aa++)
            {


                if (cBPatternFixedLen.Checked)
                    for (int a = 0; a < LiczbaWzorcow; a++)
                    {

                        Wzorce.Add(new Wzorzec(MaxDlgWzorca, LiczbaDopuszczonychSlow));

                    }
                else
                    for (int a = 0; a < LiczbaWzorcow; a++)
                    {

                        Wzorce.Add(new Wzorzec(rnd.Next(MinDlgWzorca, MaxDlgWzorca), LiczbaDopuszczonychSlow));

                    }
                textBox1.AppendText(Wzorce[aa].ToString() + System.Environment.NewLine);
            }// for (int aa = 0; aa < LiczbaWzorcow; aa++)

            //wpsiujemy wszystkie elementy wzorców do jednej tablicy

            int[] TabWartosciWzorcow = new int[0];

            foreach (Wzorzec Wzr in Wzorce)

            {
                Array.Resize(ref TabWartosciWzorcow, TabWartosciWzorcow.Length + Wzr.Dlugosc);
                int a = 0;
                for (int t = TabWartosciWzorcow.Length - Wzr.Dlugosc; t < TabWartosciWzorcow.Length; t++)
                {
                    TabWartosciWzorcow[t] = Wzr.Values[a];
                    a++;
                }

            }

            //i usuwamy duplikaty
            int[] q = TabWartosciWzorcow.Distinct().ToArray();

            ArrayOfAllEvents = new int[Wzorce.Count][];
            for (int kk=0;kk< Wzorce.Count;kk++)
               ArrayOfAllEvents[kk] = new int[TabWartosciWzorcow.Length];


            Random RndBool = new Random();
            //for (int ii = 0; ii < LiczbaWszystkichWpisow;ii++)
            //{
            int ii = 0;
            int jj = 0;
            foreach (Wzorzec Wzr in Wzorce)

            {
              
                for (int IleRazyWzorzec = 0; IleRazyWzorzec < Wzr.IleRazyMaSiePojawic; IleRazyWzorzec++)
                {
                    // int NumWartWeWzorca = 0;
                  
                    for (int NumWartWeWzorca = 0; NumWartWeWzorca < Wzr.Dlugosc; NumWartWeWzorca++)
                    {

                        for (int randomilosc=0;randomilosc<rnd.Next(30); randomilosc++)
                        { 
                        Array.Resize(ref ArrayOfAllEvents[jj], ii + 1);                      
                      
                        int wart = rnd.Next(LiczbaDopuszczonychSlow);
                        while ((q.Contains(wart)))
                            {

                                wart = rnd.Next(LiczbaDopuszczonychSlow);
                            }
                            ArrayOfAllEvents[jj][ii] = wart;
                            ii++;
                        }//  for (int randomilosc=0;randomilosc<rnd.Next(30); randomilosc++)                        
                        Array.Resize(ref ArrayOfAllEvents[jj], ii + 1);
                        ArrayOfAllEvents[jj][ii] = Wzr.Values[NumWartWeWzorca];                      
                        ii++;

                    }// for (int NumWartWeWzorca = 0; NumWartWeWzorca < Wzr.Dlugosc; NumWartWeWzorca++)
                }// for (int IleRazyWzorzec=0; IleRazyWzorzec<Wzr.IleRazyMaSiePojawic; IleRazyWzorzec++)
                ii = 0;
                jj++;
            }
           
            textBox1.AppendText("zaszumione wpisy " + System.Environment.NewLine);
            for (jj=0;jj<Wzorce.Count;jj++)
              for (int i=0;i< ArrayOfAllEvents[jj].Length; i++)
                textBox1.AppendText(ArrayOfAllEvents[jj][i].ToString()+System.Environment.NewLine);
            textBox1.ResumeLayout();*/

        }


        private void button2_Click(object sender, EventArgs e)
        {
          
            string myTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string Path = @"c:\WykrywanieSchematow\plik" + myTime + @".txt";

           
            if (!Directory.Exists(@"c:\WykrywanieSchematow"))
                Directory.CreateDirectory(@"c:\WykrywanieSchematow");


            
            File.WriteAllText(Path, richTextBox1.Text);
            MessageBox.Show("Zapisano w plik "+Path);


           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int LiczbaWektorowUczacych = WektoryUczace.Count;
            int LiczbaWartosciWWierszu = Convert.ToInt32(tBSigleRowLength.Text);
            int RozmiarAlfabetu = Convert.ToInt32(tBMaxWordCount.Text);

            bool[,] BlResult = new bool[LiczbaWartosciWWierszu, RozmiarAlfabetu];//liczba wartosci wejsciowych   na rozmiar alfabetu
            int RozmiarSlownika = RozmiarAlfabetu;
            int RozmiarSesji = LiczbaWartosciWWierszu;
            string myTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string path = @"c:\WykrywanieSchematow\OUT_1_z_N_" + myTime + @".txt";
            if (!Directory.Exists(@"c:\WykrywanieSchematow"))
                    Directory.CreateDirectory(@"c:\WykrywanieSchematow");

            foreach (WektorUczacy wkt in WektoryUczace)

            {

                ConvertTo1zN(wkt.WejsciaSieci, ref BlResult, RozmiarSlownika);
                StringBuilder Klasa = new StringBuilder(" | features");
                foreach (int val in wkt.wyjsciaSieci)
                    Klasa.Append(" " + val);
                for (int i = 0; i < RozmiarSlownika; i++)
                {
                    StringBuilder OutLine = new StringBuilder(RozmiarSesji);
                    OutLine.Append("labels |");
                    for (int j = 0; j < RozmiarSesji; j++)
                    {
                        OutLine.Append(Convert.ToInt32(BlResult[j, i])+ " ");

                    }
                    OutLine.Append(Klasa);
                   
                    File.AppendAllText(path, OutLine.ToString());
                }//for (int i = 0; i < liczbaKanalow; i++)
            }
            MessageBox.Show("Zapisano w pliku " + path);


            /*   for (int ww = 0; ww < Wzorce.Count; ww++)

               {

                   ConvertTo1zN(ArrayOfAllEvents[ww],ref BlResult, RozmiarSlownika);
                   StringBuilder Klasa = new StringBuilder("|features");
                   foreach (int val in Wzorce[ww].Values)
                       Klasa.Append(" " + val);
                   for (int i = 0; i < RozmiarSlownika; i++)
                   {
                       StringBuilder OutLine = new StringBuilder(RozmiarSesji);
                       OutLine.Append("labels |");
                       for (int j = 0; j < RozmiarSesji; j++)
                       {
                           OutLine.Append(Convert.ToInt32(BlResult[j, i] + " "));

                       }
                       OutLine.Append(Klasa);
                       string myTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
                       string path=@"c:\WykrywanieSchematow\OUT_1_z_N_" + myTime + @".txt";
                       File.AppendAllText(path, OutLine.ToString());
                   }//for (int i = 0; i < liczbaKanalow; i++)
               }*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int LiczbaRekordow = Convert.ToInt32(tBAllRecordsCount.Text);//liczba rekordow
            int MaxRecordLength = Convert.ToInt32(tBSigleRowLength.Text);//RozmiarPojWiersza
            int LiczbaWzorcow = Convert.ToInt32(tBPatternCount.Text);//liczba wzorców
            int LiczbaWszystkichWpisow = Convert.ToInt32(tBAllRecordsCount.Text);
            int MaxDlgWzorca = Convert.ToInt32(tBMaxPatterLen.Text);//ile liczb maksymalnie we wzorcu
            int MinDlgWzorca = Convert.ToInt32(tBMinPatterLen.Text);//ile liczb minimalnie we wzorcu
            int LiczbaDopuszczonychSlow = Convert.ToInt32(tBMaxWordCount.Text);// liczba słów jakie mogą się pojawić (liczba różnych adresów URL
            richTextBox1.SuspendLayout();
            richTextBox1.AppendText("wzorce " + System.Environment.NewLine);
            for (int aa = 0; aa < LiczbaWzorcow; aa++)
            {


                if (cBPatternFixedLen.Checked)
                  //  for (int a = 0; a < LiczbaWzorcow; a++)
                    {

                        Wzorce.Add(new Wzorzec(MaxDlgWzorca, LiczbaDopuszczonychSlow,8));

                    }
                else
                   // for (int a = 0; a < LiczbaWzorcow; a++)
                    {

                        Wzorce.Add(new Wzorzec(rnd.Next(MinDlgWzorca, MaxDlgWzorca), LiczbaDopuszczonychSlow,8));

                    }
                richTextBox1.AppendText(Wzorce[aa].ToString() + System.Environment.NewLine);
            }// for (int aa = 0; aa < LiczbaWzorcow; aa++)

            //wpsiujemy wszystkie elementy wzorców do jednej tablicy

            int[] TabWartosciWzorcow = new int[0];

            foreach (Wzorzec Wzr in Wzorce)

            {
                Array.Resize(ref TabWartosciWzorcow, TabWartosciWzorcow.Length + Wzr.Dlugosc);
                int a = 0;
                for (int t = TabWartosciWzorcow.Length - Wzr.Dlugosc; t < TabWartosciWzorcow.Length; t++)
                {
                    TabWartosciWzorcow[t] = Wzr.Values[a];
                    a++;
                }

            }

            //i usuwamy duplikaty

          
            int[] q = TabWartosciWzorcow.Distinct().ToArray();

            ArrayOfAllEvents = new int[LiczbaRekordow][][];
            for (int tmp = 0; tmp < LiczbaRekordow; tmp++)
            {
                ArrayOfAllEvents[tmp] = new int[TabWartosciWzorcow.Length][];
                for (int kk = 0; kk < Wzorce.Count; kk++)
                    ArrayOfAllEvents[tmp][kk] = new int[MaxRecordLength];

            }

           
           


            Random RndBool = new Random();
            //for (int ii = 0; ii < LiczbaWszystkichWpisow;ii++)
            //{
            int ii = 0;
            int jj = 0;
            int numRekordu = 0;
          
           // Array.Resize(ref ArrayOfAllEvents[numRekordu][2][numWektora], numWektora + 1);
            for (numRekordu = 0; numRekordu < LiczbaRekordow; numRekordu++)
            {

             int   rndNumWzorca = rnd.Next(0,Wzorce.Count-1);
             Wzorzec Wzr = Wzorce[rndNumWzorca];

                do
                {
                    ii = 0;
                    for (int IleRazyWzorzec = 0; IleRazyWzorzec < Wzr.IleRazyMaSiePojawic; IleRazyWzorzec++)
                    {

                        for (int NumWartWeWzorca = 0; NumWartWeWzorca < Wzr.Dlugosc; NumWartWeWzorca++)
                        {

                            int rndil = rnd.Next(5);
                            for (int randomilosc = 0; randomilosc < rndil; randomilosc++)
                            {

                                int wart = rnd.Next(LiczbaDopuszczonychSlow);
                                while ((q.Contains(wart)))
                                {

                                    wart = rnd.Next(LiczbaDopuszczonychSlow);
                                }
                                if (ii < MaxRecordLength)
                                {
                                    ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = wart;
                                    ii++;
                                }
                                else
                                    break;
                               
                            }//  for (int randomilosc=0;randomilosc<rnd.Next(30); randomilosc++)                        
                            if (ii < MaxRecordLength)
                            {
                                ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = Wzr.Values[NumWartWeWzorca];
                                ii++;
                            }
                            else
                                break;
                           

                        }// for (int NumWartWeWzorca = 0; NumWartWeWzorca < Wzr.Dlugosc; NumWartWeWzorca++)


                    }//for (int IleRazyWzorzec = 0; IleRazyWzorzec < Wzr.IleRazyMaSiePojawic; IleRazyWzorzec++)
                }
                while (ii > MaxRecordLength);

                for (;ii<MaxRecordLength;ii++)//uzupelnuiamy do konca
                {
                    int wart = rnd.Next(LiczbaDopuszczonychSlow);
                    while ((q.Contains(wart)))
                    {

                        wart = rnd.Next(LiczbaDopuszczonychSlow);
                    }
                    ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = wart;

                }

            }// for (numRekordu = 0; numRekordu < LiczbaRekordow; numRekordu++)
            

            richTextBox1.AppendText("zaszumione wpisy " + System.Environment.NewLine);
            for (int dd = 0; dd < LiczbaRekordow; dd++)
            {
                for (jj = 0; jj < Wzorce.Count; jj++)
                {
                    if ((ArrayOfAllEvents[dd][jj][0])!=0 && (ArrayOfAllEvents[dd][jj][1] != 0) && (ArrayOfAllEvents[dd][jj][2] != 0))
                    {
                        richTextBox1.AppendText("wzorzec " + jj.ToString() + System.Environment.NewLine);
                        for (int i = 0; i < ArrayOfAllEvents[dd][jj].Length; i++)
                            richTextBox1.AppendText(ArrayOfAllEvents[dd][jj][i].ToString() + "|");
                        richTextBox1.AppendText(System.Environment.NewLine);
                    }
                    

                }
               
           
           }// for (int dd = 0; dd < LiczbaRekordow; dd++)
            richTextBox1.ResumeLayout();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            int LiczbaRekordow = Convert.ToInt32(tBAllRecordsCount.Text);//liczba rekordow
            int MaxRecordLength = Convert.ToInt32(tBSigleRowLength.Text);//RozmiarPojWiersza
            int LiczbaWzorcow = Convert.ToInt32(tBPatternCount.Text);//liczba wzorców
            int LiczbaWszystkichWpisow = Convert.ToInt32(tBAllRecordsCount.Text);
            int MaxDlgWzorca = Convert.ToInt32(tBMaxPatterLen.Text);//ile liczb maksymalnie we wzorcu
            int MinDlgWzorca = Convert.ToInt32(tBMinPatterLen.Text);//ile liczb minimalnie we wzorcu
            int LiczbaDopuszczonychSlow = Convert.ToInt32(tBMaxWordCount.Text);// liczba słów jakie mogą się pojawić (liczba różnych adresów URL
            int MaxRepeatofPatternInRecord = Convert.ToInt32(tBMAXLiczbaPowtorzenWzorcawRekordzie.Text);
            int MaxOdstepMiedzySekwencjami = Convert.ToInt32(tBMakOdstepMiedzySekwencjami.Text);// Maksymalny odstęp miedzy sekwencjami
            richTextBox1.SuspendLayout();
            richTextBox1.AppendText("wzorce " + System.Environment.NewLine);

            if (MaxDlgWzorca * MaxRepeatofPatternInRecord * 5 > MaxRecordLength)
            {

                MessageBox.Show("Błędne dane wejściowe- ilocznyn (max dłg wzorca * liczba pojawień się wzorca) przy uwzględnieniu plosowych przesunięć jest większa od długości rekordu ");

            }

            for (int aa = 0; aa < LiczbaWzorcow; aa++)
            {


                if (cBPatternFixedLen.Checked)
                //  for (int a = 0; a < LiczbaWzorcow; a++)
                {

                    Wzorce.Add(new Wzorzec(MaxDlgWzorca, LiczbaDopuszczonychSlow, MaxRepeatofPatternInRecord));

                }
                else
                // for (int a = 0; a < LiczbaWzorcow; a++)
                {
                    Wzorce.Add(new Wzorzec(rnd.Next(MinDlgWzorca, MaxDlgWzorca), LiczbaDopuszczonychSlow, MaxRepeatofPatternInRecord));
                    //GetWzorce().Add(new Wzorzec(rnd.Next(MinDlgWzorca, MaxDlgWzorca), LiczbaDopuszczonychSlow, MaxRepeatofPatternInRecord));

                }
                richTextBox1.AppendText(Wzorce[aa].ToString() + System.Environment.NewLine);
            }// for (int aa = 0; aa < LiczbaWzorcow; aa++)

            //wpsiujemy wszystkie elementy wzorców do jednej tablicy

            int[] TabWartosciWzorcow = new int[0];
            MessageBox.Show("utworzono Wzorce");
            Application.DoEvents();
            foreach (Wzorzec Wzr in Wzorce)

            {
                Array.Resize(ref TabWartosciWzorcow, TabWartosciWzorcow.Length + Wzr.Dlugosc);
                int a = 0;
                for (int t = TabWartosciWzorcow.Length - Wzr.Dlugosc; t < TabWartosciWzorcow.Length; t++)
                {
                    TabWartosciWzorcow[t] = Wzr.Values[a];
                    a++;
                }

            }

            //usuwamy duplikaty


            int[] q1 = TabWartosciWzorcow.Distinct().ToArray();
            //tablica liczb w której nie ma wartości wzorców
          int[] ValuesWithoutPatterns1 = new int[0];
            for (int i = 0; i < LiczbaDopuszczonychSlow; i++)
            {
                if (!(q1.Contains(i)))
                {
                    Array.Resize(ref ValuesWithoutPatterns1, ValuesWithoutPatterns1.Length + 1);
                    ValuesWithoutPatterns1[ValuesWithoutPatterns1.Length - 1] = i;
                }
                  

            }

            StringBuilder stb = new StringBuilder();
            foreach (int s in ValuesWithoutPatterns1)
            {
                stb.Append(s + ", ");
            }
            MessageBox.Show("liczba stron, które nie występują we wzorcach " + ValuesWithoutPatterns1.Length+" te wartości to "+ stb.ToString());

            Random RndBool = new Random();
          
            int ii = 0;
            int jj = 0;
            int numRekordu = 0;
            int MaxWektLen = 0;
            int[] WejsciaTMP = new int[MaxRecordLength];
            int NumerGenerowanegoWektora = 0;
            // Array.Resize(ref ArrayOfAllEvents[numRekordu][2][numWektora], numWektora + 1);
            for (numRekordu = 0; numRekordu < LiczbaRekordow; numRekordu++)
            {

                int rndNumWzorca = rnd.Next(0, Wzorce.Count - 1);
                Wzorzec Wzr = Wzorce[rndNumWzorca];

                int[] q = Wzr.Values.Distinct().ToArray();
                //tablica liczb w której nie ma wartości wzorców
                int[] ValuesWithoutPatterns = new int[0];
                for (int i = 0; i < LiczbaDopuszczonychSlow; i++)
                {
                    if (!(q.Contains(i)))
                    {
                        Array.Resize(ref ValuesWithoutPatterns, ValuesWithoutPatterns.Length + 1);
                        ValuesWithoutPatterns[ValuesWithoutPatterns.Length - 1] = i;
                    }

                }//for (int i = 0; i < LiczbaDopuszczonychSlow; i++)

                NumerGenerowanegoWektora = 0;
                ii = 0;
                do
                {
                  if(  ii > MaxRecordLength)
                      ii = 0;
                    NumerGenerowanegoWektora++;
                    for (int IleRazyWzorzec = 0; IleRazyWzorzec < Wzr.IleRazyMaSiePojawic; IleRazyWzorzec++)
                    {
                        int rndil2 = rnd.Next(MaxOdstepMiedzySekwencjami); // TO dodałem odstep miedzy sekwencjami
                        for (int randomilosc = 0; randomilosc < rndil2; randomilosc++)
                        {
                            int wart = ValuesWithoutPatterns[rnd.Next(ValuesWithoutPatterns.Length - 1)];
                            if (ii < MaxRecordLength)
                            {
                                WejsciaTMP[ii] = wart;
                                //   ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = wart;
                                ii++;
                            }
                            else
                                break;

                        }
                        //Koniec Co dodałem 


                        if (ii<MaxRecordLength)
                        for (int NumWartWeWzorca = 0; NumWartWeWzorca < Wzr.Dlugosc; NumWartWeWzorca++)
                        {
                            int rndil = rnd.Next(3);
                            for (int randomilosc = 0; randomilosc < rndil; randomilosc++)
                            {
                                int wart = ValuesWithoutPatterns[rnd.Next(ValuesWithoutPatterns.Length-1)];
                                if (ii < MaxRecordLength)
                                {
                                    WejsciaTMP[ii] = wart;
                                 //   ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = wart;
                                    ii++;
                                }
                                else
                                    break;

                            }//  for (int randomilosc=0;randomilosc<rnd.Next(30); randomilosc++)                        
                            if (ii < MaxRecordLength)
                            {
                                WejsciaTMP[ii] = Wzr.Values[NumWartWeWzorca];
                                //        ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = Wzr.Values[NumWartWeWzorca];
                                ii++;
                            }
                          
                        }// for (int NumWartWeWzorca = 0; NumWartWeWzorca < Wzr.Dlugosc; NumWartWeWzorca++)


                    }//for (int IleRazyWzorzec = 0; IleRazyWzorzec < Wzr.IleRazyMaSiePojawic; IleRazyWzorzec++)
                  //  Application.DoEvents();
                    if (ii > MaxWektLen)
                        MaxWektLen =2* ii;
                //    label9.Text = "Numer wzorca " + numRekordu.ToString() + " numer wektora błędnego " + NumerGenerowanegoWektora.ToString()+" max długość wektora "+ MaxWektLen.ToString();

                }//do
                while (ii < MaxRecordLength);

                for (; ii < MaxRecordLength; ii++)//uzupelnuiamy do konca
                {

                    int wart = ValuesWithoutPatterns[rnd.Next(ValuesWithoutPatterns.Length - 1)];
                    
                  
             //       ArrayOfAllEvents[numRekordu][rndNumWzorca][ii] = wart;
                    WejsciaTMP[ii] = wart;
                    //Application.DoEvents();
                }
             //   Application.DoEvents();
                WektoryUczace.Add(new WektorUczacy(WejsciaTMP, Wzorce[rndNumWzorca].Values, rndNumWzorca, Wzorce[rndNumWzorca].IleRazyMaSiePojawic ));
               // label7.Text = "Numer wektora: "+WektoryUczace.Count;
            }// for (numRekordu = 0; numRekordu < LiczbaRekordow; numRekordu++)
            MessageBox.Show("export to richtextbox");
            richTextBox1.AppendText("zaszumione wpisy " + System.Environment.NewLine);
            StringBuilder stbWyjscia = new StringBuilder();
            StringBuilder stbWejscia = new StringBuilder();

            string myTime = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
            string Path = @"c:\WykrywanieSchematow\plik" + myTime + @".txt";
            string PathOnlyInputs = @"c:\WykrywanieSchematow\Inputs" + myTime + @".txt";

            if (!Directory.Exists(@"c:\WykrywanieSchematow"))
                Directory.CreateDirectory(@"c:\WykrywanieSchematow");

            StreamWriter OutFileOnlyInputs = new StreamWriter(PathOnlyInputs, true);


            foreach (WektorUczacy wkt in WektoryUczace)
            {
                stbWyjscia.Clear();
                stbWejscia.Clear();


                for (int a = 0; a < wkt.WejsciaSieci.Length;a++)
                {

                    stbWejscia.Append(wkt.WejsciaSieci[a]+"|");

                }
                for (int a = 0; a < wkt.wyjsciaSieci.Length;a++)
                {

                    stbWyjscia.Append(wkt.wyjsciaSieci[a] + "|");

                }
                //  label12.Text = "Export do pliku wektora numer " + num;

                //    File.AppendAllText()
                //    File.AppendAllText(Path, "indeks wzorca " + wkt.idWzorca.ToString() + " wejscia " + stbWejscia.ToString() + " wyjscia " + stbWyjscia + System.Environment.NewLine);


                OutFileOnlyInputs.WriteLine(stbWejscia.ToString());




                richTextBox1.AppendText("indeks wzorca " + wkt.idWzorca.ToString() + " wejscia " + stbWejscia.ToString() + " wyjscia " + stbWyjscia+System.Environment.NewLine);
            }// foreach (WektorUczacy wkt in WektoryUczace)
            richTextBox1.ResumeLayout();
            OutFileOnlyInputs.Close();

            if (!Directory.Exists(@"c:\WykrywanieSchematow"))
                Directory.CreateDirectory(@"c:\WykrywanieSchematow");
            File.WriteAllText(Path, richTextBox1.Text);
           
            MessageBox.Show("Zapisano w pliku zawartość RichTextBox " + Path);





        }

        private List<Wzorzec> GetWzorce()
        {
            return Wzorce;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
