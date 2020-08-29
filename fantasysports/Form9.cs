using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fantasysports
{
    public partial class Form9 : Form
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









        public Form9()
        {
            InitializeComponent();
        }









        private void button1_Click(object sender, EventArgs e)
        {
        }
    }


}
