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

        private Stopwatch stopwatch = new Stopwatch();
        private Random random = new Random();
        private PictureBox[] tiles;
        private PictureBox firstClicked = null;
        private Image[] correctOrder1, correctOrder2, correctOrder3, correctOrder4, correctOrder5;
        private Image[] currentCorrectOrder;
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

            foreach (PictureBox tile in tiles)
            {
                tile.Click += Tile_Click;
            }
        }

        // Functia care alege ce puzzle să încarce
        private void butonStart_Click(object sender, EventArgs e)
        {
            // Alege un puzzle specific (în acest caz, puzzle-ul 1)
            currentCorrectOrder = correctOrder1;
            LoadPuzzle(currentCorrectOrder);
        }

        private void butonStart1_Click_1(object sender, EventArgs e)
        {
            currentCorrectOrder = correctOrder2;
            LoadPuzzle(currentCorrectOrder);
        }

        private void butonStart2_Click_1(object sender, EventArgs e)
        {
            currentCorrectOrder = correctOrder3;
            LoadPuzzle(currentCorrectOrder);
        }
        private void butonStart3_Click_1(object sender, EventArgs e)
        {
            currentCorrectOrder = correctOrder4;
            LoadPuzzle(currentCorrectOrder);
        }

        private void butonStart4_Click_1(object sender, EventArgs e)
        {
            currentCorrectOrder = correctOrder5;
            LoadPuzzle(currentCorrectOrder);
        }
        // Încărcăm puzzle-ul cu imaginea aleasă
        private void LoadPuzzle(Image[] correctOrder)
        {
            stopwatch.Restart();
            for (int i = 0; i < 9; i++)
            {
                tiles[i].Image = correctOrder[i];
            }
            ShuffleTiles();
        }

        private void PuzzleMode_Load(object sender, EventArgs e)
        {

        }

        private void ShuffleTiles()
        {
            for (int i = 0; i < 9; i++)
            {
                int randIndex = random.Next(9);
                (tiles[i].Image, tiles[randIndex].Image) = (tiles[randIndex].Image, tiles[i].Image);
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
                // Verifică completarea puzzle-ului pentru corectOrder-ul curent
                if (tiles[i].Image != currentCorrectOrder[i])
                    return;
            }
            stopwatch.Stop(); // Oprim cronometrul
            TimeSpan elapsedTime = stopwatch.Elapsed; // Obținem timpul total

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
