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
    }
}
