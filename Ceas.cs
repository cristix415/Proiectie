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
    public partial class Ceas : Form
    {
        public Ceas()
        {
            InitializeComponent();
            lblTime.Font = new Font("Arial", Properties.Settings.Default.MarimeCeas, FontStyle.Bold);
            
            StartTimer();

        }
        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
        }
    }
}
