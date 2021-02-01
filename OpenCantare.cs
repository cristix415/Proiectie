using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProiectareCantari
{
    public partial class OpenCantare : Form
    {
        Cantare _cantare;
        public Cantare Cantare { get { return _cantare; }  }
        public OpenCantare()
        {
            InitializeComponent();
            
        }
        public OpenCantare(Cantare cantare)
        {
            InitializeComponent();            
            _cantare = cantare;
            rtxtCantare.Text = cantare.Versuri;
            rtxtCantare.Tag = cantare;
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            var titlu = rtxtCantare.Text.Split(new string[] { "\n" }, StringSplitOptions.None)[0];
            string versuri;
            if (_cantare == null)
            {
                versuri = rtxtCantare.Text + "\n\nBETEL";
                _cantare = new Cantare(titlu, versuri, 1);
            }
            else
            {
                versuri = rtxtCantare.Text;
                _cantare.Versuri = versuri;
                _cantare.Titlu = titlu;
            }
 
            this.Dispose();
            DialogResult = DialogResult.OK;
        }

    }
}
