using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fantasysports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Directory.CreateDirectory(@"C:\FantasySports\Fanteam_Teams");
            Directory.CreateDirectory(@"C:\FantasySports\Python_Scripts");
            Directory.CreateDirectory(@"C:\FantasySports\Referenztabelle");
        }

        private void analyse_btn_Click(object sender, EventArgs e)
        {
            Form2 Analyse_Fenster = new Form2();
            Analyse_Fenster.Show();
           
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Scrapp_Fenster = new Form3();
            Scrapp_Fenster.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.Show();
        }

        private void Pythonscript_Click(object sender, EventArgs e)
        {

        }



        private void referenz_btn_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form8 Form8 = new Form8();
            Form8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //mysql connection erzeugen
            MySqlConnection connection = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            connection.Open();

            //letzte db id auslesen

            List<string> dblist2 = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Referenz";
            MySqlDataReader Reader;
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
            int k = 0;
            string[,] aa = new string[dblist2.Count() / 7, 7];
            for ( int i=0; i<dblist2.Count()/7;i++)
            {
                for (int j=0; j<7;j++)
                {
                    aa[i, j] = dblist2[k];
                    k++;
                }
            }

            using (StreamWriter writer = new StreamWriter(@"C:\FantasySports\Referenztabelle\PPPP.csv"))
            {
                for (int i = 0; i < aa.Length / 7; i++)
                {
                    writer.WriteLine(aa[i, 0] + ";" + aa[i, 1] + ";" + aa[i, 2] + ";" + aa[i, 3] + ";" + aa[i, 4] + ";" + aa[i, 5] + ";" + aa[i, 6]);
                }
            }

        }
    }
}
