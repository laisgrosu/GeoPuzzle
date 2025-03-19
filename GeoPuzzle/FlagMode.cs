using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoPuzzle
{
    public partial class FlagMode : Form
    {
        public FlagMode()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelFlag_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonStartFlag_Click(object sender, EventArgs e)
        {
            Random MyNO=new Random();
            int maxim = 6;
            int numNO= MyNO.Next(1,maxim);
            lblCNo.Text = numNO.ToString();
    
            if(numNO == 1)
            {
                buttonStartFlag.Enabled = false;
                pictureBox1.Image = Properties.Resources.brazil_flag;
                pictureBox2.Image = Properties.Resources.portugal_flag;
                pictureBox3.Image = Properties.Resources.japonia_flag;
                pictureBox4.Image = Properties.Resources.franta_flag;
                pictureBox5.Image = Properties.Resources.india_flag;
                pictureBox6.Image = Properties.Resources.cehia_flag;
                tb1flag.Enabled = true;
                btnSubmit.Enabled = true;

            }
            if (numNO == 2)
            {
                buttonStartFlag.Enabled = false;
                pictureBox1.Image = Properties.Resources.plonia_flag;
                pictureBox2.Image = Properties.Resources.romania_flag;
                pictureBox3.Image = Properties.Resources.uk_flag;
                pictureBox4.Image = Properties.Resources.turcia_flag;
                pictureBox5.Image = Properties.Resources.tailanda_flag;
                pictureBox6.Image = Properties.Resources.sua_flag;
                tb1flag.Enabled = true;
                btnSubmit.Enabled = true;

            }
            if (numNO == 3)
            {
                buttonStartFlag.Enabled = false;
                pictureBox1.Image = Properties.Resources.uruguay_flag_flag;
                pictureBox2.Image = Properties.Resources.venezuela_flag;
                pictureBox3.Image = Properties.Resources.south_coreea_flag;
                pictureBox4.Image = Properties.Resources.olanda_flag;
                pictureBox5.Image = Properties.Resources.filipine_flag;
                pictureBox6.Image = Properties.Resources.dameraca_flag;
                tb1flag.Enabled = true;
                btnSubmit.Enabled = true;

            }
            if (numNO == 4)
            {
                buttonStartFlag.Enabled = false;
                pictureBox1.Image = Properties.Resources.madagascar_flag;
                pictureBox2.Image = Properties.Resources.mongolia_flag;
                pictureBox3.Image = Properties.Resources.puerto_rico_flag_pnh;
                pictureBox4.Image = Properties.Resources.zambia_flag;
                pictureBox5.Image = Properties.Resources.uganda_flag;
                pictureBox6.Image = Properties.Resources.south_africa_flag;
                tb1flag.Enabled = true;
                btnSubmit.Enabled = true;

            }
            if (numNO == 5)
            {
                buttonStartFlag.Enabled = false;
                pictureBox1.Image = Properties.Resources.belarsu_flag;
                pictureBox2.Image = Properties.Resources.canada_flag;
                pictureBox3.Image = Properties.Resources.costa_rica_flag;
                pictureBox4.Image = Properties.Resources.chile_flag;
                pictureBox5.Image = Properties.Resources.china_flag;
                pictureBox6.Image = Properties.Resources.sudan_flag;
                tb1flag.Enabled = true;
                btnSubmit.Enabled = true;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonBackFlag_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(); // Creezi o nouă instanță a meniului
            menu.Show(); // Afișezi meniul
            this.Close(); // Închizi formularul curent (FlagMode)
}
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((lblCNo.Text == "1") && (tb1flag.Text == "Brazilia") && (tb2flag.Text == "Portugalia") && (tb3flag.Text == "Japonia") && (tb4flag.Text == "Franta")|| (tb4flag.Text == "Franța") && (tb5flag.Text == "India") && (tb6flag.Text == "Cehia"))
            {
                buttonStartFlag.Enabled = true;
                btnSubmit.Enabled = false;
                lblCNo.Text = "0";
                tb1flag.Enabled = false;
                MessageBox.Show("Felicitari!");
            }
            else if ((lblCNo.Text == "2") && (tb1flag.Text == "Polonia") && (tb2flag.Text == "Romania") && (tb3flag.Text == "Regatul Unit")||(tb3flag.Text == "Marea Britanie") && (tb4flag.Text == "Turcia") && (tb5flag.Text == "Thailanda") && (tb6flag.Text == "America")||(tb6flag.Text == "Statele Unite ale Americii")||(tb6flag.Text == "SUA"))
            {
                buttonStartFlag.Enabled = true;
                btnSubmit.Enabled = false;
                lblCNo.Text = "0";
                tb1flag.Enabled = false;
                MessageBox.Show("Felicitari!");
            }
            else if ((lblCNo.Text == "3") && (tb1flag.Text == "Uruguay") && (tb2flag.Text == "Venezuela") && (tb3flag.Text == "Coreea de Sud") && (tb4flag.Text == "Olanda") && (tb5flag.Text == "Filipine") && (tb6flag.Text == "Danemarca"))
            {
                buttonStartFlag.Enabled = true;
                btnSubmit.Enabled = false;
                lblCNo.Text = "0";
                tb1flag.Enabled = false;
                MessageBox.Show("Felicitari!");
            }
            else if ((lblCNo.Text == "4") && (tb1flag.Text == "Madagascar") && (tb2flag.Text == "Mongolia") && (tb3flag.Text == "Puerto Rico") && (tb4flag.Text == "Zambia") && (tb5flag.Text == "Uganda") && (tb6flag.Text == "Africa de Sud"))
            {
                buttonStartFlag.Enabled = true;
                btnSubmit.Enabled = false;
                lblCNo.Text = "0";
                tb1flag.Enabled = false;
                MessageBox.Show("Felicitari!");
            }
            else if ((lblCNo.Text == "5") && (tb1flag.Text == "Belarus") && (tb2flag.Text == "Canada") && (tb3flag.Text == "Costa Rica") && (tb4flag.Text == "Chile") && (tb5flag.Text == "China") && (tb6flag.Text == "Sudan"))
            {
                buttonStartFlag.Enabled = true;
                btnSubmit.Enabled = false;
                lblCNo.Text = "0";
                tb1flag.Enabled = false;
                MessageBox.Show("Felicitari!");
            }
            else
            {
                MessageBox.Show("Încearcă din nou!");
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
