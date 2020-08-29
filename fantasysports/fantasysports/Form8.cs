using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fantasysports
{
    public partial class Form8 : Form

    {
        //permutationen bestimmen
        // Die Methode, die man von außen nur mit den nötigen Parametern aufruft.
        public static List<T[]> Combination<T>(T[] atInput, int iToChoose)
        {
            List<T[]> listatResult = new List<T[]>();
            Combination(atInput, iToChoose, 0, 0, new T[iToChoose], listatResult);
            return listatResult;
        }
        // Die Methode, die intern verwendet wird und die eigentliche rekursive Arbeit macht
        private static void Combination<T>(T[] atInput,
                                             int iToChoose,
                                             int iNumChoosen,
                                             int iChooseBegin,
                                             T[] atCurrSelection,
                                             List<T[]> listatResult)
        {
            if (iToChoose <= 0)
            {
                T[] atCurrResult = new T[atCurrSelection.Length];
                atCurrSelection.CopyTo(atCurrResult, 0);
                listatResult.Add(atCurrResult);
                return;
            }

            for (int i = iChooseBegin; i <= atInput.Length - iToChoose; ++i)
            {
                atCurrSelection[iNumChoosen] = atInput[i];
                Combination<T>(atInput, iToChoose - 1, iNumChoosen + 1, i + 1,
                                 atCurrSelection, listatResult);

            }
        }

        // Beispielaufruf:
        //static void Aufruf(int [] id_array, int Anz)
        List<int> Aufruf(int[] id_array, int Anz)
        {
            //int[] aiInput = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            List<int> rück = new List<int>();
            foreach (int[] aiResult in Combination<int>(id_array, Anz))
            {
                foreach (int i in aiResult)
                {
                    rück.Add(i);
                    // Console.Write("{0}, ", i);
                }
                //Console.WriteLine();
            }
            return rück;
        }









        //Funktionen Projectionberechnung
        //
        // 90min Mittelfeld,Sturm
        double Spiel90min_SM(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            if (input > 90)
                input = 90;
            input = 1 * (input / 90);
            return input;
        }

        //StürmerGoal
        double SGoalS(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 4;
            return input;
        }

        //Mitelfeld goal
        double MGoalS(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 5;
            return input;
        }

        //Verteidigung goal
        double VGoalS(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 6;
            return input;
        }

        // Torwart goal
        double GoalS(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 8;
            return input;
        }

        //Assists
        double Assists(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 3;
            return input;
        }

        //Mittelfeld Cleansheet
        double MCleansheet(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 1;
            return input;
        }

        //Verteidigung /Torwart Cleansheet
        double VTCleansheet(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * 4;
            return input;
        }

        //Torwart, Verteidigung, 2 gegentore Goals gegnerisches Team ist input
        double VT2Goals(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = (input / 2) * -1;
            return input;
        }

        //Torwart Parade. SOG gegnerisches Team - G gegnerisches Team dann mal 0.5
        double Parade(string inpu1)
        {
            double input1;
            double.TryParse(inpu1, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input1);
            input1 = input1 * 0.5;

            return input1;
        }

        //Spielzeit >60
        double Spielzeit_gr60(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            if (input > 60)
                input = 1;
            return input;
        }

        //Spielzeit <60
        double Spielzeit_kl60(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            if (input > 0)
                input = 1;
            return input;
        }

        //Gelbe Karte
        double gelb(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * (-1);
            return input;
        }

        //Rote Karte
        double rot(string inpu)
        {
            double input;
            double.TryParse(inpu, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input);
            input = input * (-3);
            return input;
        }

        //win90  
        double win90(string inpu1, string inpu2)
        {
            double input1;
            double.TryParse(inpu1, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input1);
            double input2;
            double.TryParse(inpu2, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input2);
            if (input1 > input2)
                input1 = 1;
            else
                input1 = 0;
            return input1;
        }

        //loose90  
        double loose90(string inpu1, string inpu2)
        {
            double input1;
            double.TryParse(inpu1, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input1);
            double input2;
            double.TryParse(inpu2, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out input2);
            if (input1 > input2)
                input1 = 0;
            else
                input1 = -1;
            return input1;
        }

        //array aus Liste generieren input (Liste, Anzahl Spalten;)
        string[,] list2array(List<string> liste, int spalten)
        {
            string[,] array = new string[liste.Count() / spalten, spalten];
            int k = 0;
            for (int i = 0; i < liste.Count() / spalten; i++)
            {
                for (int j = 0; j < spalten; j++)
                {
                    array[i, j] = liste[k];
                    k++;
                }
            }
            return array;
        }

        //db auslesen Rotowire, Referenz
        List<string> db2list(string tablename)
        {
            MySqlConnection connection = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            List<string> dblist = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + tablename;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row = Reader.GetValue(i).ToString();
                    dblist.Add(row);
                }
            }
            connection.Close();
            return dblist;
        }




        //db auslesen Fanteam
        List<string> db2list2(string id)
        {
            MySqlConnection connection = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            List<string> dblist2 = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader Reader;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM FanteamPreise WHERE TurnierID = " + id;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row = Reader.GetValue(i).ToString();
                    dblist2.Add(row);
                }
            }
            connection.Close();
            return dblist2;
        }

        //List2string1d
        int[] list2array1d(List<string> liste)
        {
            int[] a = new int[liste.Count()];

            for (int i = 0; i < liste.Count(); i++)
            {
                a[i] = Int32.Parse(liste[i]);
            }
            return a;
        }

        // double to string array
        string[,] double2string(List<int> Zeilen, int spalten)
        {
            int k = 0;
            string[,] a = new string[Zeilen.Count() / spalten, spalten];
            for (int i = 0; i < Zeilen.Count() / spalten; i++)
            {
                for (int j = 0; j < spalten; j++)
                {
                    a[i, j] = Zeilen[k].ToString();
                    k = k + 1;
                }
            }
            return a;
        }

        //Gesamtpreis zu DEF, MID, FOR, GK        
        string[,] Gesamtpreis(string[,] input, string[,] arrayf, int anz)
        {
            double kk = 0.0;
            double bb;
            for (int i = 0; i < input.Length / (anz + 2); i++)
            {
                for (int j = 0; j < anz; j++)
                {
                    for (int l = 0; l < arrayf.Length / 7; l++)
                    {
                        if (input[i, j] == arrayf[l, 0])
                        {
                            double b;
                            double.TryParse(arrayf[l, 4], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out b);
                            kk = kk + b;
                            break;
                        }
                    }
                }
                bb = kk;
                kk = 0.0;
                input[i, anz] = bb.ToString();
            }
            return input;
        }

        //Gesamtproj zu DEF, MID, FOR, GK
        string[,] Gesamtproj(string[,] input, string[,] arrayf, int anz)
        {
            double kk = 0.0;
            double bb;
            for (int i = 0; i < input.Length / (anz + 2); i++)
            {
                for (int j = 0; j < anz; j++)
                {
                    for (int l = 0; l < arrayf.Length / 7; l++)
                    {
                        if (input[i, j] == arrayf[l, 0])
                        {
                            double b;
                            arrayf[l, 6] = arrayf[l, 6].ToString().Replace(',', '.');
                            double.TryParse(arrayf[l, 6], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out b);
                            kk = kk + b;
                            break;
                        }
                    }
                }
                bb = kk;
                kk = 0.0;
                input[i, anz + 1] = bb.ToString();
            }
            return input;
        }

        //string zu double array
        double[,] string2double(string[,] input, int spalten)
        {
            double[,] output = new double[input.Length / spalten, spalten];
            for (int i = 0; i < input.Length / spalten; i++)
            {
                for (int j = 0; j < spalten; j++)
                {
                    double b;
                    input[i, j] = input[i, j].ToString().Replace(',', '.');
                    double.TryParse(input[i, j], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out b);
                    output[i, j] = b;
                }
            }
            return output;
        }

        //datum Python zu datum c# wandeln
        string datumPytoC(string input)
        {
            
            string[] temp = input.Split(new Char[] { '-' });
            string output = temp[2] + "." + temp[1] + "." + temp[0];
            return output;

        }





        public Form8()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (TurnierID_input.Text == "")
            {
                label3.Text = "TurnierID eingeben";
                return;
            }


            if (Wettbewerb_combobox.Text == "")
            {
                label3.Text = "Turnierform eingeben";
                return;
            }







            //db auslesen und in Liste
            List<String> Rotowire22 = db2list("Rotowire");
            List<String> Fanteam = db2list2(TurnierID_input.Text);
            List<String> Referenz = db2list("Referenz");

            //Abbruch bedingung prüfen
            if (Rotowire22.Count() < 1)
            {
                label3.Text = "Rotowire uploaden!!!";
                return;
            }
            if (Fanteam.Count() < 1)
            {
                label3.Text = "Fanteam uploaden!!!!";
                return;
            }
            if (Referenz.Count() < 1)
            {
                label3.Text = "Referenzliste pflegen!!!";
                return;
            }


            //liste2array
            string[,] Rotowire_array22 = list2array(Rotowire22, 33);
            string[,] Fanteam_array = list2array(Fanteam, 12);
            string[,] Referenz_array = list2array(Referenz, 7);

            if(Rotowire_array22.Length<1)
            {
                label3.Text = "Rotowire uploaden";
                return;
            }

            string datum = System.DateTime.Now.ToShortDateString();
            int b = 0;
            for( int i=0; i<Rotowire_array22.Length/33; i++)
            {
                if (Rotowire_array22[i, 32] == datum)
                    b = 1;
            }
            if (b==0)
            {
                label3.Text = "Aktuelle Rotowire Projections uploaden!!!!!";
                    return;
            }

            List<String> Rotowire2 = new List<string>();
            for (int i = 0; i < Rotowire_array22.Length / 33; i++)
            {
                if (Rotowire_array22[i, 32] == datum)
                {
                    for (int j = 0; j < 33; j++)
                    {
                        Rotowire2.Add(Rotowire_array22[i, j]);
                    }
                }

            }
            string[,] Rotowire_array = list2array(Rotowire2, 33);

            //Fanteam filtern...
            List<String> FT2 = new List<string>();
            for (int i = 0; i < Fanteam_array.Length / 12; i++)
            {
                if (Fanteam_array[i, 11] == TurnierID_input.Text)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        FT2.Add(Fanteam_array[i, j]);
                    }
                }

            }
            Fanteam_array = list2array(FT2, 12);




            //Arrays Filtern und id hinzufügen
            List<String> Rotowire_filter = new List<string>();
            List<String> Fanteam_filter = new List<string>();

            for (int i = 0; i < Rotowire_array.Length / 33; i++)
            {
                for (int j = 0; j < Referenz.Count() / 7; j++)
                {   //wenn NameRef==NameRot && TeamRot==TeamRef, dann hinzufügen
                    if (Rotowire_array[i, 1] == Referenz_array[j, 2] && Rotowire_array[i, 2] == Referenz_array[j, 3])
                    {
                        Rotowire_filter.Add(Rotowire_array[i, 1]);  //Name
                        Rotowire_filter.Add(Rotowire_array[i, 2]);  //Team
                        Rotowire_filter.Add(Rotowire_array[i, 4]);  //Pos
                        Rotowire_filter.Add(Referenz_array[j, 0]);   //id
                        break;
                    }
                }
            }
            for (int i = 0; i < Fanteam.Count() / 12; i++)
            {
                for (int j = 0; j < Referenz.Count() / 7; j++)
                {
                    if ((Fanteam_array[i, 2] == Referenz_array[j, 1] && Fanteam_array[i, 4] == Referenz_array[j, 4]) || (Fanteam_array[i, 2] == Referenz_array[j, 1] && Fanteam_array[i, 5] == Referenz_array[j, 4]))
                    {
                        Fanteam_filter.Add(Referenz_array[j, 1]);   //Name
                        Fanteam_filter.Add(Referenz_array[j, 4]);   //Team
                        Fanteam_filter.Add(Fanteam_array[i, 3]);    //Pos
                        Fanteam_filter.Add(Referenz_array[j, 0]);   //id
                        Fanteam_filter.Add(Fanteam_array[i, 8]);    //Preis
                        break;
                    }
                }
            }
            string[,] Rotowire_arrayF = list2array(Rotowire_filter, 4);
            string[,] Fanteam_arrayF = list2array(Fanteam_filter, 5);


            //Pos bei Rotowirefilter tauschen
            for (int i = 0; i < Rotowire_filter.Count() / 4; i++)
            {
                for (int j = 0; j < Fanteam_filter.Count() / 5; j++)
                {
                    if (Rotowire_arrayF[i, 3] == Fanteam_arrayF[j, 3])
                    {
                        Rotowire_arrayF[i, 2] = Fanteam_arrayF[j, 2];
                        break;
                    }
                }
            }



            //Proj berechnen
            double Proj = 0.0;
            List<double> Erg = new List<double>();
            string[,] array_projections = new string[Rotowire_arrayF.Length / 4, 7];
            for (int i = 0; i < Rotowire_filter.Count() / 4; i++)
            {
                for (int j = 0; j < Rotowire_array.Length / 33; j++)
                {
                    //Position prüfen
                    if (Rotowire_arrayF[i, 0] == Rotowire_array[j, 1] && Rotowire_arrayF[i, 1] == Rotowire_array[j, 2])
                    {
                        //Torwart berechnen
                        if (Rotowire_arrayF[i, 2] == "GK")
                        {
                            Proj = GoalS(Rotowire_array[j, 6]) + Assists(Rotowire_array[j, 7]) + VTCleansheet(Rotowire_array[j, 23]) + Spielzeit_gr60(Rotowire_array[j, 5]) + Spielzeit_kl60(Rotowire_array[j, 5]) + Spiel90min_SM(Rotowire_array[j, 5]) + gelb(Rotowire_array[j, 28]) + rot(Rotowire_array[j, 29]) + Parade(Rotowire_array[j, 25]);
                            array_projections[i, 0] = Rotowire_arrayF[i, 3]; //id
                            array_projections[i, 1] = Rotowire_arrayF[i, 0]; //Name
                            array_projections[i, 2] = Rotowire_arrayF[i, 2]; //pos
                            array_projections[i, 3] = Rotowire_arrayF[i, 1]; //Mannschaft                            
                            array_projections[i, 5] = Rotowire_array[j, 3]; //Gegner
                            array_projections[i, 6] = Proj.ToString(); //Proj
                            Proj = 0;
                        }
                        //Abwehr berechnen
                        if (Rotowire_arrayF[i, 2] == "DEF")
                        {
                            Proj = GoalS(Rotowire_array[j, 6]) + Assists(Rotowire_array[j, 7]) + VTCleansheet(Rotowire_array[j, 23]) + Spielzeit_gr60(Rotowire_array[j, 5]) + Spielzeit_kl60(Rotowire_array[j, 5]) + Spiel90min_SM(Rotowire_array[j, 5]) + gelb(Rotowire_array[j, 28]) + rot(Rotowire_array[j, 29]);
                            array_projections[i, 0] = Rotowire_arrayF[i, 3]; //id
                            array_projections[i, 1] = Rotowire_arrayF[i, 0]; //Name
                            array_projections[i, 2] = Rotowire_arrayF[i, 2]; //pos
                            array_projections[i, 3] = Rotowire_arrayF[i, 1]; //Mannschaft                            
                            array_projections[i, 5] = Rotowire_array[j, 3]; //Gegner
                            array_projections[i, 6] = Proj.ToString(); //Proj
                            Proj = 0;
                        }
                        //Mittelfeld berechnen
                        if (Rotowire_arrayF[i, 2] == "MID")
                        {
                            Proj = GoalS(Rotowire_array[j, 6]) + Assists(Rotowire_array[j, 7]) + VTCleansheet(Rotowire_array[j, 23]) + Spielzeit_gr60(Rotowire_array[j, 5]) + Spielzeit_kl60(Rotowire_array[j, 5]) + Spiel90min_SM(Rotowire_array[j, 5]) + gelb(Rotowire_array[j, 28]) + rot(Rotowire_array[j, 29]);
                            array_projections[i, 0] = Rotowire_arrayF[i, 3]; //id
                            array_projections[i, 1] = Rotowire_arrayF[i, 0]; //Name
                            array_projections[i, 2] = Rotowire_arrayF[i, 2]; //pos
                            array_projections[i, 3] = Rotowire_arrayF[i, 1]; //Mannschaft                            
                            array_projections[i, 5] = Rotowire_array[j, 3]; //Gegner
                            array_projections[i, 6] = Proj.ToString(); //Proj
                            Proj = 0;
                        }
                        //Sturm berechnen
                        if (Rotowire_arrayF[i, 2] == "FOR")
                        {
                            Proj = GoalS(Rotowire_array[j, 6]) + Assists(Rotowire_array[j, 7]) + VTCleansheet(Rotowire_array[j, 23]) + Spielzeit_gr60(Rotowire_array[j, 5]) + Spielzeit_kl60(Rotowire_array[j, 5]) + Spiel90min_SM(Rotowire_array[j, 5]) + gelb(Rotowire_array[j, 28]) + rot(Rotowire_array[j, 29]);
                            array_projections[i, 0] = Rotowire_arrayF[i, 3]; //id
                            array_projections[i, 1] = Rotowire_arrayF[i, 0]; //Name
                            array_projections[i, 2] = Rotowire_arrayF[i, 2]; //pos
                            array_projections[i, 3] = Rotowire_arrayF[i, 1]; //Mannschaft                            
                            array_projections[i, 5] = Rotowire_array[j, 3]; //Gegner
                            array_projections[i, 6] = Proj.ToString(); //Proj
                            Proj = 0;
                        }
                    }
                }
            }


            //Preis hinzufügen
            for (int i = 0; i < Rotowire_arrayF.Length / 4; i++)
            {
                for (int j = 0; j < Fanteam_filter.Count() / 5; j++)
                {
                    if (array_projections[i, 0] == Fanteam_arrayF[j, 3])
                    {
                        array_projections[i, 4] = Fanteam_arrayF[j, 4];
                    }

                }
            }

            for (int i = 0; i < Rotowire_arrayF.Length / 4; i++)
            {
                for (int j = 0; j < Fanteam_filter.Count() / 5; j++)
                {
                    if (array_projections[i, 0] == Fanteam_arrayF[j, 3])
                    {
                        array_projections[i, 4] = Fanteam_arrayF[j, 4];
                    }

                }
            }



            //leere Einträge löschen
            List<string> Final = new List<string>();
            string a;
            for (int i = 0; i < array_projections.Length / 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    label4.Text = array_projections[i, j];
                    if (label4.Text != "")
                    {
                        Final.Add(array_projections[i, j]);
                    }
                }
            }
            int k = 0;
            string[,] array_final = new string[Final.Count() / 7 + 1, 7];
            array_final[0, 0] = "ID";
            array_final[0, 1] = "Name";
            array_final[0, 2] = "Position";
            array_final[0, 3] = "Mannschaft";
            array_final[0, 4] = "Preis";
            array_final[0, 5] = "Gegner";
            array_final[0, 6] = "Proj";
            for (int i = 1; i < Final.Count() / 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    array_final[i, j] = Final[k];
                    k++;
                }
            }
            for (int i = 0; i < Final.Count() / 7; i++)
            {


                array_final[i, 4] = array_final[i, 4].Remove(array_final[i, 4].Length - 1, 1);
            }

            // SpielerID, Name, Position, Team, Preis, Gegner, Projections, TurnieriD, CS
            string[,] upload_array = new string[Final.Count() / 7, 9];
            for (int i = 0; i < Final.Count() / 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    upload_array[i, j] = array_final[i, j];
                }
            }

            //Turnierid hinzufügen

            for (int i = 0; i < Final.Count() / 7; i++)
            {
                upload_array[i, 7] = TurnierID_input.Text;
            }

            // CS hinzufügen

            for (int i = 1; i < Final.Count() / 7; i++)
            {

                for (int l = 0; l < Rotowire_array22.Length / 33; l++)
                {
                    if (upload_array[i, 1] == Rotowire_array22[l, 1])
                    {
                        upload_array[i, 8] = Rotowire_array22[l, 23];
                    }
                }

            }
            if(upload_array.Length<1)
            {
                label3.Text = "zu wenig Daten!!!!!!";
                return;
            }
            upload_array[0, 7] = "TuernierID";
            upload_array[0, 8] = "CS";

            //nochmals alles Filtern
            List<string> abab = new List<string>();
            for(int i=0;i<upload_array.Length/9;i++)
            {
                abab.Add(upload_array[i, 0]);

            }
            abab = abab.Distinct().ToList();
            string[,] temper = new string[abab.Count(), 9];
            
            for (int i=0; i<abab.Count();i++)
            {
                for (int j=0; j<upload_array.Length/9; j++)
                {
                    if(abab[i]==upload_array[j,0])
                    {
                        temper[i, 0] = upload_array[j, 0];
                        temper[i, 1] = upload_array[j, 1];
                        temper[i, 2] = upload_array[j, 2];
                        temper[i, 3] = upload_array[j, 3];
                        temper[i, 4] = upload_array[j, 4];
                        temper[i, 5] = upload_array[j, 5];
                        temper[i, 6] = upload_array[j, 6];
                        temper[i, 7] = upload_array[j, 7];
                        temper[i, 8] = upload_array[j, 8];
                        break;

                    }
                }
            }
            upload_array = temper;

            // upload 2 db
            //mysql tables string erzeugen
            string abcd = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
                `DB_id` int(5) unsigned NOT NULL AUTO_INCREMENT,
                `SpielerID` VARCHAR(50) NOT NULL,
                `Name` VARCHAR(50) NOT NULL,
                `Position` VARCHAR(50) NOT NULL,
                `Team` VARCHAR(50) NOT NULL,
                `Preis` VARCHAR(50) NOT NULL,
                `Gegner` VARCHAR(50) NOT NULL,
                `Proj` VARCHAR(50) NOT NULL,
                `CS` VARCHAR(50) NOT NULL,
                `Turnier_ID` VARCHAR(50) NOT NULL,
                `db_ID1` smallint(5) unsigned NOT NULL DEFAULT '0',
                `Datum` VARCHAR(50) NOT NULL,
                PRIMARY KEY (`DB_id`),
                KEY `Spielerid` (`db_ID1`)) 
                ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "Projections");

            //mysql connection erzeugen
            MySqlConnection con = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            con.Open();

            //mysql DB erzeugen
            var cmda = new MySql.Data.MySqlClient.MySqlCommand(abcd, con);
            cmda.ExecuteNonQuery();
            con.Close();

            //db auslesen
            //liste Wettbewerb erzeugen
            List<string> dbListe1 = new List<string>();
            MySqlCommand command1 = con.CreateCommand();
            command1.CommandText = "SELECT Turnier_ID FROM Projections";
            MySqlDataReader Reader1;
            con.Open();
            Reader1 = command1.ExecuteReader();
            while (Reader1.Read())
            {
                string row1 = "";
                for (int i = 0; i < Reader1.FieldCount; i++)
                {
                    row1 += Reader1.GetValue(i).ToString();
                    dbListe1.Add(row1);
                }
            }
            con.Close();

            dbListe1 = dbListe1.Distinct().ToList();

            int abb = 0;
            for (int i = 0; i < dbListe1.Count(); i++)
            {
                if (dbListe1[i] == TurnierID_input.Text)
                    abb = 1;
            }

            if (abb != 0)
            {
                label3.Text = "Turnier bereits in DB geladen.";
                return;
            }

            //letzte db id auslesen
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Projections";
            MySqlDataReader Reader;
            con.Open();
            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                //Komplette dB auslesen
                //for (int i = 0; i < Reader.FieldCount; i++)

                //letzte id auslesen
                for (int i = 0; i < 1; i++)
                    row += Reader.GetValue(i).ToString();

                label3.Text = row;
            }
            con.Close();


            //daten in db
            con.Open();
            int h;
            if (label3.Text.Length == 0)
            {
                h = 1;
            }
            else
                h = Int32.Parse(label3.Text) + 1;

            string st2;
            string st3;

            for (int i = 1; i < upload_array.Length / 9; i++)
            {
                cmd.CommandText = "INSERT INTO Projections(DB_id, SpielerID, Name, Position, Team, Preis, Gegner, Proj, CS, Turnier_ID, db_ID1, Datum) VALUES(@DB_id, @SpielerID, @Name, @Position, @Team, @Preis, @Gegner, @Proj, @CS, @Turnier_ID, @db_ID1, @Datum)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@DB_id", h + i);
                st2 = upload_array[i, 0];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@SpielerID", st3);
                st2 = upload_array[i, 1];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Name", st3);
                st2 = upload_array[i, 2];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Position", st3);
                st2 = upload_array[i, 3];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Team", st3);
                st2 = upload_array[i, 4];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Preis", st3);
                st2 = upload_array[i, 5];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Gegner", st3);
                st2 = upload_array[i, 6];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Proj", st3);
                st2 = upload_array[i, 8];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@CS", st3);
                st2 = upload_array[i, 7];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Turnier_ID", st3);
                cmd.Parameters.AddWithValue("@db_ID1", h + 1);
                cmd.Parameters.AddWithValue("@Datum", datum);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            con.Close();

            label3.Text = "Upload finished!";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string lineToWrite = null;
            using (StreamReader reader = new StreamReader(@"C:\FantasySports\Python_Scripts\Weekly_Monster_PL.py"))
            {
                for (int i = 1; i <= 5; ++i)
                    lineToWrite = reader.ReadLine();
            }

            // Read the old file.
            string[] lines = File.ReadAllLines(@"C:\FantasySports\Python_Scripts\Weekly_Monster_PL.py");

            // Write the new file over the old file.
            using (StreamWriter writer = new StreamWriter(@"C:\FantasySports\Python_Scripts\Weekly_Monster_PL.py"))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if(i!=4)
                    {
                        writer.WriteLine(lines[i]);

                    }

                    if (i == 4)
                    {
                        writer.WriteLine("Game_ID = "+TurnierID_input.Text);
                    }

                }

            }
            System.Diagnostics.Process.Start(@"C:\FantasySports\Python_Scripts\" + Wettbewerb_combobox.Text + ".py");



        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            //mysql connection erzeugen
            MySqlConnection con = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            con.Open();

            //db auslesen
            List<string> dbListe1 = new List<string>();
            MySqlCommand command1 = con.CreateCommand();
            command1.CommandText = "SELECT * FROM Team_Opti";
            MySqlDataReader Reader1;
            Reader1 = command1.ExecuteReader();
            while (Reader1.Read())
            {
                string row1 = "";
                for (int i = 0; i < Reader1.FieldCount; i++)
                {
                    row1 = Reader1.GetValue(i).ToString();
                    dbListe1.Add(row1);
                }
            }
            con.Close();

            int k = 0;
            string[,] temp= new string[dbListe1.Count() / 15, 15];
            for (int i=0; i< dbListe1.Count()/15;i++)
            {
                for (int j=0; j<15; j++)
                {
                    temp[i, j] = dbListe1[k];
                    k++;
                }
            }
            string datum= System.DateTime.Now.ToShortDateString();
            List<string> temp2 = new List<string>();
            for(int i=0; i<temp.Length/15;i++)
            {
                temp[i, 14] = datumPytoC(temp[i, 14]);
                if(temp[i,14]==datum)
                {
                    temp2.Add(temp[i, 0]);
                    temp2.Add(temp[i, 1]);
                    temp2.Add(temp[i, 2]);
                    temp2.Add(temp[i, 3]);
                    temp2.Add(temp[i, 4]);
                    temp2.Add(temp[i, 5]);
                    temp2.Add(temp[i, 6]);
                    temp2.Add(temp[i, 7]);
                    temp2.Add(temp[i, 8]);
                    temp2.Add(temp[i, 9]);
                    temp2.Add(temp[i, 10]);
                    temp2.Add(temp[i, 11]);
                    temp2.Add(temp[i, 12]);
                    temp2.Add(temp[i, 13]);
                    temp2.Add(temp[i, 14]);

                }
            }

            string[,] Team_download = new string[temp2.Count() / 15, 15];
            k = 0;
            for (int i = 0; i < temp2.Count() / 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Team_download[i, j] = temp2[k];
                    k++;
                }
            }

            using (StreamWriter writer = new StreamWriter(@"C:\FantasySports\Fanteam_Teams\"+TurnierID_input.Text+"_"+datum+".csv"))
            {
                for (int i = 0; i < Team_download.Length/15; i++)
                {
                    writer.WriteLine(Team_download[i,0] + ";"+ Team_download[i, 1] + ";" + Team_download[i, 2] + ";" + Team_download[i, 3] + ";" + Team_download[i, 4] + ";" + Team_download[i, 5] + ";" + Team_download[i, 6] + ";" + Team_download[i, 7] + ";" + Team_download[i, 8] + ";" + Team_download[i, 9] + ";" + Team_download[i, 10] + ";" + Team_download[i, 11] + ";" + Team_download[i, 12] + ";" + Team_download[i, 13] + ";" + Team_download[i, 14] );

                    
                }

            }

        }
    }
}

