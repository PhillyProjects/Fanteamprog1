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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mysql tables string erzeugen
            string createTableQuery = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
            `id` int(5) unsigned NOT NULL AUTO_INCREMENT,
            `Wettbewerb` VARCHAR(50) NOT NULL,
            `Spieler` VARCHAR(50) NOT NULL,
            `Position` VARCHAR(50) NOT NULL,
            `home` VARCHAR(50) NOT NULL,
            `away` VARCHAR(50) NOT NULL,
            `Form` VARCHAR(50) NOT NULL,
            `Punkte` VARCHAR(50) NOT NULL,
            `Preis` VARCHAR(50) NOT NULL,
            `Spielerid` smallint(5) unsigned NOT NULL DEFAULT '0',
            `Datum` VARCHAR(50) NOT NULL,
            `TurnierID` VARCHAR(50) NOT NULL,
            PRIMARY KEY (`id`),
            KEY `Spielerid` (`Spielerid`)) 
            ENGINE = MyISAM AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;", "FanteamPreise");

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
                    dbListe.Add(row);
                }
            }

            dbListe = dbListe.Distinct().ToList();

            using (StreamWriter writer = new StreamWriter(@"C:\Users\gunde\Desktop\Gruppenmitglieder.csv"))
            {
                for (int l = 0; l < dbListe.Count; l++)
                {
                    writer.WriteLine((dbListe[l]));
                }
            }

        }
    }
}
