namespace ProiectareCantari
{
    partial class FrmSecondMonitor
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
            this.lblStrofa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStrofa
            // 
            this.lblStrofa.BackColor = System.Drawing.Color.Black;
            this.lblStrofa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrofa.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrofa.ForeColor = System.Drawing.Color.White;
            this.lblStrofa.Location = new System.Drawing.Point(0, 0);
            this.lblStrofa.Name = "lblStrofa";
            this.lblStrofa.Size = new System.Drawing.Size(832, 264);
            this.lblStrofa.TabIndex = 0;
            this.lblStrofa.Text = "label1";
            this.lblStrofa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmSecondMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(832, 264);
            this.Controls.Add(this.lblStrofa);
            this.Name = "FrmSecondMonitor";
            this.Text = "FrmSecondMonitor";
            this.Shown += new System.EventHandler(this.FrmSecondMonitor_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSecondMonitor_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStrofa;
    }
}