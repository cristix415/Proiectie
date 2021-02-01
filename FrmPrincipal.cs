using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProiectareCantari
{
    public partial class FrmPrincipal : Form
    {
        private delegate void SafeCallDelegate(BindingSource binding);
        FrmSecondMonitor formSecondMonitor;
        Ceas formCeas;
        Screen _screen;        

        private string ConnectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\db.db";
        private readonly List<Cantare> _listcantari = new List<Cantare>();

        IList<CantareFormatata> _listaCantariFormatate;
        public FrmPrincipal()
        {
            InitializeComponent();

            try
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);

                if (Screen.AllScreens.Length > 1)
                    _screen = Screen.AllScreens[1];
                else
                    _screen = Screen.AllScreens[0];


                formSecondMonitor = new FrmSecondMonitor();
                formSecondMonitor.StartPosition = FormStartPosition.Manual;
                formSecondMonitor.Left = _screen.WorkingArea.Left + 10;
                formSecondMonitor.Top = _screen.WorkingArea.Top + 10;
                formSecondMonitor.Width = _screen.WorkingArea.Width + 10;
                formSecondMonitor.Height = _screen.WorkingArea.Height + 10;
                formSecondMonitor.WindowState = FormWindowState.Maximized;
                formSecondMonitor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;


                LoadCantari();
                BindCantari();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBoxMarimeCantari.Text = Properties.Settings.Default.MarimeVersuri.ToString();
            textBoxMarime.Text = Properties.Settings.Default.MarimeCeas.ToString();
            checkBoxClock.Checked = Properties.Settings.Default.FlagCeas;
        }

        private void LoadCantari()
        {
            const string stringSql = "SELECT * FROM Cantari";
            _listcantari.Clear();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(stringSql, connection);

                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        int id = Convert.ToInt32(sqlReader["Id"]);
                        string titlu = (string)sqlReader["Titlu"];
                        string versuri = (string)sqlReader["Versuri"];
                        int flagBetel = Convert.ToInt32(sqlReader["FlagBetel"]);

                        Cantare cantare = new Cantare(id, titlu, versuri, flagBetel);

                        _listcantari.Add(cantare);
                    }
                }

            }
        }
        private void BindCantari()
        {

            IList<CantareFormatata> listaCantariFormatate = new List<CantareFormatata>();
            IList<Cantare> listBIND;
            if (checkBoxBetel.Checked)
                listBIND = _listcantari.Where(x => x.FlagBetel == 1).ToList();
            else
                listBIND = _listcantari;

            foreach (Cantare cantareDB in listBIND)
            {
                CantareFormatata cantare = new CantareFormatata();
                cantare.ListaStrofe = new List<string>();
                cantare.listaCor = new List<string>();
                cantare.Cantare = cantareDB;
                String[] cantareNeta = cantareDB.Versuri.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.None);
                cantare.Titlu = cantareNeta[0];
                cantare.TextulTOT = cantareDB.Versuri;
                for (int i = 1; i < cantareNeta.Length - 1; i++)
                {
                    string strofa = cantareNeta[i];
                    while (strofa.Length>1 && strofa.Substring(0, 1) == "\n")
                        strofa = strofa.Substring(1, strofa.Length-2);

                    if (strofa.Length > 4 && (strofa.Substring(0, 6) == "Chorus" || strofa.Substring(0, 6) == "Ending" || strofa.Substring(0, 2) == "c\n" || strofa.Substring(0, 5) == "Verse"))
                    {

                        if (strofa.Substring(0, 6) == "Chorus")
                            cantare.listaCor.Add(strofa.Substring(9, strofa.Length - 10));
                        if (strofa.Substring(0, 5) == "Verse")
                            cantare.ListaStrofe.Add(strofa.Substring(9, strofa.Length - 10));
                        if (strofa.Substring(0, 2) == "c\n")
                            cantare.listaCor.Add(strofa.Substring(2, strofa.Length - 3));
                        if (strofa.Substring(0, 6) == "Ending")
                            cantare.Ending = strofa.Substring(9, strofa.Length - 10);

                    }
                    else
                    {
                        if (strofa.Length > 4)
                        {
                            cantare.ListaStrofe.Add(strofa);
                        }
                    }

                }
                listaCantariFormatate.Add(cantare);

            }

            _listaCantariFormatate = listaCantariFormatate;

            var binding = new BindingSource();
            binding.DataSource = _listaCantariFormatate;
            dgwlista.DataSource = binding;

        }
        private void ProiecteazaCantare(Rectangle workingArea)
        {
            if (formSecondMonitor == null)
            {

                formSecondMonitor.Show();
            }
            else
            {
                formSecondMonitor.Show();
            }


        }
        private void CreazaSlide(CantareFormatata cantare)
        {

            flowStrofe.Controls.Clear();
            labelTitlu.BackColor = Properties.Settings.Default.CuloareFundal;
            labelTitlu.ForeColor = Properties.Settings.Default.CuloareText;

            labelTitlu.Text = cantare.Titlu;
            labelTitlu.AutoSize = false;

            labelTitlu.Width = _screen.WorkingArea.Size.Width / 6;
            
            foreach (var strofa in cantare.ListaStrofe)
            {
                Label lblStrofa = CreareLabel(strofa);
                flowStrofe.Controls.Add(lblStrofa);

                if (cantare.listaCor.Count > 0)
                {
                    Label lblCor = CreareLabel(cantare.listaCor[0]);
                    flowStrofe.Controls.Add(lblCor);
                }

            }
            if (!String.IsNullOrEmpty(cantare.Ending))
            {
                Label lblEnd = CreareLabel(cantare.Ending);
                flowStrofe.Controls.Add(lblEnd);
            }
        }

        private Label CreareLabel(string text)
        {
            Label lblStrofa = new Label();
            lblStrofa.TextChanged += new EventHandler(MeasureStringMin);
            lblStrofa.Width = _screen.WorkingArea.Size.Width / 6;
            lblStrofa.Height = _screen.WorkingArea.Size.Height / 6;
            lblStrofa.Text = text;
            lblStrofa.AutoSize = false;
            lblStrofa.TextAlign = ContentAlignment.MiddleCenter;

            lblStrofa.Margin = new Padding(10);
            lblStrofa.BackColor = Properties.Settings.Default.CuloareFundal;
            lblStrofa.ForeColor = Properties.Settings.Default.CuloareText;

            //lblStrofa.Font = new Font(FontFamily.GenericSansSerif, 15);
            lblStrofa.Click += new EventHandler(FireClickEvent);

         
            return lblStrofa;
        }

        private void CautaDupaTitlu()
        {   
            BindingSource lista = dgwlista.DataSource as BindingSource;
            var lis = lista.DataSource as List<CantareFormatata>;
            lis = _listaCantariFormatate.ToList();
            string cuvant = txtCautare.Text.ToLower();
            var listtt = lis.Where(c => c.Titlu.ToLower().Contains(cuvant));

            var binding = new BindingSource();

            binding.DataSource = listtt;

            dgwlista.DataSource = binding;

        }

   
     

        #region SETARI
        private void btnCuloareFundal_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;


            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["CuloareFundal"] = colorDlg.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                foreach (Control ctl in flowStrofe.Controls)
                {
                    (ctl as Label).BackColor = Properties.Settings.Default.CuloareFundal;
                }

            }

        }

        private void btnCuloareText_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["CuloareText"] = colorDlg.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

                foreach (Control ctl in flowStrofe.Controls)
                {
                    (ctl as Label).ForeColor = Properties.Settings.Default.CuloareText;
                }



            }
        }

        private void textBoxMarimeCantari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Properties.Settings.Default["MarimeVersuri"] = Convert.ToInt32(textBoxMarimeCantari.Text);
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                catch
                { };
            }
        }

        private void textBoxMarime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Properties.Settings.Default["MarimeCeas"] = Convert.ToInt32(textBoxMarime.Text);
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                catch
                { };
            }
        }

        #endregion


        #region OPERATII DATABASE
        private void AddCantareDB(Cantare cantare)
        {
            var queryString = "insert into Cantari(Titlu, Versuri, FlagBetel)" +
                                " values(@titlu,@versuri,@FlagBetel);  " +
                                "SELECT last_insert_rowid()";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.AddWithValue("@Titlu", cantare.Titlu);
                command.Parameters.AddWithValue("@Versuri", cantare.Versuri);
                command.Parameters.AddWithValue("@FlagBetel", 1);


                cantare.Id = Convert.ToInt32(command.ExecuteScalar());

                _listcantari.Add(cantare);

            }
        }
        private void AdaugaCantare(Cantare cantare)
        {
            try
            {
                AddCantareDB(cantare);
                BindCantari();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AdaugaCantareNoua_Click(object sender, EventArgs e)
        {
            OpenCantare frmOpenCantare = new OpenCantare();
            frmOpenCantare.ShowDialog();
            if (frmOpenCantare.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                AdaugaCantare(frmOpenCantare.Cantare);
            }

        }
        private void StergeCantare(Cantare cantare)
        {
            const string stringSql = "DELETE FROM Cantari WHERE Id=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(stringSql, connection);
                command.Parameters.AddWithValue("@id", cantare.Id);

                command.ExecuteNonQuery();

                _listcantari.Remove(cantare);
            }
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            CantareFormatata cantare = (dgwlista.SelectedRows[0].DataBoundItem as CantareFormatata);

            if (cantare == null)
            {
                MessageBox.Show("Alege o cantare");
                return;
            }

            if (MessageBox.Show("Esti sigur?", "Sterge", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    StergeCantare(cantare.Cantare);
                    LoadCantari();
                    BindCantari();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            try
            {
                CantareFormatata cantare = (dgwlista.SelectedRows[0].DataBoundItem as CantareFormatata);

                if (cantare == null)
                {
                    MessageBox.Show("Alege o cantare");
                    return;
                }

                OpenCantare frmOpenCantare = new OpenCantare(cantare.Cantare);
                frmOpenCantare.ShowDialog();

                if (frmOpenCantare.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    ModificaCantareDB(frmOpenCantare.Cantare);
                }
            }
            catch
            {
                {
                    MessageBox.Show("Eroar:  Alege o cantare");
                    return;
                }
            }
        }
        private void ModificaCantareDB(Cantare cantare)
        {
            var titlu = cantare.Versuri.Split(new string[] { "\n" }, StringSplitOptions.None)[0];
            var versuri = cantare.Versuri;
            string stringSql = "UPDATE Cantari SET Titlu= @titlu, Versuri = @versuri , FlagBetel = @flagBetel  WHERE Id=" + cantare.Id;

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                //Remove from the database
                SQLiteCommand command = new SQLiteCommand(stringSql, connection);
                command.Parameters.AddWithValue("@titlu", titlu);
                command.Parameters.AddWithValue("@versuri", versuri);
                command.Parameters.AddWithValue("@flagBetel", 1);

                var tt = command.ExecuteNonQuery();


                LoadCantari();
                BindCantari();

            }
        }
        #endregion
        private void FireClickEvent(object sender, EventArgs e)
        {
            foreach (Label ctl in flowStrofe.Controls)
                ctl.ForeColor = Properties.Settings.Default.CuloareText;

            Label lblStrofa = sender as Label;
            lblStrofa.ForeColor = Color.Red;
            lblStrofa.BorderStyle = BorderStyle.FixedSingle;
            lblStrofa.Name = "focus";

            if (_screen != null)
            {

                formSecondMonitor.BindStrofa(lblStrofa.Text);
                formSecondMonitor.BringToFront();
                ProiecteazaCantare(_screen.WorkingArea);
                button1.Focus();
            }
            else
                MessageBox.Show($"Monitor does not exists.");
        }

        private void rtxtCantare_KeyDown(object sender, KeyEventArgs e)
        {
            Oprire(e);
        }
        private void Oprire(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                formSecondMonitor.Hide();
                foreach (Label ctl in flowStrofe.Controls)
                    ctl.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formSecondMonitor.Hide();
            foreach (Label ctl in flowStrofe.Controls)
                ctl.ForeColor = Color.White;
        }

        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            Oprire(e);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                formSecondMonitor.Hide();
                foreach (Label ctl in flowStrofe.Controls)
                    ctl.ForeColor = Color.White;
            }
            if (e.KeyCode == Keys.Down)
            {

                foreach (Label ctl in flowStrofe.Controls)                
                    ctl.ForeColor = Color.White;
                for (int i= 0; i< flowStrofe.Controls.Count;i++)
                    if (flowStrofe.Controls[i].Name == "focus")
                    {
                        Label label = (Label)(flowStrofe.Controls[i + 1]);
                        FireClickEvent(label, null);
                    }

            }


        }

        private void checkBoxClock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBoxMarime.Text) > 10 && Convert.ToInt32(textBoxMarime.Text) < 150)
                {
                    if (checkBoxClock.Checked == true)
                    {
                        formCeas = new Ceas();
                        formCeas.StartPosition = FormStartPosition.Manual;
                        formCeas.Left = _screen.WorkingArea.Left + 10;
                        formCeas.Top = _screen.WorkingArea.Top + 10;
                        formCeas.Width = _screen.WorkingArea.Width + 10;
                        formCeas.Height = _screen.WorkingArea.Height + 10;
                        formCeas.WindowState = FormWindowState.Maximized;
                        formCeas.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

                        formCeas.Show();
                    }
                    else
                        formCeas.Hide();
                }
                else MessageBox.Show("Numar invalid");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DOAR NUMERE SUNT PERMISE");
            }
            button1.Focus();
        }



        private void txtCautare_TextChanged(object sender, EventArgs e)
        {
            CautaDupaTitlu();
        }

        private void dgwlista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CantareFormatata cantare = (dgwlista.SelectedRows[0].DataBoundItem) as CantareFormatata;
            CreazaSlide(cantare);
        }

        private void MeasureStringMin(object sender, EventArgs e)
        {
            Helper.MeasureStringMin((Label)sender, 20);
        }

        private void checkBoxBetel_CheckedChanged(object sender, EventArgs e)
        {
            BindCantari();
        }


        #region UPLOAD
        // doar pentru upload  - upload initial a cantarilor din fisierele txt de pe resurse crestine
        private void CitesteFisierele()
        {

            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Cristian\Downloads\cantece-resurse-crestine-ccli-standard");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(); //Getting Text files
            IList<string> str = new List<string>();

            IList<CantareFormatata> listaCantari = new List<CantareFormatata>();

            foreach (FileInfo file in Files)
            {
                CantareFormatata cantare = new CantareFormatata();
                cantare.ListaStrofe = new List<string>();
                cantare.listaCor = new List<string>();
                string textBrut = System.IO.File.ReadAllText(file.FullName, Encoding.GetEncoding("ISO-8859-2"));

                String[] cantareNeta = textBrut.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.None);

                cantare.Titlu = cantareNeta[0];
                cantare.TextulTOT = textBrut;

                for (int i = 1; i < cantareNeta.Length - 1; i++)
                {
                    if (cantareNeta[i].Length > 4 && cantareNeta[i].Substring(0, 5) == "Verse")
                    {

                        cantare.ListaStrofe.Add(cantareNeta[i]);
                    }
                    else
                    {
                        if (cantareNeta[i].Length > 4)
                            cantare.listaCor.Add(cantareNeta[i]);
                    }
                }
                listaCantari.Add(cantare);

            }
            var de_salvat = listaCantari;

            foreach (var de_salvet in listaCantari)
                AddCantareNET(de_salvet);


            dataGridView1.DataSource = listaCantari;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            CitesteFisierele();
        }
        private void AddCantareNET(CantareFormatata cantare)
        {
            var queryString = "insert into Cantari(Titlu, Versuri, FlagBetel)" +
                                " values(@titlu,@versuri,@FlagBetel);  " +
                                "SELECT last_insert_rowid()";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(queryString, connection);
                command.Parameters.AddWithValue("@Titlu", cantare.Titlu);
                command.Parameters.AddWithValue("@Versuri", cantare.TextulTOT);
                command.Parameters.AddWithValue("@FlagBetel", 0);


                cantare.Id = Convert.ToInt32(command.ExecuteScalar());

            }
        }
        #endregion



    }
}
