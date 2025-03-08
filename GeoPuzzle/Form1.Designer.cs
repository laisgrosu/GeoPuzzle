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
            this.SuspendLayout();
            // 
            // butonPuzzle
            // 
            this.butonPuzzle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonPuzzle.Location = new System.Drawing.Point(12, 379);
            this.butonPuzzle.Name = "butonPuzzle";
            this.butonPuzzle.Size = new System.Drawing.Size(113, 59);
            this.butonPuzzle.TabIndex = 0;
            this.butonPuzzle.Text = "Puzzle mode";
            this.butonPuzzle.UseVisualStyleBackColor = true;
            // 
            // butonMatch
            // 
            this.butonMatch.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonMatch.Location = new System.Drawing.Point(12, 314);
            this.butonMatch.Name = "butonMatch";
            this.butonMatch.Size = new System.Drawing.Size(113, 59);
            this.butonMatch.TabIndex = 1;
            this.butonMatch.Text = "Match mode";
            this.butonMatch.UseVisualStyleBackColor = true;
            // 
            // butonExit
            // 
            this.butonExit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonExit.Location = new System.Drawing.Point(673, 370);
            this.butonExit.Name = "butonExit";
            this.butonExit.Size = new System.Drawing.Size(115, 59);
            this.butonExit.TabIndex = 2;
            this.butonExit.Text = "Exit";
            this.butonExit.UseVisualStyleBackColor = true;
            // 
            // buttonFlagForm1
            // 
            this.buttonFlagForm1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFlagForm1.Location = new System.Drawing.Point(12, 250);
            this.buttonFlagForm1.Name = "buttonFlagForm1";
            this.buttonFlagForm1.Size = new System.Drawing.Size(113, 58);
            this.buttonFlagForm1.TabIndex = 3;
            this.buttonFlagForm1.Text = "Flag mode";
            this.buttonFlagForm1.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFlagForm1);
            this.Controls.Add(this.butonExit);
            this.Controls.Add(this.butonMatch);
            this.Controls.Add(this.butonPuzzle);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butonPuzzle;
        private System.Windows.Forms.Button butonMatch;
        private System.Windows.Forms.Button butonExit;
        private System.Windows.Forms.Button buttonFlagForm1;
    }
}

