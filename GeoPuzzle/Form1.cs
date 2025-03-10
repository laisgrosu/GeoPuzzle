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
        public MainMenu()
        {
            InitializeComponent();
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
