using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GeoPuzzle
{
    public partial class PuzzleMode : Form
    {
        private Size originalFormSize;
        private Size originalPanelSize;
        private Rectangle originalPanel1Bounds;
        private Dictionary<Control, Rectangle> originalControlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> originalFontSizes = new Dictionary<Control, float>();
        private Dictionary<Button, Rectangle> originalButtonBounds = new Dictionary<Button, Rectangle>();
        private Dictionary<Button, float> originalButtonFontSizes = new Dictionary<Button, float>();
        private Stopwatch stopwatch = new Stopwatch();
        private Random random = new Random();
        private PictureBox[] tiles;
        private PictureBox firstClicked = null;
        private Image[] correctOrder1, correctOrder2, correctOrder3, correctOrder4, correctOrder5, correctOrder6, correctOrder7;
        private Image[] currentCorrectOrder;
        private float baseFontSize;

        public PuzzleMode()
        {
            InitializeComponent();
            this.Size = new Size(800, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            tiles = new PictureBox[] { pb1, pb2, pb3, pb4, pb5, pb6, pb7, pb8, pb9 };
            correctOrder1 = new Image[]
            {
                Properties.Resources._9, Properties.Resources._8, Properties.Resources._7,
                Properties.Resources._6, Properties.Resources._5, Properties.Resources._4,
                Properties.Resources._3, Properties.Resources._2, Properties.Resources._1
            };
            correctOrder2 = new Image[]
            {
                Properties.Resources.rom9, Properties.Resources.rom8, Properties.Resources.rom7,
                Properties.Resources.rom6, Properties.Resources.rom5, Properties.Resources.rom4,
                Properties.Resources.rom3, Properties.Resources.rom2, Properties.Resources.rom1
            };
            correctOrder3 = new Image[]
            {
                Properties.Resources.usa9, Properties.Resources.usa8, Properties.Resources.usa7,
                Properties.Resources.usa6, Properties.Resources.usa5, Properties.Resources.usa4,
                Properties.Resources.usa3, Properties.Resources.usa2, Properties.Resources.usa1
            };
            correctOrder4 = new Image[]
            {
                Properties.Resources.fra9, Properties.Resources.fra8, Properties.Resources.fra7,
                Properties.Resources.fra6, Properties.Resources.fra5, Properties.Resources.fra4,
                Properties.Resources.fra3, Properties.Resources.fra2, Properties.Resources.fra1
            };
            correctOrder5 = new Image[]
            {
                Properties.Resources.co9, Properties.Resources.co8, Properties.Resources.co7,
                Properties.Resources.co6, Properties.Resources.co5, Properties.Resources.co4,
                Properties.Resources.co3, Properties.Resources.co2, Properties.Resources.co1
            };
            correctOrder6 = new Image[]
            {
                Properties.Resources.india1, Properties.Resources.india2, Properties.Resources.india3,
                Properties.Resources.india4, Properties.Resources.india5, Properties.Resources.india6,
                Properties.Resources.india7, Properties.Resources.india8, Properties.Resources.india9
            };
            correctOrder7 = new Image[]
            {
                Properties.Resources.chi1, Properties.Resources.chi2, Properties.Resources.chi3,
                Properties.Resources.chi4, Properties.Resources.chi5, Properties.Resources.chi6,
                Properties.Resources.chi7, Properties.Resources.chi8, Properties.Resources.chi9
            };

            foreach (PictureBox tile in tiles)
            {
                tile.Click += Tile_Click;
            }
            this.Load += PuzzleMode_Load;
            this.Resize += PuzzleMode_Resize;
        }

        // Functia care alege ce puzzle să încarce
        private void butonStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int choice = rnd.Next(3);
            if (choice == 0)
            {
                currentCorrectOrder = correctOrder1;
                LoadPuzzle(currentCorrectOrder);
            }
            else if (choice == 1)
            {
                currentCorrectOrder = correctOrder6;
                LoadPuzzle(currentCorrectOrder);
            }
            else
            {
                currentCorrectOrder = correctOrder7;
                LoadPuzzle(currentCorrectOrder);
            }
        }

        private void butonStart1_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int choice = rnd.Next(2); // 0 sau 1
            if (choice == 0)
            {
                currentCorrectOrder = correctOrder2;
                LoadPuzzle(currentCorrectOrder);
            }
            else
            {
                currentCorrectOrder = correctOrder4;
                LoadPuzzle(currentCorrectOrder);
            }
        }

        private void butonStart2_Click_1(object sender, EventArgs e)
        {
            currentCorrectOrder = correctOrder3;
            LoadPuzzle(currentCorrectOrder);
        }

        private void butonStart4_Click_1(object sender, EventArgs e)
        {
            currentCorrectOrder = correctOrder5;
            LoadPuzzle(currentCorrectOrder);
        }

        private void LoadPuzzle(Image[] correctOrder)
        {
            stopwatch.Restart();
            for (int i = 0; i < 9; i++)
            {
                tiles[i].Image = correctOrder[i];
            }
            ShuffleTiles();
        }

        private Rectangle originalPuzzleAreaBounds;

        private void PuzzleMode_Load(object sender, EventArgs e)
        {
            originalFormSize = this.ClientSize;
            originalPanelSize = panel1.Size;
            originalPuzzleAreaBounds = PuzzleArea.Bounds;

            foreach (Control c in panel1.Controls)
            {
                originalControlBounds[c] = c.Bounds;
                originalFontSizes[c] = c.Font.Size;
            }
            foreach (Control c in PuzzleArea.Controls)
            {
                originalControlBounds[c] = c.Bounds;
                originalFontSizes[c] = c.Font.Size;
            }
        }


        private void PuzzleMode_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;
            float scaleRatio = Math.Min(xRatio, yRatio);

            panel1.Size = new Size((int)(originalPanelSize.Width * scaleRatio), (int)(originalPanelSize.Height * scaleRatio));
            panel1.Location = new Point(
                (this.ClientSize.Width - panel1.Width) / 2,
                (this.ClientSize.Height - panel1.Height) / 2);


            foreach (Control c in panel1.Controls)
            {
                if (c == PuzzleArea) continue; 
                Rectangle originalRect = originalControlBounds[c];
                c.Bounds = new Rectangle(
                    (int)(originalRect.X * scaleRatio),
                    (int)(originalRect.Y * scaleRatio),
                    (int)(originalRect.Width * scaleRatio),
                    (int)(originalRect.Height * scaleRatio));

                float newFontSize = originalFontSizes[c] * scaleRatio;
                if (newFontSize < 8f) newFontSize = 8f;
                c.Font = new Font(c.Font.FontFamily, newFontSize, c.Font.Style);
            }
            int newPuzzleAreaWidth = (int)(originalPuzzleAreaBounds.Width * scaleRatio);
            int newPuzzleAreaHeight = (int)(originalPuzzleAreaBounds.Height * scaleRatio);
            
            int maxAllowedHeight = (int)(panel1.Height * 0.85f);
            
            if (newPuzzleAreaHeight > maxAllowedHeight)
                newPuzzleAreaHeight = maxAllowedHeight;


            newPuzzleAreaWidth = Math.Min(newPuzzleAreaWidth, panel1.Width);
            newPuzzleAreaHeight = Math.Min(newPuzzleAreaHeight, panel1.Height);

            PuzzleArea.Size = new Size(newPuzzleAreaWidth, newPuzzleAreaHeight);

            PuzzleArea.Location = new Point(
                (panel1.Width - PuzzleArea.Width) / 2,
                (panel1.Height - PuzzleArea.Height) / 2);

            foreach (Control tile in PuzzleArea.Controls)
            {
                Rectangle originalRect = originalControlBounds[tile];
                tile.Bounds = new Rectangle(
                    (int)(originalRect.X * scaleRatio),
                    (int)(originalRect.Y * scaleRatio),
                    (int)(originalRect.Width * scaleRatio),
                    (int)(originalRect.Height * scaleRatio));

                float newFontSize = originalFontSizes[tile] * scaleRatio;
                if (newFontSize < 6f) newFontSize = 6f;
                tile.Font = new Font(tile.Font.FontFamily, newFontSize, tile.Font.Style);
            }
        }


        private void ShuffleTiles()
        {
            for (int i = tiles.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (tiles[i].Image, tiles[j].Image) = (tiles[j].Image, tiles[i].Image);
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            PictureBox clickedTile = sender as PictureBox;
            if (firstClicked == null)
            {
                firstClicked = clickedTile;
            }
            else
            {
                (firstClicked.Image, clickedTile.Image) = (clickedTile.Image, firstClicked.Image);
                firstClicked = null;
                CheckCompletion();
            }
        }

        private void CheckCompletion()
        {
            for (int i = 0; i < 9; i++)
            {
                if (tiles[i].Image != currentCorrectOrder[i])
                    return;
            }
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            MessageBox.Show($"Felicitări! Ai rezolvat puzzle-ul în {elapsedTime.Minutes} minute și {elapsedTime.Seconds} secunde!",
                            "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butonBack_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}
