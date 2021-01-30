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
        public String Strofa;
        
        public FrmSecondMonitor()
        {
            InitializeComponent();
            this.BackColor = Properties.Settings.Default.CuloareFundal;
        }
        public void BindStrofa(String strofa) {
            var gg = Properties.Settings.Default.MarimeVersuri;
            lblStrofa.Text = strofa;
            lblStrofa.BackColor = Properties.Settings.Default.CuloareFundal;
            lblStrofa.ForeColor = Properties.Settings.Default.CuloareText;
            lblStrofa.Font = new Font("Microsoft Sans Serif", Properties.Settings.Default.MarimeVersuri, FontStyle.Regular);
        }

        private void FrmSecondMonitor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void FrmSecondMonitor_Shown(object sender, EventArgs e)
        {

        }
    }
}
