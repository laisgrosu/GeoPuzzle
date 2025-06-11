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
        private float baseFontSize = 12f;

        private Dictionary<Image, List<string>> flagNames = new Dictionary<Image, List<string>>();
        private Queue<List<Image>> lastRoundsFlags = new Queue<List<Image>>();
        private int roundsMemory = 3;
        private List<Image> currentFlags = new List<Image>();

        public FlagMode()
        {
            InitializeComponent();
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FlagMode_Load;
            this.Resize += FlagMode_Resize;

            InitializeFlagNames(); // initializez țările pentru steaguri
        }

        private void InitializeFlagNames()
        {
            flagNames = new Dictionary<Image, List<string>>
    {
        { Properties.Resources.brazil_flag, new List<string> { "Brazilia", "BRAZILIA" } },
        { Properties.Resources.portugal_flag, new List<string> { "Portugalia", "PORTUGALIA" } },
        { Properties.Resources.japonia_flag, new List<string> { "Japonia", "JAPONIA" } },
        { Properties.Resources.franta_flag, new List<string> { "Franța", "FRANȚA", "Franta", "FRANTA" } },
        { Properties.Resources.india_flag, new List<string> { "India", "INDIA" } },
        { Properties.Resources.cehia_flag, new List<string> { "Cehia", "CEHIA" } },
        { Properties.Resources.plonia_flag, new List<string> { "Polonia", "POLONIA" } },
        { Properties.Resources.romania_flag, new List<string> { "România", "ROMÂNIA", "Romania", "ROMANIA" } },
        { Properties.Resources.uk_flag, new List<string> { "Regatul Unit", "REGATUL UNIT", "United Kingdom", "UNITED KINGDOM" } },
        { Properties.Resources.turcia_flag, new List<string> { "Turcia", "TURCIA" } },
        { Properties.Resources.tailanda_flag, new List<string> { "Thailanda", "THAILANDA" } },
        { Properties.Resources.sua_flag, new List<string> { "Statele Unite ale Americii", "STATELE UNITE ALE AMERICII", "SUA", "USA" } },
        { Properties.Resources.uruguay_flag_flag, new List<string> { "Uruguay", "URUGUAY" } },
        { Properties.Resources.venezuela_flag, new List<string> { "Venezuela", "VENEZUELA" } },
        { Properties.Resources.south_coreea_flag, new List<string> { "Coreea de Sud", "COREEA DE SUD", "South Korea", "SOUTH KOREA" } },
        { Properties.Resources.olanda_flag, new List<string> { "Olanda", "OLANDA" } },
        { Properties.Resources.filipine_flag, new List<string> { "Filipine", "FILIPINE" } },
        { Properties.Resources.dameraca_flag, new List<string> { "Danemarca", "DANEMARCA" } },
        { Properties.Resources.madagascar_flag, new List<string> { "Madagascar", "MADAGASCAR" } },
        { Properties.Resources.mongolia_flag, new List<string> { "Mongolia", "MONGOLIA" } },
        { Properties.Resources.puerto_rico_flag_pnh, new List<string> { "Puerto Rico", "PUERTO RICO" } },
        { Properties.Resources.zambia_flag, new List<string> { "Zambia", "ZAMBIA" } },
        { Properties.Resources.uganda_flag, new List<string> { "Uganda", "UGANDA" } },
        { Properties.Resources.south_africa_flag, new List<string> { "Africa de Sud", "AFRICA DE SUD", "South Africa", "SOUTH AFRICA" } },
        { Properties.Resources.belarsu_flag, new List<string> { "Belarus", "BELARUS" } },
        { Properties.Resources.canada_flag, new List<string> { "Canada", "CANADA" } },
        { Properties.Resources.costa_rica_flag, new List<string> { "Costa Rica", "COSTA RICA" } },
        { Properties.Resources.chile_flag, new List<string> { "Chile", "CHILE" } },
        { Properties.Resources.china_flag, new List<string> { "China", "CHINA" } },
        { Properties.Resources.bolivia_flsg, new List<string> { "Bolivia", "BOLIIVIA" } },
        { Properties.Resources.egypt_flag, new List<string> { "Egipt", "EGIPT", "EGYPT", "Egypt"} },
        { Properties.Resources.kazakhstan_flag, new List<string> { "Kazakhstan", "KAZAKHSTAN"} },
        { Properties.Resources.cuba_flag, new List<string> { "Cuba", "CUBA"} },
        { Properties.Resources.sudan_flag, new List<string> { "Sudan", "SUDAN" } }
    };
        }

        private void FlagMode_Load(object sender, EventArgs e)
        {
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

            panelFlag.Size = new Size((int)(originalPanelSize.Width * xRatio), (int)(originalPanelSize.Height * yRatio));
            panelFlag.Location = new Point((this.ClientSize.Width - panelFlag.Width) / 2, (this.ClientSize.Height - panelFlag.Height) / 2);

            foreach (Control ctrl in panelFlag.Controls)
            {
                Rectangle original = originalBounds[ctrl];
                ctrl.Bounds = new Rectangle(
                    (int)(original.X * xRatio),
                    (int)(original.Y * yRatio),
                    (int)(original.Width * xRatio),
                    (int)(original.Height * yRatio)
                );

                float newFontSize = baseFontSize * scaleRatio;
                ctrl.Font = new Font(ctrl.Font.FontFamily, Math.Max(newFontSize, 8f), ctrl.Font.Style);
            }

            labelFlag.Left = (panelFlag.Width - labelFlag.Width) / 2;
        }

        private void buttonStartFlag_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelFlag.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    tb.Text = ""; // goli textul
                    tb.BackColor = SystemColors.Window; // reset la culoarea default (alb)
                    tb.Enabled = true; // reactivare
                }
            }

            btnSubmit.Enabled = true;

            Random rnd = new Random();
            var allFlags = flagNames.Keys.ToList();

            bool validSelection = false;
            while (!validSelection)
            {
                currentFlags = allFlags.OrderBy(x => rnd.Next()).Take(6).ToList();
                validSelection = !lastRoundsFlags.Any(past => currentFlags.Intersect(past).Any());
            }

            lastRoundsFlags.Enqueue(currentFlags);
            if (lastRoundsFlags.Count > roundsMemory)
                lastRoundsFlags.Dequeue();

            // Setăm imaginile
            pictureBox1.Image = currentFlags[0];
            pictureBox2.Image = currentFlags[1];
            pictureBox3.Image = currentFlags[2];
            pictureBox4.Image = currentFlags[3];
            pictureBox5.Image = currentFlags[4];
            pictureBox6.Image = currentFlags[5];

            buttonStartFlag.Enabled = false;
            btnSubmit.Enabled = true;

            tb1flag.Enabled = tb2flag.Enabled = tb3flag.Enabled = tb4flag.Enabled = tb5flag.Enabled = tb6flag.Enabled = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox> { tb1flag, tb2flag, tb3flag, tb4flag, tb5flag, tb6flag };

            int correctCount = 0;

            for (int i = 0; i < 6; i++)
            {
                string userInput = textBoxes[i].Text.Trim();
                List<string> correctAnswersForFlag = flagNames[currentFlags[i]];

                bool isCorrect = correctAnswersForFlag.Any(ans =>
                    GetAutoCorrectedInput(userInput, ans) == ans
                );

                if (isCorrect)
                {
                    // Gasim varianta corecta care a trecut autocorectia
                    string correctedAnswer = correctAnswersForFlag.First(ans => GetAutoCorrectedInput(userInput, ans) == ans);
                    correctCount++;
                    textBoxes[i].Text = correctedAnswer;
                    textBoxes[i].BackColor = Color.LightGreen;
                }
                else
                {
                    textBoxes[i].BackColor = Color.LightCoral;
                }
            }

            if (correctCount == 6)
            {
                MessageBox.Show("Felicitări! Ai recunoscut toate cele 6 steaguri corect!");
                btnSubmit.Enabled = false;
                buttonStartFlag.Enabled = true;
                foreach (var tb in textBoxes)
                    tb.Enabled = false;
            }
            else
            {
                MessageBox.Show($"Ai răspuns corect la {correctCount} din 6. Încearcă din nou!");
                buttonStartFlag.Enabled = true;
            }
        }

        private string GetAutoCorrectedInput(string userInput, string correctAnswer)
        {
            userInput = userInput.Trim();
            string lowerUser = userInput.ToLower();
            string lowerCorrect = correctAnswer.ToLower();

            if (lowerUser == lowerCorrect)
                return correctAnswer; // e corect deja

            // Dacă distanța Levenshtein e mică, îl corectăm
            if (LevenshteinDistance(lowerUser, lowerCorrect) <= 1)
                return correctAnswer;

            return userInput; // nu putem corecta
        }

        // Levenshtein pentru autocorecție simplă
        private int LevenshteinDistance(string a, string b)
        {
            int[,] dp = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++) dp[i, 0] = i;
            for (int j = 0; j <= b.Length; j++) dp[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = (a[i - 1] == b[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(
                        Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                        dp[i - 1, j - 1] + cost);
                }
            }

            return dp[a.Length, b.Length];
        }


        private void buttonBackFlag_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }

        // Alte metode goale dacă ai nevoie
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void labelFlag_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void FlagMode_Load_1(object sender, EventArgs e) { }
        private void panelFlag_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}