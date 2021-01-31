namespace ProiectareCantari
{
    partial class OpenCantare
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
            this.rtxtCantare = new System.Windows.Forms.RichTextBox();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtCantare
            // 
            this.rtxtCantare.AcceptsTab = true;
            this.rtxtCantare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtCantare.Location = new System.Drawing.Point(31, 22);
            this.rtxtCantare.Name = "rtxtCantare";
            this.rtxtCantare.Size = new System.Drawing.Size(496, 639);
            this.rtxtCantare.TabIndex = 1;
            this.rtxtCantare.Text = "";
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalveaza.Location = new System.Drawing.Point(228, 680);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(111, 42);
            this.btnSalveaza.TabIndex = 5;
            this.btnSalveaza.Text = "OK";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // OpenCantare
            // 
            this.AcceptButton = this.btnSalveaza;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 755);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.rtxtCantare);
            this.Name = "OpenCantare";
            this.ShowIcon = false;
            this.Text = "Cantare";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtCantare;
        private System.Windows.Forms.Button btnSalveaza;
    }
}