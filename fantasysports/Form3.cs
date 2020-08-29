using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;





namespace fantasysports
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            
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
            command.CommandText = "SELECT Wettbewerb FROM FanteamPreise";
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
            dbListe=dbListe.Distinct().ToList();
            for ( int i=0; i<dbListe.Count;i++)
            {
                Wettbewerb_combobox.Items.Add(dbListe[i]);
            }

            //db auslesen
            //liste Turnierform erzeugen

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Prüfen ob alle Einträge gemacht sind!!
            if(FanteamUrl_input.Text.Length==0)
            {
                status_lbl.Text = "URL eingeben";
                return;
            }
            if(AnzahlSeiten_input.Text.Length==0)
            {
                status_lbl.Text = "Anzahl Seiten eingeben";
                return;
            }
            if(TurnierID_eingabe.Text.Length==0)
            {
                status_lbl.Text = "TurnierID eingeben";
                return;
            }
            if(Wettbewerb_combobox.Text.Length==0)
            {
                status_lbl.Text = "Wettbewerb auswählen";
                return;
            }
            if(FanteamUrl_input.Text.Length != 0 && AnzahlSeiten_input.Text.Length != 0 && TurnierID_eingabe.Text.Length != 0 && Wettbewerb_combobox.Text.Length != 0)
            {
                //mysql tables string erzeugen
                string abcd = string.Format(@"CREATE TABLE IF NOT EXISTS `{0}` (
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
                command1.CommandText = "SELECT TurnierID FROM FanteamPreise";
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
                for(int i=0;i<dbListe1.Count();i++)
                {
                    if (dbListe1[i] == TurnierID_eingabe.Text)
                        abb = 1;
                }

                if (abb != 0)
                {
                    status_lbl.Text = "Turnier bereits in DB geladen.";
                    return;
                }
                    

                if(abb==0)
                {
                    //Spielerliste erzeugen
                    List<string> Spielerliste = new List<string>();

                    //Firefox öffnen
                    IWebDriver driver = new FirefoxDriver();

                    //URL öffnen
                    driver.Url = FanteamUrl_input.Text;

                    //10 sec warten
                    System.Threading.Thread.Sleep(10000);

                    //javaScript einbinden
                    IJavaScriptExecutor js = driver as IJavaScriptExecutor;

                    //Anzahl Seiten auslesen
                    int x = Int32.Parse(AnzahlSeiten_input.Text);

                    //Daten scrappen
                    for (int j = 0; j < x; j++)
                    {
                        //Tabelle in Webelement speichern
                        IWebElement table = (IWebElement)js.ExecuteScript("return document.querySelector('.ft-view-port').shadowRoot.querySelector('.not-safari').shadowRoot.querySelector('.choices')");

                        //Webelement in String speichern
                        string table_str = table.Text;

                        //String vereinzeln und in array speichern
                        string[] Spieler_ar = table_str.Split(new Char[] { '\n' });

                        //Spieler in Liste eintragen
                        for (int i = 5; i < Spieler_ar.Length; i++)
                        {
                            Spielerliste.Add(Spieler_ar[i]);
                        }

                        //nächste Seite
                        js.ExecuteScript("return document.querySelector('.ft-view-port').shadowRoot.querySelector('.not-safari').shadowRoot.querySelector('.game > aside:nth-child(1) > ft-loading:nth-child(4) > ft-pagination:nth-child(2)').shadowRoot.querySelector('button.pagination__arrow:nth-child(4)').click()");


                    }
                    driver.Close();

                    // Daten in SQL

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

                    //letzte db id auslesen
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM FanteamPreise";
                    MySqlDataReader Reader;
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

                        status_lbl.Text = row;
                    }
                    connection.Close();


                    //daten in db
                    connection.Open();
                    int h;
                    if (status_lbl.Text.Length == 0)
                    {
                        h = 1;
                    }
                    else
                        h = Int32.Parse(status_lbl.Text) + 1;

                    int k = 0;
                    string st2;
                    string st3;
                    string datum = System.DateTime.Now.ToShortDateString();
                    for (int i = 0; i < Spielerliste.Count / 7; i++)
                    {
                        cmd.CommandText = "INSERT INTO FanteamPreise(id, Spieler, Position, home, away, Form, Punkte, Preis, Spielerid, Wettbewerb, Datum, TurnierID) VALUES(@id, @Spieler, @Position, @home, @away, @Form, @Punkte, @Preis, @Spielerid, @Wettbewerb, @Datum, @TurnierID)";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@id", h + i);
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@Position", st3);
                        k = k + 1;
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@Spieler", st3);
                        k = k + 1;
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@home", st3);
                        k = k + 1;
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@away", st3);
                        k = k + 1;
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@Form", st3);
                        k = k + 1;
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@Punkte", st3);
                        k = k + 1;
                        st2 = Spielerliste[k];
                        st3 = st2.Trim();
                        cmd.Parameters.AddWithValue("@Preis", st3);
                        k = k + 1;
                        cmd.Parameters.AddWithValue("@Spielerid", k);
                        cmd.Parameters.AddWithValue("@Wettbewerb", Wettbewerb_combobox.Text);
                        cmd.Parameters.AddWithValue("@Datum", datum);
                        cmd.Parameters.AddWithValue("@TurnierID", TurnierID_eingabe.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    connection.Close();
                    status_lbl.Text = "finished!";

                }

            }


                   
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {           

            if (textBox1.Text.Length != 0)
                Wettbewerb_combobox.Items.Add(textBox1.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
