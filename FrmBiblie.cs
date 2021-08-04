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
    public partial class FrmBiblie : Form
    {
        public FrmBiblie(Screen _screen)
        {
            InitializeComponent();

            //initializare setari la fiecare deschidere a formularului
            lblReferinta.Font = new Font("Arial" ,80);
            lblVerset.Font = new Font("Arial", 80);
            lblReferinta.Width = _screen.WorkingArea.Width;
            lblVerset.Width = _screen.WorkingArea.Width;
            lblReferinta.Height = _screen.WorkingArea.Height /10;
            lblVerset.Height = _screen.WorkingArea.Height - lblReferinta.Height;
            lblReferinta.TextAlign = ContentAlignment.MiddleCenter;
            lblVerset.TextAlign = ContentAlignment.MiddleCenter;
            lblReferinta.Padding = new Padding(0, 0, 0, 0);
        }
        public void BindVerset(Book carte, Verses verset)
        {
            //actualizare verset
            lblReferinta.BackColor = Properties.Settings.Default.CuloareFundal;
            lblReferinta.ForeColor = Properties.Settings.Default.CuloareText;
            lblVerset.BackColor = Properties.Settings.Default.CuloareFundal;
            lblVerset.ForeColor = Properties.Settings.Default.CuloareText;
            lblVerset.Text = verset.text;
            lblReferinta.Text = carte.long_name + " "+  verset.chapter + " : " + verset.verse;
            Helper.MeasureStringMin(lblReferinta, 90);
            Helper.MeasureStringMin(lblVerset, 90);
        }
      
    }
}