/*








        // Pythonscript starten und "Game_ID = 1111111" durch "Game_ID = input.Text"

        StreamReader inputStreamReader = File.OpenText(@"C:\FantasySports\Python_Scripts\"+Wettbewerb_combobox.Text+".py");
            String Inhalt = inputStreamReader.ReadToEnd();
            inputStreamReader.Close();

            String ersetzen = "Game_ID = 1111111";
            String durch = "Game_ID = "+TurnierID_input.Text;

            Inhalt = Inhalt.Replace(ersetzen, durch);

            StreamWriter outputStreamWriter = File.CreateText(@"C:\FantasySports\Python_Scripts\" + Wettbewerb_combobox.Text + ".py");
            outputStreamWriter.Write(Inhalt);
            outputStreamWriter.Close();
                       
            System.Diagnostics.Process.Start(@"C:\FantasySports\Python_Scripts\" + Wettbewerb_combobox.Text + ".py");

        }
    }
    //Klasse zum array sortieren
    public static class MultiDimensionalArrayExtensions
    {
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderBy<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().OrderBy(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector in descending order.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderByDescending<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().
                OrderByDescending(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Converts a two dimensional array to single dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source two dimensional array.</param>
        /// <returns>The repackaged two dimensional array as a single dimension based on rows.</returns>
        private static IEnumerable<T[]> ConvertToSingleDimension<T>(this T[,] source)
        {
            T[] arRow;

            for (int row = 0; row < source.GetLength(0); ++row)
            {
                arRow = new T[source.GetLength(1)];

                for (int col = 0; col < source.GetLength(1); ++col)
                    arRow[col] = source[row, col];

                yield return arRow;
            }
        }
        /// <summary>
        ///   Converts a collection of rows from a two dimensional array back into a two dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source collection of rows to convert.</param>
        /// <returns>The two dimensional array.</returns>
        private static T[,] ConvertToMultiDimensional<T>(this IEnumerable<T[]> source)
        {
            T[,] twoDimensional;
            T[][] arrayOfArray;
            int numberofColumns;

            arrayOfArray = source.ToArray();
            numberofColumns = (arrayOfArray.Length > 0) ? arrayOfArray[0].Length : 0;
            twoDimensional = new T[arrayOfArray.Length, numberofColumns];

            for (int row = 0; row < arrayOfArray.GetLength(0); ++row)
                for (int col = 0; col < numberofColumns; ++col)
                    twoDimensional[row, col] = arrayOfArray[row][col];

            return twoDimensional;
        }
    }

    
}





            /*




























































            ///////
            ///////
            /////Optimierung
            ///





            // in MID DEF usw aufteilen
            List<string> GK = new List<string>();
            List<string> DEF = new List<string>();
            List<string> MID = new List<string>();
            List<string> FOR = new List<string>();

            for (int i = 0; i < array_final.Length / 7; i++)
            {
                if (array_final[i, 2] == "GK")
                {
                    GK.Add(array_final[i, 0]);
                }
                if (array_final[i, 2] == "DEF")
                {
                    DEF.Add(array_final[i, 0]);
                }
                if (array_final[i, 2] == "MID")
                {
                    MID.Add(array_final[i, 0]);
                }
                if (array_final[i, 2] == "FOR")
                {
                    FOR.Add(array_final[i, 0]);
                }
            }

            int[] GK_A = list2array1d(GK);
            int[] DEF_A = list2array1d(DEF);
            int[] MID_A = list2array1d(MID);
            int[] FOR_A = list2array1d(FOR);




            //Liste mit Kombinationen erzeugen
            List<int> GK1 = Aufruf(GK_A, 1);
            List<int> DEF2 = Aufruf(DEF_A, 2);
            List<int> DEF3 = Aufruf(DEF_A, 3);
            List<int> DEF4 = Aufruf(DEF_A, 4);
            List<int> MID2 = Aufruf(MID_A, 2);
            List<int> MID3 = Aufruf(MID_A, 3);
            List<int> MID4 = Aufruf(MID_A, 4);
            List<int> FOR2 = Aufruf(FOR_A, 2);
            List<int> FOR3 = Aufruf(FOR_A, 3);
            List<int> FOR4 = Aufruf(FOR_A, 4);


            //Array erzeugen aus Listen 
            string[,] GK11 = double2string(GK1, 3);
            string[,] DEF22 = double2string(DEF2, 4);
            string[,] DEF33 = double2string(DEF3, 5);
            string[,] DEF44 = double2string(DEF4, 6);
            string[,] MID22 = double2string(MID2, 4);
            string[,] MID33 = double2string(MID3, 5);
            string[,] MID44 = double2string(MID4, 6);
            string[,] FOR22 = double2string(FOR2, 4);
            string[,] FOR33 = double2string(FOR3, 5);
            string[,] FOR44 = double2string(FOR4, 6);


            //Preis hinzufügen
            GK11 = Gesamtpreis(GK11, array_final, 1);
            DEF22 = Gesamtpreis(DEF22, array_final, 2);
            DEF33 = Gesamtpreis(DEF33, array_final, 3);
            DEF44 = Gesamtpreis(DEF44, array_final, 4);
            MID22 = Gesamtpreis(MID22, array_final, 2);
            MID33 = Gesamtpreis(MID33, array_final, 3);
            MID44 = Gesamtpreis(MID44, array_final, 4);
            FOR22 = Gesamtpreis(FOR22, array_final, 2);
            FOR33 = Gesamtpreis(FOR33, array_final, 3);
            FOR44 = Gesamtpreis(FOR44, array_final, 4);

            //Proj hinzufügen
            GK11 = Gesamtproj(GK11, array_final, 1);
            DEF22 = Gesamtproj(DEF22, array_final, 2);
            DEF33 = Gesamtproj(DEF33, array_final, 3);
            DEF44 = Gesamtproj(DEF44, array_final, 4);
            MID22 = Gesamtproj(MID22, array_final, 2);
            MID33 = Gesamtproj(MID33, array_final, 3);
            MID44 = Gesamtproj(MID44, array_final, 4);
            FOR22 = Gesamtproj(FOR22, array_final, 2);
            FOR33 = Gesamtproj(FOR33, array_final, 3);
            FOR44 = Gesamtproj(FOR44, array_final, 4);



            //Liste Teams erstellen
            List<string> Teams = new List<string>();
            for (int i = 1; i < array_final.Length / 7; i++)
            {
                Teams.Add(array_final[i, 3]);
            }
            Teams = Teams.Distinct().ToList();

            //Array Teamid erstellen
            string[,] Teamid_array = new string[Teams.Count(), 2];
            for (int i = 0; i < Teams.Count() - 1; i++)
            {
                Teamid_array[i, 0] = Teams[i];
                Teamid_array[i, 1] = "0";
            }

            //Ref Team spielerliste erstellen
            List<string> Spielerliste = new List<string>();
            for (int i = 0; i < array_final.Length / 7; i++)
            {
                Spielerliste.Add(array_final[i, 0]);
            }
            Spielerliste = Spielerliste.Distinct().ToList();
            string[,] Ref_pl_team = new string[Spielerliste.Count(), 3];

            //Spielerid hinzufügen
            for (int i = 0; i < Ref_pl_team.Length / 3; i++)
            {
                Ref_pl_team[i, 0] = Spielerliste[i];
            }

            //Teamid hinzufügen
            for (int i = 0; i < Ref_pl_team.Length / 3; i++)
            {
                for (int j = 0; j < array_final.Length / 7; j++)
                {
                    if (Ref_pl_team[i, 0] == array_final[j, 0])
                    {
                        Ref_pl_team[i, 1] = array_final[j, 3];
                        break;
                    }
                }
            }

            //Begegnungid hinzufügen
            // Array mit Begegnungen erstellen
            //
            string[,] Spiele = new string[Teams.Count(), 2];
            for (int i = 0; i < Teams.Count(); i++)
            {
                for (int j = 0; j < array_final.Length / 7; j++)
                {
                    if (Teams[i] == array_final[j, 3])
                    {
                        Spiele[i, 0] = Teams[i];
                        Spiele[i, 1] = array_final[j, 5];

                        break;

                    }
                }
            }
            int z = 0;
            for (int i = 0; i < Spiele.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < Spiele.Length / 2; l++)
                    {
                        for (int m = 0; m < 2; m++)
                        {
                            if (Spiele[i, j] == Spiele[l, m])
                            {
                                z = z + 1;
                            }
                            if (z > 1)
                            {
                                Spiele[l, m] = "";
                            }

                        }
                    }
                    z = 0;
                }

            }



            //Array Kürzen über Liste und anschließend id für Begegnung vergeben
            List<string> Begegnungen = new List<string>();
            for (int i = 0; i < Spiele.Length / 2; i++)
            {
                if (Spiele[i, 0] != "")
                {
                    Begegnungen.Add(Spiele[i, 0]);
                    Begegnungen.Add(Spiele[i, 1]);
                }
            }
            string[,] Begegnungen_ref = new string[Begegnungen.Count() / 2, 3];
            k = 0;
            for (int i = 0; i < Begegnungen_ref.Length / 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {

                    Begegnungen_ref[i, j] = Begegnungen[k];
                    k = k + 1;

                }
            }
            k = 0;
            for (int i = 0; i < Begegnungen_ref.Length / 3; i++)
            {
                Begegnungen_ref[i, 2] = k.ToString();
                k = k + 1;
            }




            // MID44            
            for (int i = 0; i < MID44.Length / 6; i++)
            {
                for (int j = 0; j < Ref_pl_team.Length / 3; j++)
                {
                    if (MID44[i, 0] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }
                    if (MID44[i, 1] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }
                    if (MID44[i, 2] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }
                    if (MID44[i, 3] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }

                }
                for (int n = 0; n < Teamid_array.Length / 2; n++)
                {
                    if (Teamid_array[n, 1] == "3")
                    {
                        MID44[i, 0] = "";
                        MID44[i, 2] = "";
                        MID44[i, 1] = "";
                        MID44[i, 3] = "";
                        MID44[i, 4] = "";
                        MID44[i, 5] = "";
                    }
                }
                for (int m = 0; m < Teamid_array.Length / 2; m++)
                {
                    Teamid_array[m, 1] = "0";
                }
            }
            List<string> MID44_KL = new List<string>();
            for (int i = 0; i < MID44.Length / 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (MID44[i, j] != "")
                    {
                        MID44_KL.Add(MID44[i, j]);
                    }

                }
            }
            MID44 = list2array(MID44_KL, 6);

            // FOR44
            for (int i = 0; i < FOR44.Length / 6; i++)
            {
                for (int j = 0; j < Ref_pl_team.Length / 3; j++)
                {
                    if (FOR44[i, 0] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }
                    if (FOR44[i, 1] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }
                    if (FOR44[i, 2] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }
                    if (FOR44[i, 3] == Ref_pl_team[j, 0])
                    {
                        for (int l = 0; l < Teamid_array.Length / 2; l++)
                        {
                            if (Ref_pl_team[j, 1] == Teamid_array[l, 0])
                            {
                                int x = 0;
                                Int32.TryParse(Teamid_array[l, 1], out x);
                                x = x + 1;
                                Teamid_array[l, 1] = x.ToString();
                            }
                        }
                    }

                }
                for (int n = 0; n < Teamid_array.Length / 2; n++)
                {
                    if (Teamid_array[n, 1] == "3")
                    {
                        FOR44[i, 0] = "";
                        FOR44[i, 2] = "";
                        FOR44[i, 1] = "";
                        FOR44[i, 3] = "";
                        FOR44[i, 4] = "";
                        FOR44[i, 5] = "";
                    }
                }
                for (int m = 0; m < Teamid_array.Length / 2; m++)
                {
                    Teamid_array[m, 1] = "0";
                }
            }
            List<string> FOR44_KL = new List<string>();
            for (int i = 0; i < FOR44.Length / 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (FOR44[i, j] != "")
                    {
                        FOR44_KL.Add(FOR44[i, j]);
                    }

                }
            }
            FOR44 = list2array(FOR44_KL, 6);

            //Mannschaft_id
            Begegnungen = Begegnungen.Distinct().ToList();
            string[,] Team_id = new string[Begegnungen.Count(), 2];
            for (int i = 0; i < Begegnungen.Count(); i++)
            {
                Team_id[i, 0] = Begegnungen[i];
                Team_id[i, 1] = i.ToString();

            }

            //string in double umwandeln
            double[,] GK111 = string2double(GK11, 3);
            double[,] DEF222 = string2double(DEF22, 4);
            double[,] DEF333 = string2double(DEF33, 5);
            double[,] DEF444 = string2double(DEF44, 6);
            double[,] MID222 = string2double(MID22, 4);
            double[,] MID333 = string2double(MID33, 5);
            double[,] MID444 = string2double(MID44, 6);
            double[,] FOR222 = string2double(FOR22, 4);
            double[,] FOR333 = string2double(FOR33, 5);
            double[,] FOR444 = string2double(FOR44, 6);






            // Erweitern mit Teamid und Begegnungid
            double[,] GK_1 = new double[GK111.Length / 3, 6];
            for (int i = 0; i < GK111.Length / 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GK_1[i, j] = GK111[i, j];
                }
            }
            double[,] DEF_2 = new double[DEF222.Length / 4, 9];
            for (int i = 0; i < DEF222.Length / 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    DEF_2[i, j] = DEF222[i, j];
                }
            }
            double[,] DEF_3 = new double[DEF333.Length / 5, 12];
            for (int i = 0; i < DEF333.Length / 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    DEF_3[i, j] = DEF333[i, j];
                }
            }
            double[,] DEF_4 = new double[DEF444.Length / 6, 15];
            for (int i = 0; i < DEF444.Length / 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    DEF_4[i, j] = DEF444[i, j];
                }
            }
            double[,] MID_2 = new double[MID222.Length / 4, 9];
            for (int i = 0; i < MID222.Length / 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    MID_2[i, j] = MID222[i, j];
                }
            }
            double[,] MID_3 = new double[MID333.Length / 5, 12];
            for (int i = 0; i < MID333.Length / 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MID_3[i, j] = MID333[i, j];
                }
            }
            double[,] MID_4 = new double[MID444.Length / 6, 15];
            for (int i = 0; i < MID444.Length / 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    MID_4[i, j] = MID444[i, j];
                }
            }
            double[,] FOR_2 = new double[FOR222.Length / 4, 9];
            for (int i = 0; i < FOR222.Length / 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    FOR_2[i, j] = FOR222[i, j];
                }
            }
            double[,] FOR_3 = new double[FOR333.Length / 5, 12];
            for (int i = 0; i < FOR333.Length / 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    FOR_3[i, j] = FOR333[i, j];
                }
            }
            double[,] FOR_4 = new double[FOR444.Length / 6, 15];
            for (int i = 0; i < FOR444.Length / 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    FOR_4[i, j] = FOR444[i, j];
                }
            }


            //Teamid hinzufügen
            for (int i = 0; i < (GK111.Length / 3); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (GK_1[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    GK_1[i, j + 3] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (DEF222.Length / 4); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (DEF_2[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    DEF_2[i, j + 4] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (DEF333.Length / 5); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (DEF_3[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    DEF_3[i, j + 5] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (DEF444.Length / 6); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (DEF_4[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    DEF_4[i, j + 6] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (MID222.Length / 4); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (MID_2[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    MID_2[i, j + 4] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (MID333.Length / 5); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (MID_3[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    MID_3[i, j + 5] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (MID444.Length / 6); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (MID_4[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    MID_4[i, j + 6] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (FOR222.Length / 4); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (FOR_2[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    FOR_2[i, j + 4] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (FOR333.Length / 5); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (FOR_3[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    FOR_3[i, j + 5] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (FOR444.Length / 6); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (FOR_4[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Team_id.Length / 2); m++)
                            {
                                if (Team_id[m, 0] == Ref_pl_team[l, 1])
                                {
                                    FOR_4[i, j + 6] = Int32.Parse(Team_id[m, 1]);
                                }
                            }
                        }
                    }
                }
            }

            //Begegnung id hinzufügen
            for (int i = 0; i < (GK111.Length / 3); i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (GK_1[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    GK_1[i, j + 4] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (DEF222.Length / 4); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (DEF_2[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    DEF_2[i, j + 6] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (DEF333.Length / 5); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (DEF_3[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    DEF_3[i, j + 8] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (DEF444.Length / 6); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (DEF_4[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    DEF_4[i, j + 10] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (MID222.Length / 4); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (MID_2[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    MID_2[i, j + 6] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (MID333.Length / 5); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (MID_3[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    MID_3[i, j + 8] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (MID444.Length / 6); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (MID_4[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    MID_4[i, j + 10] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (FOR222.Length / 4); i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (FOR_2[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    FOR_2[i, j + 6] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (FOR333.Length / 5); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (FOR_3[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    FOR_3[i, j + 8] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < (FOR444.Length / 6); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int l = 0; l < (Ref_pl_team.Length / 3); l++)
                    {
                        if (FOR_4[i, j].ToString() == Ref_pl_team[l, 0])
                        {
                            for (int m = 0; m < (Begegnungen_ref.Length / 3); m++)
                            {
                                if (Begegnungen_ref[m, 0] == Ref_pl_team[l, 1] || Begegnungen_ref[m, 1] == Ref_pl_team[l, 1])
                                {
                                    FOR_4[i, j + 10] = Int32.Parse(Begegnungen_ref[m, 2]);
                                }
                            }
                        }
                    }
                }
            }

            //Points per Doller hinzufügen
            for (int i=0; i<GK_1.Length/6;i++)
            {
                GK_1[i, 5] = GK_1[i, 2] / GK_1[i, 1];
            }
            for (int i=0; i<DEF_2.Length/9;i++)
            {
                DEF_2[i, 8] = DEF_2[i, 3] / DEF_2[i, 2];
            }
            for (int i = 0; i < DEF_3.Length / 12; i++)
            {
                DEF_3[i, 11] = DEF_3[i, 4] / DEF_3[i, 3];
            }
            for (int i = 0; i < DEF_4.Length / 15; i++)
            {
                DEF_4[i, 14] = DEF_4[i, 5] / DEF_4[i, 4];
            }
            for (int i = 0; i < MID_2.Length / 9; i++)
            {
                MID_2[i, 8] = MID_2[i, 3] / MID_2[i, 2];
            }
            for (int i = 0; i < MID_3.Length / 12; i++)
            {
                MID_3[i, 11] = MID_3[i, 4] / MID_3[i, 3];
            }
            for (int i = 0; i < MID_4.Length / 15; i++)
            {
                MID_4[i, 14] = MID_4[i, 5] / MID_4[i, 4];
            }
            for (int i = 0; i < FOR_2.Length / 9; i++)
            {
                FOR_2[i, 8] = FOR_2[i, 3] / FOR_2[i, 2];
            }
            for (int i = 0; i < FOR_3.Length / 12; i++)
            {
                FOR_3[i, 11] = FOR_3[i, 4] / FOR_3[i, 3];
            }
            for (int i = 0; i < FOR_4.Length / 15; i++)
            {
                FOR_4[i, 14] = FOR_4[i, 5] / FOR_4[i, 4];
            }

            //Sortieren Points per doller aufsteigend
            //MID_4
            double[,] GK_1S = GK_1.OrderBy(x => x[5]);
            double[,] DEF_2S = DEF_2.OrderBy(x => x[8]);
            double[,] DEF_3S = DEF_3.OrderBy(x => x[11]);
            double[,] DEF_4S = DEF_4.OrderBy(x => x[14]);
            double[,] MID_2S = MID_2.OrderBy(x => x[8]);
            double[,] MID_3S = MID_3.OrderBy(x => x[11]);
            double[,] MID_4S = MID_4.OrderBy(x => x[14]);
            double[,] FOR_2S = FOR_2.OrderBy(x => x[8]);
            double[,] FOR_3S = FOR_3.OrderBy(x => x[11]);
            double[,] FOR_4S = FOR_4.OrderBy(x => x[14]);


            //Array kürzen
            if((GK_1S.Length/6)>100)
            {
                int counter = 0;
                double[,] GK_1SK = new double[100, 6];
                for(int i = GK_1S.Length / 6;i>= GK_1S.Length / 6 - 100;i--)
                {
                    for(int j=0;j<6;j++)
                    {
                        GK_1SK[counter, j] = GK_1S[i, j];
                    }
                    counter++;
                }
                GK_1S = GK_1SK;

            }
            if ((DEF_2S.Length / 9) > 100)
            {
                int counter = 0;
                double[,] DEF_2SK = new double[100, 9];
                for (int i = (DEF_2S.Length / 9)-1; i >= (DEF_2S.Length / 9) - 100; i--)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        DEF_2SK[counter, j] = DEF_2S[i, j];
                    }
                    counter++;
                }
                DEF_2S = DEF_2SK;

            }
            if ((DEF_3S.Length / 12) > 100)
            {
                int counter = 0;
                double[,] DEF_3SK = new double[100, 12];
                for (int i = (DEF_3S.Length / 12)-1; i >= (DEF_3S.Length / 12) - 100; i--)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        DEF_3SK[counter, j] = DEF_3S[i, j];
                    }
                    counter++;
                }
                DEF_3S = DEF_3SK;

            }
            if ((DEF_4S.Length / 15) > 100)
            {
                int counter = 0;
                double[,] DEF_4SK = new double[100, 15];
                for (int i = (DEF_4S.Length / 15)-1; i >= (DEF_4S.Length / 15) - 100; i--)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        DEF_4SK[counter, j] = DEF_4S[i, j];
                    }
                    counter++;
                }
                DEF_4S = DEF_4SK;

            }
            if ((MID_2S.Length / 9) > 100)
            {
                int counter = 0;
                double[,] MID_2SK = new double[100, 9];
                for (int i = (DEF_2S.Length / 9) - 1; i >= (MID_2S.Length / 9) - 100; i--)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        MID_2SK[counter, j] = MID_2S[i, j];
                    }
                    counter++;
                }
                MID_2S = MID_2SK;

            }
            if ((MID_3S.Length / 12) > 100)
            {
                int counter = 0;
                double[,] MID_3SK = new double[100, 12];
                for (int i = (MID_3S.Length / 12) - 1; i >= (MID_3S.Length / 12) - 100; i--)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        MID_3SK[counter, j] = MID_3S[i, j];
                    }
                    counter++;
                }
                MID_3S = MID_3SK;

            }
            if ((MID_4S.Length / 15) > 100)
            {
                int counter = 0;
                double[,] MID_4SK = new double[100, 15];
                for (int i = (MID_4S.Length / 15) - 1; i >= (MID_4S.Length / 15) - 100; i--)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        MID_4SK[counter, j] = MID_4S[i, j];
                    }
                    counter++;
                }
                MID_4S = MID_4SK;

            }
            if ((FOR_2S.Length / 9) > 100)
            {
                int counter = 0;
                double[,] FOR_2SK = new double[100, 9];
                for (int i = (FOR_2S.Length / 9) - 1; i >= (FOR_2S.Length / 9) - 100; i--)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        FOR_2SK[counter, j] = FOR_2S[i, j];
                    }
                    counter++;
                }
                FOR_2S = FOR_2SK;

            }
            if ((FOR_3S.Length / 12) > 100)
            {
                int counter = 0;
                double[,] FOR_3SK = new double[100, 12];
                for (int i = (FOR_3S.Length / 12) - 1; i >= (FOR_3S.Length / 12) - 100; i--)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        FOR_3SK[counter, j] = FOR_3S[i, j];
                    }
                    counter++;
                }
                FOR_3S = FOR_3SK;

            }
            if ((FOR_4S.Length / 15) > 100)
            {
                int counter = 0;
                double[,] FOR_4SK = new double[100, 15];
                for (int i = (FOR_4S.Length / 15) - 1; i >= (FOR_4S.Length / 15) - 100; i--)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        FOR_4SK[counter, j] = FOR_4S[i, j];
                    }
                    counter++;
                }
                FOR_4S = FOR_4SK;

            }

            

            //GK1DEF4
            //
            List<double> temp1 = new List<double>();
            for(int i=0;i<GK_1S.Length/6;i++)
            {
                for(int j=0; j<DEF_4S.Length/15; j++)
                {
                    temp1.Add(GK_1S[i, 0]);
                    temp1.Add(GK_1S[i, 1]);
                    temp1.Add(GK_1S[i, 2]);
                    temp1.Add(GK_1S[i, 3]);
                    temp1.Add(GK_1S[i, 4]);
                    temp1.Add(GK_1S[i, 5]);
                    temp1.Add(DEF_4S[j, 0]);
                    temp1.Add(DEF_4S[j, 1]);
                    temp1.Add(DEF_4S[j, 2]);
                    temp1.Add(DEF_4S[j, 3]);
                    temp1.Add(DEF_4S[j, 4]);
                    temp1.Add(DEF_4S[j, 5]);
                    temp1.Add(DEF_4S[j, 6]);
                    temp1.Add(DEF_4S[j, 7]);
                    temp1.Add(DEF_4S[j, 8]);
                    temp1.Add(DEF_4S[j, 9]);
                    temp1.Add(DEF_4S[j, 10]);
                    temp1.Add(DEF_4S[j, 11]);
                    temp1.Add(DEF_4S[j, 12]);
                    temp1.Add(DEF_4S[j, 13]);
                    temp1.Add(DEF_4S[j, 14]);
                }
            }
            double[,] GK1DEF4 = new double[temp1.Count() / 21, 21];
            k = 0;
            for(int i=0; i< temp1.Count() / 21;i++)
            {
                for (int j=0; j< 21;j++)
                {
                    GK1DEF4[i, j] = temp1[k];
                    k++;
                }
            }
            //ordnen
            double[,] temp2 = new double[temp1.Count() / 21, 17];
            for(int i=0; i<GK1DEF4.Length/21;i++)
            {
                temp2[i, 0] = GK1DEF4[i, 0];
                temp2[i, 1] = GK1DEF4[i, 6];
                temp2[i, 2] = GK1DEF4[i, 7];
                temp2[i, 3] = GK1DEF4[i, 8];
                temp2[i, 4] = GK1DEF4[i, 9];
                temp2[i, 5] = GK1DEF4[i, 10]+GK1DEF4[i,1];
                temp2[i, 6] = GK1DEF4[i, 11]+GK1DEF4[i,2];
                temp2[i, 7] = GK1DEF4[i, 3];
                temp2[i, 8] = GK1DEF4[i, 12];
                temp2[i, 9] = GK1DEF4[i, 13];
                temp2[i, 10] = GK1DEF4[i, 14];
                temp2[i, 11] = GK1DEF4[i, 15];
                temp2[i, 12] = GK1DEF4[i, 4];
                temp2[i, 13] = GK1DEF4[i, 16];
                temp2[i, 14] = GK1DEF4[i, 17];
                temp2[i, 15] = GK1DEF4[i, 18];
                temp2[i, 16] = GK1DEF4[i, 19];
            }
            

            
            
            //Team generieren
            double[,] best = new double[1, 13];
            for (int i = 0; i < 13; i++)
            {
                best[0, i] = 0.0;
            }

            for (int i=0; i<(GK1DEF4.Length/17);i++)
            {
                for(int j=0; j<(MID_4S.Length/15);j++)
                {
                    for (int l=0; l<(FOR_2S.Length/9);l++)
                    {

                            if(GK1DEF4[i,5]+MID_4S[j,4]+FOR_2S[l,2]<100)
                            {
                            /*
                                if(GK1DEF4[i, 6] + MID_4S[j, 5] + FOR_2S[l, 3] > best[0,12])
                                {

                                        
                                            best[0, 0] = GK1DEF4[i, 0];
                                            best[0, 1] = GK1DEF4[i, 1];
                                            best[0, 2] = GK1DEF4[i, 2];
                                            best[0, 3] = GK1DEF4[i, 3];
                                            best[0, 4] = GK1DEF4[i, 4];
                                            best[0, 5] = MID_4S[j, 0];
                                            best[0, 6] = MID_4S[j, 1];
                                            best[0, 7] = MID_4S[j, 2];
                                            best[0, 8] = MID_4S[j, 3];
                                            best[0, 9] = FOR_2S[l, 0];
                                            best[0, 10] = FOR_2S[l, 1];
                                            best[0, 12] = (GK1DEF4[i, 6] + MID_4S[j, 5] + FOR_2S[l, 3]);
                                            best[0, 11] = (GK1DEF4[i, 5] + MID_4S[j, 4] + FOR_2S[l, 2]);

                                        

                                    






                                }

                                
      
    
    






           // label4.Text = best[0,11]+"  "+best[0,12];
        }
    }
}
            
             

            for (int i=0; i<(GK_1.Length/5);i++)
            {

                for (int j=0; j<(14);j++)
                {
                    //10 sec warten
                    System.Threading.Thread.Sleep(10000);
                    
                    for (int l=0; l<(MID_4.Length/14);l++)
                    {
                        for (int m=0; m<(FOR_2.Length/8);m++)
                        {   
                            
                            //Preis<100
                            if((GK_1[i,1]+DEF_4[j,4]+MID_4[l,4]+FOR_2[m,2])>100)
                            {
                                break;
                            }

                            //Proj>temP
                            if ((GK_1[i, 2] + DEF_4[j, 5] + MID_4[l, 5] + FOR_2[m, 3]) < best[0,11])
                            {
                                break;
                            }

                            //Stürmer gegen Goalie 1
                            if (MID_4[l,10]==FOR_2[m,6]|| MID_4[l, 10] == FOR_2[m, 7])
                            {
                                break;
                            }
                            
                            best[0, 0] = GK_1[i, 0];
                            best[0, 1] = DEF_4[j, 0];
                            best[0, 2] = DEF_4[j, 1];
                            best[0, 3] = DEF_4[j, 2];
                            best[0, 4] = DEF_4[j, 3];
                            best[0, 5] = MID_4[l, 0];
                            best[0, 6] = MID_4[l, 1];
                            best[0, 7] = MID_4[l, 2];
                            best[0, 8] = MID_4[l, 3];
                            best[0, 9] = FOR_2[m, 0];
                            best[0, 10] = FOR_2[m, 1];
                            best[0, 11] = (GK_1[i, 2] + DEF_4[j, 5] + MID_4[l, 5] + FOR_2[m, 3]);
                            best[0, 12] = (GK_1[i, 1] + DEF_4[j, 4] + MID_4[l, 4] + FOR_2[m, 2]);
                            


                        }
                    }
            
                }
            }
            label3.Text = "FERTIG";
        }
    }
}



/*




            //array für ausgabe erzeugen
            double[,] best = new double[1, 13];
            for (int i = 0; i < 13; i++)
            {
                best[0, i] = 0.0;
            }
            string[,] best1 = new string[2, 13];

            for (int i = 0; i < GK111.Length / 3; i++)
            {
                for (int j = 0; j < DEF444.Length / 6; j++)
                {
                    for (int l = 0; l < MID444.Length / 6; l++)
                    {
                        for (int m = 0; m < FOR222.Length / 4; m++)
                        {   //Preis prüfen
                            if ((100 > GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]))

                            {   //Proj prüfen
                                if (best[0, 11] < GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3])
                                {
                                    //Spieler von Team<3
                                    for (int o = 0; o < Ref_pl_team.Length / 2; o++)
                                    {
                                        //GK
                                        if (GK111[i, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF1
                                        if (DEF444[j, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF2
                                        if (DEF444[j, 1].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF3
                                        if (DEF444[j, 2].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF4
                                        if (DEF444[j, 3].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID1
                                        if (MID444[l, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID2
                                        if (MID444[l, 1].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID3
                                        if (MID444[l, 2].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID4
                                        if (MID444[l, 3].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //FOR1
                                        if (FOR222[m, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //FOR2
                                        if (FOR222[m, 2].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                    }
                                    k = 0;
                                    for (int r = 0; r < Teamid_array.Length / 2; r++)
                                    {
                                        if (Teamid_array[r, 1] == "4")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "5")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "6")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "7")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "8")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "9")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "10")
                                        {
                                            k = 1;
                                        }
                                        if (Teamid_array[r, 1] == "11")
                                        {
                                            k = 1;
                                        }

                                    }
                                    if (k != 1)
                                    {
                                        //Stacking Abwehr und GC
                                        //Stacking

                                        //Staking -> neuer array mit id, Team, CS
                                        string[,] temp = new string[3, 13];
                                        temp[0, 0] = GK111[i, 0].ToString();
                                        temp[0, 1] = DEF444[j, 0].ToString();
                                        temp[0, 2] = DEF444[j, 1].ToString();
                                        temp[0, 3] = DEF444[j, 2].ToString();
                                        temp[0, 4] = DEF444[j, 3].ToString();
                                        temp[0, 5] = MID444[l, 0].ToString();
                                        temp[0, 6] = MID444[l, 1].ToString();
                                        temp[0, 7] = MID444[l, 2].ToString();
                                        temp[0, 8] = MID444[l, 3].ToString();
                                        temp[0, 9] = FOR444[m, 0].ToString();
                                        temp[0, 10] = FOR444[m, 1].ToString();
                                        temp[0, 11] = (GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3]).ToString();
                                        temp[0, 12] = (GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]).ToString();

                                        for (int r = 0; r < 11; r++)
                                        {
                                            for (int s = 0; s < Referenz_array.Length / 7; s++)
                                            {
                                                if (temp[0, r] == Referenz_array[s, 0])
                                                {
                                                    temp[1, r] = Referenz_array[s, 2];
                                                }
                                            }
                                        }
                                        for (int r = 0; r < 11; r++)
                                        {
                                            for (int s = 0; s < Rotowire_array.Length / 33; s++)
                                            {
                                                if (temp[0, r] == Rotowire_array[s, 2])
                                                {
                                                    temp[2, r] = Referenz_array[s, 23];
                                                }
                                            }
                                        }


                                        List<double> abzug = new List<double>();
                                        List<string> temp2 = new List<string>();
                                        for (int x = 0; x < 5; x++)
                                        {
                                            temp2.Add(temp[1, x]);
                                        }
                                        temp2 = temp2.Distinct().ToList();
                                        string[,] temp3 = new string[2, temp2.Count()];
                                        for (int x = 0; x < temp3.Length / 2; x++)
                                        {
                                            temp3[0, x] = temp2[x];
                                        }
                                        for (int x = 0; x < temp3.Length / 2; x++)
                                        {
                                            temp3[1, x] = "0";
                                        }
                                        for (int x = 0; x < temp2.Count(); x++)
                                        {
                                            for (int y = 0; y < 5; y++)
                                            {
                                                if (temp3[0, y] == temp[0, x])
                                                {
                                                    int d = 0;
                                                    Int32.TryParse(temp[1, y], out d);
                                                    d = d + 1;
                                                    temp3[1, y] = d.ToString();
                                                }
                                            }
                                        }
                                        for (int x = 0; x < temp3.Length / 2; x++)
                                        {
                                            for (int y = 0; y < temp.Length / 3; y++)
                                            {
                                                if (temp3[0, x] == temp[0, y])
                                                {
                                                    double d;
                                                    double.TryParse(temp[2, y], NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out d);
                                                    int dd = 0;
                                                    Int32.TryParse(temp3[1, y], out dd);
                                                    if (dd == 2)
                                                    {
                                                        abzug.Add(8 * d - 7 * d);
                                                    }
                                                    if (dd == 3)
                                                    {
                                                        abzug.Add(12 * d - 9 * d);
                                                    }

                                                    break;
                                                }
                                            }
                                        }
                                        double abzug_ges = 0;
                                        for (int x = 0; x < abzug.Count(); x++)
                                        {
                                            abzug_ges = abzug_ges + abzug[x];

                                        }
                                        if ((GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3] + abzug_ges) > best[0, 11])
                                        {

                                            //goalie gegen stürmer ausschließen

                                            for (int x = 0; x < 13; x++)
                                            {
                                                for (int y = 0; y < Ref_pl_team.Length / 2; y++)
                                                {
                                                    if (temp[0, x].ToString() == Ref_pl_team[y, 1])
                                                    {
                                                        best1[0, x] = temp[0, x];
                                                        best1[1, x] = Ref_pl_team[y, 0];

                                                    }
                                                }

                                            }

                                            int ll = 0;
                                            for (int x = 0; x < 5; x++)
                                            {
                                                for (int y = 5; y < 11; y++)
                                                {
                                                    if (best1[1, x] == best1[1, y])
                                                    {
                                                        ll = 1;
                                                    }

                                                }
                                            }
                                            if(ll==0)
                                            {
                                                best[0, 0] = GK111[i, 0];
                                                best[0, 1] = DEF444[j, 0];
                                                best[0, 2] = DEF444[j, 1];
                                                best[0, 3] = DEF444[j, 2];
                                                best[0, 4] = DEF444[j, 3];
                                                best[0, 5] = MID444[l, 0];
                                                best[0, 6] = MID444[l, 1];
                                                best[0, 7] = MID444[l, 2];
                                                best[0, 8] = MID444[l, 3];
                                                best[0, 9] = FOR222[m, 0];
                                                best[0, 10] = FOR222[m, 1];
                                                best[0, 11] = (GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3] + abzug_ges);
                                                best[0, 12] = (GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]);

                                            }

                                        }

                                    }


                                    for (int q = 0; q < Teamid_array.Length / 2; q++)
                                    {
                                        Teamid_array[q, 1] = "0";
                                    }

                                }
                            }
                        }
                    }
                }
                string[,] auss = new string[2, 13];
                for (int x = 0; x < 13; x++)
                {
                    for (int y = 0; y < Ref_pl_team.Length / 2; y++)
                    {
                        if (best[0, x].ToString() == Ref_pl_team[y, 0])
                        {
                            auss[0, x] = best[0, x].ToString();
                            auss[1, x] = Ref_pl_team[y, 1];

                        }
                    }

                }
                auss[0, 11] = best[0, 11].ToString();
                auss[0, 12] = best[0, 12].ToString();
                auss[1, 11] = best[0, 11].ToString();
                auss[1, 12] = best[0, 12].ToString();

                label3.Text = best[0, 11].ToString();

                using (StreamWriter writer = new StreamWriter(@"C:\Users\gunde\Desktop\Gruppen2.csv"))
                {
                    for( int ii=0;ii<2;ii++)
                    {
                        writer.WriteLine(auss[ii, 0] + ";" + auss[ii, 1] + ";" + auss[ii, 2] + ";" + auss[ii, 3] + ";" + auss[ii, 4] + ";" + auss[ii, 5] + ";" + auss[ii, 6] + ";" + auss[ii, 7] + ";" + auss[ii, 8] + ";" + auss[ii, 9] + ";" + auss[ii, 10] + ";" + auss[ii, 11] + ";" + auss[ii, 12]);

                    }
                    
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Users\gunde\Desktop\Gruppen.csv"))
                {
                    for (int ii = 0; ii < Spiele.Length/2; ii++)
                    {
                        writer.WriteLine(Spiele[ii, 0] + ";" + Spiele[ii, 1]);

                    }

                }
            }
        }
    }
}



            

            /*
            //Var.1 1GK 4DEF 4MID 2FOR
            double[,] best = new double[1, 13];
            for (int i = 0; i < 13; i++)
            {
                best[0, i] = 0.0;
            }
            for (int i = 0; i < GK111.Length / 3; i++)
            {
                for (int j = 0; j < DEF444.Length / 6; j++)
                {
                    for (int l = 0; l < MID444.Length / 6; l++)
                    {
                        for (int m = 0; m < FOR222.Length / 4; m++)
                        {   //Projections Gesamt prüfen.
                            if ((GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3]) > best[0, 11])
                            {
                                best[0, 0] = GK111[i, 0];
                                best[0, 1] = DEF444[j, 0];
                                best[0, 2] = DEF444[j, 1];
                                best[0, 3] = DEF444[j, 2];
                                best[0, 4] = DEF444[j, 3];
                                best[0, 5] = MID444[l, 0];
                                best[0, 6] = MID444[l, 1];
                                best[0, 7] = MID444[l, 2];
                                best[0, 8] = MID444[l, 3];
                                best[0, 9] = FOR222[m, 0];
                                best[0, 10] = FOR222[m, 1];
                                best[0, 11] = (GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3]);
                                best[0, 12] = (GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]);
                                /*
                                //Preis Prüfen <100Millionen                           
                                if ((GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]) < 100)
                                {   //Spieler von Team<3
                                    for (int o = 0; o < Ref_pl_team.Length / 2; o++)
                                    {
                                        //GK
                                        if (GK111[i, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF1
                                        if (DEF444[j, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF2
                                        if (DEF444[j, 1].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF3
                                        if (DEF444[j, 2].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //DEF4
                                        if (DEF444[j, 3].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID1
                                        if (MID444[l, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID2
                                        if (MID444[l, 1].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID3
                                        if (MID444[l, 2].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //MID4
                                        if (MID444[l, 3].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //FOR1
                                        if (FOR222[m, 0].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                        //FOR2
                                        if (FOR222[m, 2].ToString() == Ref_pl_team[o, 0])
                                        {
                                            for (int p = 0; p < Teamid_array.Length / 2; p++)
                                            {
                                                if (Ref_pl_team[o, 1] == Teamid_array[p, 0])
                                                {
                                                    int x = 0;
                                                    Int32.TryParse(Teamid_array[p, 1], out x);
                                                    x = x + 1;
                                                    Teamid_array[p, 1] = x.ToString();
                                                }
                                            }
                                        }
                                    }
                                    best[0, 0] = GK111[i, 0];
                                    best[0, 1] = DEF444[j, 0];
                                    best[0, 2] = DEF444[j, 1];
                                    best[0, 3] = DEF444[j, 2];
                                    best[0, 4] = DEF444[j, 3];
                                    best[0, 5] = MID444[l, 0];
                                    best[0, 6] = MID444[l, 1];
                                    best[0, 7] = MID444[l, 2];
                                    best[0, 8] = MID444[l, 3];
                                    best[0, 9] = FOR222[m, 0];
                                    best[0, 10] = FOR222[m, 1];
                                    best[0, 11] = (GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3]);
                                    best[0, 12] = (GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]);
                                    /*
                                    for (int p = 0; p < Teamid_array.Length / 2; p++)
                                    {

                                        /*
                                        //M&S gegen DEF,G
                                        if ((GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3])-abzug_ges > best[0, 11])
                                        {
                                            

                                        if (ll == 0)
                                            {
                                                best[0, 0] = GK111[i, 0];
                                                best[0, 1] = DEF444[j, 0];
                                                best[0, 2] = DEF444[j, 1];
                                                best[0, 3] = DEF444[j, 2];
                                                best[0, 4] = DEF444[j, 3];
                                                best[0, 5] = MID444[l, 0];
                                                best[0, 6] = MID444[l, 1];
                                                best[0, 7] = MID444[l, 2];
                                                best[0, 8] = MID444[l, 3];
                                                best[0, 9] = FOR222[m, 0];
                                                best[0, 10] = FOR222[m, 1];
                                                best[0, 11] = (GK111[i, 2] + DEF444[j, 5] + MID444[l, 5] + FOR222[m, 3] - abzug_ges);
                                                best[0, 12] = (GK111[i, 1] + DEF444[j, 4] + MID444[l, 4] + FOR222[m, 2]);

                                            }
                                            

                            }




                                }

                                for (int q = 0; q < Teamid_array.Length / 2; q++)
                                {
                                    Teamid_array[q, 1] = "0";
                                }
                                
                            }
                        }
                    }
                }
            }
                
            
        
    


   


            
            using (StreamWriter writer = new StreamWriter(@"C:\Users\gunde\Desktop\Gruppen.csv"))
            {
                for (int l = 0; l < 1; l++)
                {
                   // writer.WriteLine(GK111[0, 2]+DEF444[1,5]+MID444[1,5]+FOR222[1,3]);
                   
                    writer.WriteLine(best[l,0]+ ";"+ best[l, 1] + ";" + best[l, 2] + ";" + best[l, 3] + ";" + best[l, 4] + ";" + best[l, 5] + ";" + best[l, 6] + ";" + best[l, 7] + ";" + best[l, 8] + ";" + best[l, 9] + ";" + best[l, 10] + best[l,11] + ";" + best[l, 12]);
                }
            }

            label3.Text = "Fertig";

        }

        
    }
}
    */
