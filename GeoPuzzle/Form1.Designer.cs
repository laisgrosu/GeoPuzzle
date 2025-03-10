namespace GeoPuzzle
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butonPuzzle = new System.Windows.Forms.Button();
            this.butonMatch = new System.Windows.Forms.Button();
            this.butonExit = new System.Windows.Forms.Button();
            this.buttonFlagForm1 = new System.Windows.Forms.Button();
            this.Titlu = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butonPuzzle
            // 
            this.butonPuzzle.Font = new System.Drawing.Font("Segoe Print", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonPuzzle.Location = new System.Drawing.Point(580, 565);
            this.butonPuzzle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butonPuzzle.Name = "butonPuzzle";
            this.butonPuzzle.Size = new System.Drawing.Size(271, 77);
            this.butonPuzzle.TabIndex = 0;
            this.butonPuzzle.Text = "Puzzle mode";
            this.butonPuzzle.UseVisualStyleBackColor = true;
            this.butonPuzzle.Click += new System.EventHandler(this.butonPuzzle_Click);
            // 
            // butonMatch
            // 
            this.butonMatch.Font = new System.Drawing.Font("Segoe Print", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonMatch.Location = new System.Drawing.Point(580, 464);
            this.butonMatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butonMatch.Name = "butonMatch";
            this.butonMatch.Size = new System.Drawing.Size(271, 77);
            this.butonMatch.TabIndex = 1;
            this.butonMatch.Text = "Match mode";
            this.butonMatch.UseVisualStyleBackColor = true;
            this.butonMatch.Click += new System.EventHandler(this.butonMatch_Click);
            // 
            // butonExit
            // 
            this.butonExit.Font = new System.Drawing.Font("Segoe Print", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonExit.Location = new System.Drawing.Point(1274, 798);
            this.butonExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butonExit.Name = "butonExit";
            this.butonExit.Size = new System.Drawing.Size(164, 77);
            this.butonExit.TabIndex = 2;
            this.butonExit.Text = "Exit";
            this.butonExit.UseVisualStyleBackColor = true;
            this.butonExit.Click += new System.EventHandler(this.butonExit_Click);
            // 
            // buttonFlagForm1
            // 
            this.buttonFlagForm1.Font = new System.Drawing.Font("Segoe Print", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFlagForm1.Location = new System.Drawing.Point(580, 363);
            this.buttonFlagForm1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFlagForm1.Name = "buttonFlagForm1";
            this.buttonFlagForm1.Size = new System.Drawing.Size(271, 77);
            this.buttonFlagForm1.TabIndex = 3;
            this.buttonFlagForm1.Text = "Flag mode";
            this.buttonFlagForm1.UseVisualStyleBackColor = true;
            this.buttonFlagForm1.Click += new System.EventHandler(this.buttonFlagForm1_Click);
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("Kristen ITC", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.Location = new System.Drawing.Point(555, 95);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(308, 74);
            this.Titlu.TabIndex = 5;
            this.Titlu.Text = "GeoPuzzle";
            this.Titlu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GeoPuzzle.Properties.Resources.pngwing3;
            this.pictureBox1.Location = new System.Drawing.Point(419, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(589, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1490, 900);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Titlu);
            this.Controls.Add(this.buttonFlagForm1);
            this.Controls.Add(this.butonExit);
            this.Controls.Add(this.butonMatch);
            this.Controls.Add(this.butonPuzzle);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainMenu";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butonPuzzle;
        private System.Windows.Forms.Button butonMatch;
        private System.Windows.Forms.Button butonExit;
        private System.Windows.Forms.Button buttonFlagForm1;
        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

