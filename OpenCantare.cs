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
            var versuri = rtxtCantare.Text + "\n\nBETEL";
            if (_cantare == null)
                _cantare = new Cantare(titlu, versuri, 1);
            else
                _cantare.Titlu = titlu;
            _cantare.Versuri = versuri;
            this.Dispose();
            DialogResult = DialogResult.OK;
        }

    }
}
