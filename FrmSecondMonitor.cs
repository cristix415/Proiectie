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
    public partial class FrmSecondMonitor : Form
    {        
        public FrmSecondMonitor()
        {
            InitializeComponent();
            this.BackColor = Properties.Settings.Default.CuloareFundal;
        }
        public void BindStrofa(String strofa)
        {
            lblStrofa.BackColor = Properties.Settings.Default.CuloareFundal;
            lblStrofa.ForeColor = Properties.Settings.Default.CuloareText;
            lblStrofa.Text = strofa;            
        }
        
        private void FrmSecondMonitor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void lblStrofa_TextChanged(object sender, EventArgs e)
        {
            Helper.MeasureStringMin(lblStrofa, 80);
        }
    }
}
