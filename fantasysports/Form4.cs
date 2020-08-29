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
using MySql.Data.MySqlClient;

namespace fantasysports
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (Wettbewerb_combobox.Text.Length == 0)
            {
                label2.Text = "Wettbewerb auswählen";
                return;
            }
            //mysql tables string erzeugen
            string abcd = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
            `id` int(5) unsigned NOT NULL AUTO_INCREMENT,
            `Spieler` VARCHAR(50) NOT NULL,
            `Team` VARCHAR(50) NOT NULL,
            `Opp` VARCHAR(50) NOT NULL,
            `Pos` VARCHAR(50) NOT NULL,
            `Min` VARCHAR(50) NOT NULL,
            `G` VARCHAR(50) NOT NULL,
            `A` VARCHAR(50) NOT NULL,
            `S` VARCHAR(50) NOT NULL,
            `SOG` VARCHAR(50) NOT NULL,
            `CC` VARCHAR(50) NOT NULL,
            `P` VARCHAR(50) NOT NULL,
            `AP` VARCHAR(50) NOT NULL,
            `CR` VARCHAR(50) NOT NULL,
            `ACR` VARCHAR(50) NOT NULL,
            `AW` VARCHAR(50) NOT NULL,
            `DR` VARCHAR(50) NOT NULL,
            `DSP` VARCHAR(50) NOT NULL,
            `INTT` VARCHAR(50) NOT NULL,
            `TKL` VARCHAR(50) NOT NULL,
            `TKLW` VARCHAR(50) NOT NULL,
            `BLK` VARCHAR(50) NOT NULL,
            `CL` VARCHAR(50) NOT NULL,
            `CS` VARCHAR(50) NOT NULL,
            `GC` VARCHAR(50) NOT NULL,
            `SV` VARCHAR(50) NOT NULL,
            `FS` VARCHAR(50) NOT NULL,
            `FC` VARCHAR(50) NOT NULL,
            `Y` VARCHAR(50) NOT NULL,
            `R` VARCHAR(50) NOT NULL,
            `Wettbewerb` VARCHAR(50) NOT NULL,
            `Spielerid` smallint(5) unsigned NOT NULL DEFAULT '0',
            `Datum` VARCHAR(50) NOT NULL,
            PRIMARY KEY (`id`),
            KEY `Spielerid` (`Spielerid`)) 
            ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "Rotowire");

            //mysql connection erzeugen
            MySqlConnection con = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            con.Open();

            //mysql DB erzeugen
            var cmda = new MySql.Data.MySqlClient.MySqlCommand(abcd, con);
            cmda.ExecuteNonQuery();
            con.Close();

            //db auslesen
            //liste Datum erzeugen
            string datum2 = System.DateTime.Now.ToShortDateString();

            List<string> dbListe1 = new List<string>();
            MySqlCommand command1 = con.CreateCommand();
            command1.CommandText = "SELECT Wettbewerb FROM Rotowire WHERE Datum = '"+datum2+"'";
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
            dbListe1 = dbListe1.Distinct().ToList();
            con.Close();



            





            //CSV in Array speichern
            string whole_file;
            string link = String.Join(",", listBox1.Items.OfType<Object>().Select(i => i.ToString()).ToArray());
            whole_file = System.IO.File.ReadAllText(@link);
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;
            string[,] Tabelle = new string[num_rows, 10];

            string[,] values = new string[num_rows, num_cols];
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }


            //MYSQL Table erzeugen und Connection erstellen

            //mysql tables string erzeugen
            string createTableQuery = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
            `id` int(5) unsigned NOT NULL AUTO_INCREMENT,
            `Spieler` VARCHAR(50) NOT NULL,
            `Team` VARCHAR(50) NOT NULL,
            `Opp` VARCHAR(50) NOT NULL,
            `Pos` VARCHAR(50) NOT NULL,
            `Min` VARCHAR(50) NOT NULL,
            `G` VARCHAR(50) NOT NULL,
            `A` VARCHAR(50) NOT NULL,
            `S` VARCHAR(50) NOT NULL,
            `SOG` VARCHAR(50) NOT NULL,
            `CC` VARCHAR(50) NOT NULL,
            `P` VARCHAR(50) NOT NULL,
            `AP` VARCHAR(50) NOT NULL,
            `CR` VARCHAR(50) NOT NULL,
            `ACR` VARCHAR(50) NOT NULL,
            `AW` VARCHAR(50) NOT NULL,
            `DR` VARCHAR(50) NOT NULL,
            `DSP` VARCHAR(50) NOT NULL,
            `INTT` VARCHAR(50) NOT NULL,
            `TKL` VARCHAR(50) NOT NULL,
            `TKLW` VARCHAR(50) NOT NULL,
            `BLK` VARCHAR(50) NOT NULL,
            `CL` VARCHAR(50) NOT NULL,
            `CS` VARCHAR(50) NOT NULL,
            `GC` VARCHAR(50) NOT NULL,
            `SV` VARCHAR(50) NOT NULL,
            `FS` VARCHAR(50) NOT NULL,
            `FC` VARCHAR(50) NOT NULL,
            `Y` VARCHAR(50) NOT NULL,
            `R` VARCHAR(50) NOT NULL,
            `Wettbewerb` VARCHAR(50) NOT NULL,
            `Spielerid` smallint(5) unsigned NOT NULL DEFAULT '0',
            `Datum` VARCHAR(50) NOT NULL,
            PRIMARY KEY (`id`),
            KEY `Spielerid` (`Spielerid`)) 
            ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "Rotowire");

            //mysql connection erzeugen
            MySqlConnection connection = new MySqlConnection("server=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;database=bddiyuk2rbzdbj9pfb9r;uid=uxayl6sbtpqdhepa;password=QZPnMNX6OIJrkYTkes3F");
            connection.Open();

            //mysql DB erzeugen
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(createTableQuery, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            //letzte db id auslesen
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Rotowire";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            label2.Text = "";
            while (Reader.Read())
            {
                string row = "";
                //Komplette dB auslesen
                //for (int i = 0; i < Reader.FieldCount; i++)

                //letzte id auslesen
                for (int i = 0; i < 1; i++)
                    row += Reader.GetValue(i).ToString();

                label2.Text = row;
            }
            connection.Close();

            //daten in db
            connection.Open();
            int h;
            if (label2.Text.Length == 0)
            {
                h = 1;
            }
            else
                h = Int32.Parse(label2.Text) + 1;

            int k;
            string st2;
            string st3;
            string datum = System.DateTime.Now.ToShortDateString();
            for (int i = 2; i < num_rows; i++)
            {
                k = 0;
                cmd.CommandText = "INSERT INTO Rotowire(id, Spieler, Team, Opp, Pos, Min, G, A, S, SOG, CC, P, AP, CR, ACR, AW, DR, DSP, INTT, TKL, TKLW, BLK, CL, CS, GC, SV, FS, FC, Y, R, Wettbewerb, Spielerid, Datum) VALUES(@id, @Spieler, @Team, @Opp, @Pos, @Min, @G, @A, @S, @SOG, @CC, @P, @AP, @CR, @ACR, @AW, @DR, @DSP, @INTT, @TKL, @TKLW, @BLK, @CL, @CS, @GC, @SV, @FS, @FC, @Y, @R, @Wettbewerb, @Spielerid, @Datum)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", h + i);
                st2 = values[i,k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Spieler", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Team", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Opp", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Pos", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Min", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@G", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@A", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@S", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@SOG", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@CC", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@P", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@AP", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@CR", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@ACR", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@AW", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@DR", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@DSP", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@INTT", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@TKL", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@TKLW", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@BLK", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@CL", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@CS", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@GC", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@SV", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@FS", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@FC", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@Y", st3);
                k = k + 1;
                st2 = values[i, k];
                st3 = st2.Trim();
                cmd.Parameters.AddWithValue("@R", st3);
                cmd.Parameters.AddWithValue("@Spielerid", k);
                cmd.Parameters.AddWithValue("@Wettbewerb", Wettbewerb_combobox.Text);
                cmd.Parameters.AddWithValue("@Datum", datum);                
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            connection.Close();


            label2.Text = "Finish";



        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                listBox1.Items.Add(file);
            }
                
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false)==true)
            {
                e.Effect = DragDropEffects.All;
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
