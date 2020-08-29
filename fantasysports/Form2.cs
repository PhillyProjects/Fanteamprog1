using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace fantasysports
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnectionString = "SERVER=bddiyuk2rbzdbj9pfb9r-mysql.services.clever-cloud.com;" +
                            "DATABASE=bddiyuk2rbzdbj9pfb9r;" +
                            "UID=uxayl6sbtpqdhepa;" +
                            "PASSWORD=QZPnMNX6OIJrkYTkes3F;";

            MySqlConnection connection = new MySqlConnection(myConnectionString);
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM FanteamPreise";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                string row = "";
                //for (int i = 0; i < Reader.FieldCount; i++)
                for (int i=0;i<1;i++)
                    row += Reader.GetValue(i).ToString();
                //Console.WriteLine(row);
                label8.Text = row;
            }
            connection.Close();
        }
    }
}
