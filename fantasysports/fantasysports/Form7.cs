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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listBox1_DragDrop_1(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                listBox1.Items.Add(file);
            }

        }

        private void listBox1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mysql tables string erzeugen
            string createTableQuery = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
            `id` int(5) unsigned NOT NULL AUTO_INCREMENT,
            `Fanteam` VARCHAR(50) NOT NULL,
            `Rotowire` VARCHAR(50) NOT NULL,
            `TeamR` VARCHAR(50) NOT NULL, 
            `TeamF` VARCHAR(50) NOT NULL,
            `Spielerid` smallint(5) unsigned NOT NULL DEFAULT '0',
            `Datum` VARCHAR(50) NOT NULL,
            PRIMARY KEY (`id`),
            KEY `Spielerid` (`Spielerid`)) 
            ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "Referenz");

            //mysql connection erzeugen
            MySqlConnection connection = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            connection.Open();

            //mysql DB erzeugen
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(createTableQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            //db auslesen
            //liste Wettbewerb erzeugen
            List<string> dbListe = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Fanteam FROM Referenz";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString();
                    dbListe.Add(row);
                }
            }
            connection.Close();

            //db auslesen
            //liste Wettbewerb erzeugen
            List<string> dbListe2 = new List<string>();
            command = connection.CreateCommand();
            command.CommandText = "SELECT TeamR FROM Referenz";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString();
                    dbListe2.Add(row);
                }
            }
            connection.Close();

            
            //CSV in Array speichern
            string whole_file;
            string link = String.Join(",", listBox1.Items.OfType<Object>().Select(i => i.ToString()).ToArray());
            if (link=="")
            {
                info_lbl.Text = "Bitte CSV einfügen!!";
                return;
            }
               
            whole_file = System.IO.File.ReadAllText(@link);
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            int num_rows = lines.Length;
            int num_cols = lines[0].Split(';').Length;
            string[,] Tabelle = new string[num_rows, 10];

            string[,] values = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }


            //db mit csv Prüfen, nur einträge hinzufügen, welche noch nicht vorhanden sind
            List<string> newlistSpieler = new List<string>();
            List<string> newllistTeam = new List<string>();
            List<string> newlistSpieler1 = new List<string>();
            List<string> newllistTeam1 = new List<string>();
            for (int i = 0; i < num_rows; i++)
            {
                newlistSpieler.Add(values[i, 0]);
                newllistTeam.Add(values[i, 2]);
                newlistSpieler1.Add(values[i, 0]);
                newllistTeam1.Add(values[i, 2]);
            }

            for (int i = 0; i < newlistSpieler.Count(); i++)
            {
                for (int j = 0; j < dbListe.Count(); j++)
                {
                    if (newlistSpieler[i] == dbListe[j] && newllistTeam[i] == dbListe2[j])
                    {
                        newlistSpieler1.Remove(newlistSpieler[i]);
                        newllistTeam1.Remove(newllistTeam[i]);
                    }
                }
            }

            List<string> newlistSpieler2 = new List<string>();
            for (int i = 0; i < newlistSpieler1.Count(); i++)
            {
                for(int j=0; j<num_rows;j++)
                {
                    if (newlistSpieler1[i] == values[j, 0] && newllistTeam1[i] == values[j, 2])
                    {
                        newlistSpieler2.Add(values[j, 0]);
                        newlistSpieler2.Add(values[j, 1]);
                        newlistSpieler2.Add(values[j, 2]);
                        newlistSpieler2.Add(values[j, 3]);
                    }
                }
                

            }

        
            

            //letzte db id auslesen
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Referenz";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                //Komplette dB auslesen
                //for (int i = 0; i < Reader.FieldCount; i++)

                //letzte id auslesen
                for (int i = 0; i < 1; i++)
                    row += Reader.GetValue(i).ToString();

                info_lbl.Text = row;
            }
            connection.Close();


            //daten in db
            connection.Open();
            int h;
            if (info_lbl.Text.Length == 0)
            {
                h = 1;
            }
            else
                h = Int32.Parse(info_lbl.Text) + 1;

            string st2;
            string st3;
            int k = 0;
            string datum = System.DateTime.Now.ToShortDateString();
            for (int i = 0; i < newlistSpieler2.Count()/4; i++)
            {
                cmd.CommandText = "INSERT INTO Referenz(id, Fanteam, Rotowire, TeamR, TeamF, Spielerid, Datum) VALUES(@id, @Fanteam, @Rotowire, @TeamR, @TeamF, @Spielerid, @Datum)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", h + i);
                st2 = newlistSpieler2[k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Fanteam", st3);
                k = k + 1;
                st2 = newlistSpieler2[k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Rotowire", st3);
                k = k + 1;
                st2 = newlistSpieler2[k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@TeamR", st3);
                k = k + 1;
                st2 = newlistSpieler2[k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@TeamF", st3);
                k = k + 1;
                cmd.Parameters.AddWithValue("@Spielerid", h+i);
                cmd.Parameters.AddWithValue("@Datum", datum);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            connection.Close();


             info_lbl.Text = "finish!";
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //mysql tables string erzeugen
            string createTableQuery = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
            `id` int(5) unsigned NOT NULL AUTO_INCREMENT,
            `Fanteam` VARCHAR(50) NOT NULL,
            `Rotowire` VARCHAR(50) NOT NULL,
            `TeamR` VARCHAR(50) NOT NULL, 
            `TeamF` VARCHAR(50) NOT NULL,
            `Spielerid` smallint(5) unsigned NOT NULL DEFAULT '0',
            `Datum` VARCHAR(50) NOT NULL,
            PRIMARY KEY (`id`),
            KEY `Spielerid` (`Spielerid`)) 
            ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "Referenz");

            //mysql connection erzeugen
            MySqlConnection connection = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            connection.Open();

            //mysql DB erzeugen
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(createTableQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();


            //db auslesen
            //Spielerliste Fanteam erzeugen
            List<string> SpielerFanteam = new List<string>();
            List<string> SpielerFanteam1 = new List<string>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Spieler FROM FanteamPreise";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString();
                    SpielerFanteam.Add(row);
                    SpielerFanteam1.Add(row);
                }
            }

            SpielerFanteam = SpielerFanteam.Distinct().ToList();
            SpielerFanteam1 = SpielerFanteam1.Distinct().ToList();

            //array für ausgabe erzeugen und Spieler fanteam hinzufügen
            string[,] array = new string[SpielerFanteam.Count(),3];

            for(int i=0;i<SpielerFanteam.Count();i++)
            {
                array[i, 0] = SpielerFanteam[i];
            }

            connection.Close();

            //db auslesen
            //heim und auswärts auslesen
            List<string> All = new List<string>();
            List<string> All1 = new List<string>();
            command.CommandText = "SELECT * FROM FanteamPreise";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row = Reader.GetValue(i).ToString();
                    All.Add(row);
                    All1.Add(row);

                }
            }
            connection.Close();

            for (int i=0;i<SpielerFanteam.Count();i++)
            {
                for (int j=0; j<All.Count();j++)
                {
                    if(array[i,0]==All[j])
                    {
                        array[i, 1] = All[j + 2];
                        array[i, 2] = All[j + 3];
                        break;
                    }
                }
            }

            //db auslesen
            //Referenzliste auslesen
            List<string> Referenz = new List<string>();

            command.CommandText = "SELECT * FROM Referenz";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row = Reader.GetValue(i).ToString();
                    Referenz.Add(row);
                    
                }
            }
            connection.Close();

            for (int i=0; i<SpielerFanteam.Count();i++)
            {
                for (int j=0; j<Referenz.Count()-3; j++)
                {
                    if(array[i,0]==Referenz[j]&&array[i,1]==Referenz[j+3]|| array[i, 0] == Referenz[j] && array[i, 2] == Referenz[j + 3])
                    {
                        array[i, 0] = "";
                        array[i, 1] = "";
                        array[i, 2] = "";

                    }
                }
            }
            


            List<string> neu = new List<string>();

            for (int i=0; i< SpielerFanteam.Count();i++)
            {
                if(array[i,0]!="")
                {
                    neu.Add(array[i, 0]);
                    neu.Add(array[i, 1]);
                    neu.Add(array[i, 2]);

                }
            }

            string[,] array2 = new string[neu.Count(), 3];
            int k = 0;

            for (int i = 0; i < neu.Count()/3; i++)
            {
                for(int j=0;j<3;j++)
                {
                    array2[i, j] = neu[k];
                    k++;

                }

            }

            /*
            //db auslesen
            //liste Wettbewerb erzeugen
            List<string> AuswärtsFanteam = new List<string>();
            List<string> AuswärtsFanteam1 = new List<string>();
            command.CommandText = "SELECT away FROM FanteamPreise";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString();
                    AuswärtsFanteam.Add(row);
                    AuswärtsFanteam1.Add(row);
                }
            }
            connection.Close();

            //db auslesen
            //liste Wettbewerb erzeugen
            List<string> NameReferenzFanteam = new List<string>();
            List<string> NameReferenzFanteam1 = new List<string>();
            command.CommandText = "SELECT Fanteam FROM Referenz";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString();
                    NameReferenzFanteam.Add(row);
                    NameReferenzFanteam1.Add(row);
                }
            }
            connection.Close();

            //db auslesen
            //liste Wettbewerb erzeugen
            List<string> TeamReferenzFanteam = new List<string>();
            List<string> TeamReferenzFanteam1 = new List<string>();
            command.CommandText = "SELECT TeamF FROM Referenz";
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    row += Reader.GetValue(i).ToString();
                    TeamReferenzFanteam.Add(row);
                    TeamReferenzFanteam1.Add(row);
                }
            }
            connection.Close();
            

            for (int i=0;i<TeamReferenzFanteam.Count();i++)
            {
                for(int j=0; j<AuswärtsFanteam.Count();j++)
                {
                    if((SpielerFanteam[j]==NameReferenzFanteam[i] && TeamReferenzFanteam[i]== HeimFanteam[j])|| (SpielerFanteam[j] == NameReferenzFanteam[i] && TeamReferenzFanteam[i] == AuswärtsFanteam[j]))
                    {
                        SpielerFanteam1.Remove(SpielerFanteam[j]);
                        HeimFanteam1.Remove(HeimFanteam[j]);
                        AuswärtsFanteam1.Remove(AuswärtsFanteam[j]);

                    }

                }
            }
            */
            using (StreamWriter writer = new StreamWriter(@"C:\FantasySports\Referenztabelle\Referenz.csv"))
            {
                for (int l = 0; l < neu.Count()/3; l++)
                {
                    writer.WriteLine(array2[l,0]+";"+ array2[l,1]+";"+ array2[l,2]);
                }
            }

            info_lbl.Text = "Fertig";

        }
    }


}


  
 
