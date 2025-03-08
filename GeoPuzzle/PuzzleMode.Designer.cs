namespace GeoPuzzle
{
    partial class PuzzleMode
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
            this.PuzzleArea = new System.Windows.Forms.Panel();
            this.butonStart = new System.Windows.Forms.Button();
            this.butonBack = new System.Windows.Forms.Button();
            this.PuzzleArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // PuzzleArea
            // 
            this.PuzzleArea.Controls.Add(this.butonBack);
            this.PuzzleArea.Controls.Add(this.butonStart);
            this.PuzzleArea.Location = new System.Drawing.Point(117, 114);
            this.PuzzleArea.Name = "PuzzleArea";
            this.PuzzleArea.Size = new System.Drawing.Size(721, 397);
            this.PuzzleArea.TabIndex = 0;
            // 
            // butonStart
            // 
            this.butonStart.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonStart.Location = new System.Drawing.Point(14, 330);
            this.butonStart.Name = "butonStart";
            this.butonStart.Size = new System.Drawing.Size(104, 53);
            this.butonStart.TabIndex = 1;
            this.butonStart.Text = "Start";
            this.butonStart.UseVisualStyleBackColor = true;
            // 
            // butonBack
            // 
            this.butonBack.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butonBack.Location = new System.Drawing.Point(598, 330);
            this.butonBack.Name = "butonBack";
            this.butonBack.Size = new System.Drawing.Size(107, 53);
            this.butonBack.TabIndex = 1;
            this.butonBack.Text = "Back";
            this.butonBack.UseVisualStyleBackColor = true;
            // 
            // PuzzleMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 631);
            this.Controls.Add(this.PuzzleArea);
            this.Name = "PuzzleMode";
            this.Text = "PuzzleMode";
            this.PuzzleArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PuzzleArea;
        private System.Windows.Forms.Button butonStart;
        private System.Windows.Forms.Button butonBack;
    }
}