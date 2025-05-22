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
        private Dictionary<Control, Rectangle> originalBounds = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;
        private Size originalPanelSize;
        private float baseFontSize = 12f; // ajustează după fontul inițial

        public FlagMode()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Load += FlagMode_Load;
            this.Resize += FlagMode_Resize;
        }

        private void FlagMode_Load(object sender, EventArgs e)
        {
            // presupun că ai un panel numit panelFlag unde ai toate controalele
            originalFormSize = this.ClientSize;
            originalPanelSize = panelFlag.Size;

            foreach (Control ctrl in panelFlag.Controls)
            {
                originalBounds[ctrl] = ctrl.Bounds;
            }
        }

        private void FlagMode_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;
            float scaleRatio = Math.Min(xRatio, yRatio);

            int newPanelWidth = (int)(originalPanelSize.Width * xRatio);
            int newPanelHeight = (int)(originalPanelSize.Height * yRatio);
            panelFlag.Size = new Size(newPanelWidth, newPanelHeight);

            panelFlag.Location = new Point(
                (this.ClientSize.Width - panelFlag.Width) / 2,
                (this.ClientSize.Height - panelFlag.Height) / 2
            );

            foreach (Control ctrl in panelFlag.Controls)
            {
                Rectangle original = originalBounds[ctrl];
                int newX = (int)(original.X * xRatio);
                int newY = (int)(original.Y * yRatio);
                int newWidth = (int)(original.Width * xRatio);
                int newHeight = (int)(original.Height * yRatio);

                ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);

                // scalează fontul
                float newFontSize = baseFontSize * scaleRatio;
                if (newFontSize < 8f) newFontSize = 8f;
                ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
            }

            labelFlag.Left = (panelFlag.Width - labelFlag.Width) / 2;
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
        private Queue<List<Image>> lastRoundsFlags = new Queue<List<Image>>();
        private int roundsMemory = 3;

        private void buttonStartFlag_Click(object sender, EventArgs e)
        {
            // Golim casetele
            foreach (Control ctrl in panelFlag.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
            }

            Random rnd = new Random();

            // Toate steagurile
            List<Image> allFlags = new List<Image>()
    {
        Properties.Resources.brazil_flag,
        Properties.Resources.portugal_flag,
        Properties.Resources.japonia_flag,
        Properties.Resources.franta_flag,
        Properties.Resources.india_flag,
        Properties.Resources.cehia_flag,
        Properties.Resources.plonia_flag,
        Properties.Resources.romania_flag,
        Properties.Resources.uk_flag,
        Properties.Resources.turcia_flag,
        Properties.Resources.tailanda_flag,
        Properties.Resources.sua_flag,
        Properties.Resources.uruguay_flag_flag,
        Properties.Resources.venezuela_flag,
        Properties.Resources.south_coreea_flag,
        Properties.Resources.olanda_flag,
        Properties.Resources.filipine_flag,
        Properties.Resources.dameraca_flag,
        Properties.Resources.madagascar_flag,
        Properties.Resources.mongolia_flag,
        Properties.Resources.puerto_rico_flag_pnh,
        Properties.Resources.zambia_flag,
        Properties.Resources.uganda_flag,
        Properties.Resources.south_africa_flag,
        Properties.Resources.belarsu_flag,
        Properties.Resources.canada_flag,
        Properties.Resources.costa_rica_flag,
        Properties.Resources.chile_flag,
        Properties.Resources.china_flag,
        Properties.Resources.sudan_flag
    };

            List<Image> flagsForRound = null;
            bool validSelection = false;

            while (!validSelection)
            {
                flagsForRound = allFlags.OrderBy(x => rnd.Next()).Take(6).ToList();

                // verificăm dacă steagurile alese nu se regăsesc în ultimele 3 runde
                validSelection = true;

                foreach (var pastRound in lastRoundsFlags)
                {
                    // dacă există vreun steag comun, nu e valid
                    if (flagsForRound.Intersect(pastRound).Any())
                    {
                        validSelection = false;
                        break;
                    }
                }
            }

            // adaugăm runda curentă în coadă
            lastRoundsFlags.Enqueue(flagsForRound);

            if (lastRoundsFlags.Count > roundsMemory)
                lastRoundsFlags.Dequeue();

            // setăm imaginile
            pictureBox1.Image = flagsForRound[0];
            pictureBox2.Image = flagsForRound[1];
            pictureBox3.Image = flagsForRound[2];
            pictureBox4.Image = flagsForRound[3];
            pictureBox5.Image = flagsForRound[4];
            pictureBox6.Image = flagsForRound[5];

            buttonStartFlag.Enabled = false;
            tb1flag.Enabled = true;
            btnSubmit.Enabled = true;
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

        private void FlagMode_Load_1(object sender, EventArgs e)
        {

        }

        private void panelFlag_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
