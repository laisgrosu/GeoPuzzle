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
    public partial class MainMenu : Form
    {
        private Dictionary<Control, Rectangle> originalBounds = new Dictionary<Control, Rectangle>();
        private Size originalFormSize;
        private Size originalPanelSize;
        public MainMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(750, 550);

            this.Load += MainMenu_Load;
            this.Resize += MainMenu_Resize;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            // Salvez dimensiunea formului și panelului initial
            originalFormSize = this.ClientSize;
            originalPanelSize = panel1.Size;

            // Salvez dimensiunile originale ale tuturor controalelor din panelMain
            foreach (Control ctrl in panel1.Controls)
            {
                originalBounds[ctrl] = ctrl.Bounds;
            }
        }

        private float baseFontSize = 14f; // ajustează la fontul inițial folosit

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;
            float scaleRatio = Math.Min(xRatio, yRatio);

            int newPanelWidth = (int)(originalPanelSize.Width * xRatio);
            int newPanelHeight = (int)(originalPanelSize.Height * yRatio);
            panel1.Size = new Size(newPanelWidth, newPanelHeight);

            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2
            );

            foreach (Control ctrl in panel1.Controls)
            {
                Rectangle original = originalBounds[ctrl];
                int newX = (int)(original.X * xRatio);
                int newY = (int)(original.Y * yRatio);
                int newWidth = (int)(original.Width * xRatio);
                int newHeight = (int)(original.Height * yRatio);

                ctrl.Bounds = new Rectangle(newX, newY, newWidth, newHeight);

                // Scalează fontul proporțional
                float newFontSize = baseFontSize * scaleRatio;
                if (newFontSize < 8f) newFontSize = 8f; // font minim
                ctrl.Font = new Font(ctrl.Font.FontFamily, newFontSize, ctrl.Font.Style);
            }
            float titleFontScale = 1.6f; // sau 1.8f, cât vrei să fie mai mare decât celelalte

            float newTitleFontSize = baseFontSize * scaleRatio * titleFontScale;
            if (newTitleFontSize < 10f) newTitleFontSize = 10f; // font minim mai mare pentru titlu

            labelTitlu.Font = new Font(labelTitlu.Font.FontFamily, newTitleFontSize, labelTitlu.Font.Style);

            // Centrează titlul
            labelTitlu.Left = (panel1.Width - labelTitlu.Width) / 2;
        }
        private void butonPuzzle_Click(object sender, EventArgs e)
        {
            PuzzleMode puzzleForm = new PuzzleMode();
            puzzleForm.Show();
            this.Hide();
        }

        private void butonMatch_Click(object sender, EventArgs e)
        {
            MatchMode matchForm = new MatchMode();
            matchForm.Show();
            this.Hide();
        }

        private void buttonFlagForm1_Click(object sender, EventArgs e)
        {
            FlagMode flagForm = new FlagMode();
            flagForm.Show();
            this.Hide();
        }

        private void butonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureMainMenu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
