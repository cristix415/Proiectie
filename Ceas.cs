using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


namespace ProiectareCantari
{
    public partial class Ceas : Form
    {
        const int WM_NCPAINT = 0x85;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void DisableProcessWindowsGhosting();

        [DllImport("UxTheme.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Ceas()
        {
            DisableProcessWindowsGhosting();
            InitializeComponent();
            lblTime.Font = new Font("Arial", Properties.Settings.Default.MarimeCeas, FontStyle.Bold);
            
            // functie care actualizeaza ceasul
            StartTimer();

        }
        public void ModificaFont() {
            lblTime.Font = new Font("Arial", Properties.Settings.Default.MarimeCeas, FontStyle.Bold);
            lblTime.BackColor = Properties.Settings.Default.CuloareFundalCeas;
            lblTime.ForeColor = Properties.Settings.Default.CuloareTextCeas;
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


        private void lblTime_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }



    }
}
