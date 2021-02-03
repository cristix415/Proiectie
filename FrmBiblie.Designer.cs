namespace ProiectareCantari
{
    partial class FrmBiblie
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblReferinta = new System.Windows.Forms.Label();
            this.lblVerset = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.lblReferinta);
            this.flowLayoutPanel1.Controls.Add(this.lblVerset);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 585);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblReferinta
            // 
            this.lblReferinta.Location = new System.Drawing.Point(4, 0);
            this.lblReferinta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReferinta.Name = "lblReferinta";
            this.lblReferinta.Size = new System.Drawing.Size(46, 17);
            this.lblReferinta.TabIndex = 0;
            this.lblReferinta.Text = "label1";
            // 
            // lblVerset
            // 
            this.lblVerset.Location = new System.Drawing.Point(4, 17);
            this.lblVerset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVerset.Name = "lblVerset";
            this.lblVerset.Size = new System.Drawing.Size(46, 17);
            this.lblVerset.TabIndex = 1;
            this.lblVerset.Text = "label2";
            // 
            // FrmBiblie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 585);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmBiblie";
            this.Text = "FrmBiblie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblReferinta;
        private System.Windows.Forms.Label lblVerset;
    }
}