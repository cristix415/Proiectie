using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace ProiectareCantari
{
    public partial class FrmPrincipal : Form
    {
        private delegate void SafeCallDelegate(BindingSource binding);
        FrmSecondMonitor formSecondMonitor;
        Ceas formCeas;
        Screen _screen;
        FrmBiblie _formBiblie;
        Point aliniere;

        private string ConnectionString = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\db.db";
        private readonly List<Cantare> _listcantari = new List<Cantare>();

        IList<CantareFormatata> _listaCantariFormatate;
        IList<Book> _listaCarti = new List<Book>();
        IList<Verses> _listaVersete = new List<Verses>();
        Book _carte;
        public FrmPrincipal()
        {
            InitializeComponent();
            txtLungimeCadru.Text = Properties.Settings.Default.LungimeCadruCeas.ToString();
            txtLatimeCadru.Text = Properties.Settings.Default.LatimeCadruCeas.ToString();
            textBoxMarime.Text = Properties.Settings.Default.MarimeCeas.ToString();
            this.WindowState = FormWindowState.Maximized;
            try
            {
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

                //incarcare cantari in memorie
                LoadCantari();

                // bind lista de cantari la controlul DrataGrivView
                BindCantari(_listcantari);

                // incarcarea in menorie a cartilor din biblie
                LoadCarti();
                // incarcarea in menorie a cartilor din biblie
                BindCarti();
            }
            catch (Exception ex)
            {
                // afisare erori
                MessageBox.Show(ex.Message);
            }

            textBoxMarimeCantari.Text = Properties.Settings.Default.MarimeVersuri.ToString();
            textBoxMarime.Text = Properties.Settings.Default.MarimeCeas.ToString();
            checkBoxClock.Checked = Properties.Settings.Default.FlagCeas;

            flowLayoutPanelIstoric.HorizontalScroll.Enabled = false;
            flowLayoutPanelIstoric.HorizontalScroll.Visible = false;
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
        private void BindCantari(IList<Cantare> listaCantari)
        {

            IList<CantareFormatata> listaCantariFormatate = new List<CantareFormatata>();
            IList<Cantare> listBIND;
            if (checkBoxBetel.Checked)
                listBIND = listaCantari.Where(x => x.FlagBetel == 1).ToList();
            else
                listBIND = listaCantari;

            foreach (Cantare cantareDB in listBIND)
            {
                CantareFormatata cantare = new CantareFormatata();
                cantare.ListaStrofe = new List<string>();
                cantare.listaCor = new List<string>();
                cantare.Cantare = cantareDB;
                String[] cantareNeta = cantareDB.Versuri.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.None);
                cantare.Titlu = cantareDB.Titlu;
                cantare.TextulTOT = cantareDB.Versuri;
                for (int i = 1; i < cantareNeta.Length - 1; i++)
                {
                    string strofa = cantareNeta[i];
                    while (strofa.Length > 1 && strofa.Substring(0, 1) == "\n")
                        strofa = strofa.Substring(1, strofa.Length - 2);

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
            formSecondMonitor.Show();
        }
        private void CreazaSlide(CantareFormatata cantare)
        {

            flowStrofe.Controls.Clear();
            labelTitlu.BackColor = Properties.Settings.Default.CuloareFundal;
            labelTitlu.ForeColor = Properties.Settings.Default.CuloareText;

            labelTitlu.Text = cantare.Titlu;
            labelTitlu.AutoSize = false;

            labelTitlu.Width = 500;

            for (int i = 0; i < cantare.ListaStrofe.Count; i++)
            {
                int numLines = cantare.ListaStrofe[i].Split('\n').Length - 1;
                Label btnNrStrofa = CreareNrButton((i + 1).ToString(), numLines, false);

                flowStrofe.Controls.Add(btnNrStrofa);
                Button btnStrofa = CreareLabel(cantare.ListaStrofe[i]);
                flowStrofe.Controls.Add(btnStrofa);



                btnNrStrofa.Height = btnStrofa.Height;



                if (cantare.listaCor.Count > 0)
                {
                    int numLinesCor = cantare.listaCor[0].Split('\n').Length - 1;
                    Label btnNrcor = CreareNrButton("", numLinesCor, true);
                    flowStrofe.Controls.Add(btnNrcor);
                    Button btnCor = CreareLabel(cantare.listaCor[0]);

                    flowStrofe.Controls.Add(btnCor);
                    btnNrcor.Height = btnCor.Height;

                }


            }
            if (!String.IsNullOrEmpty(cantare.Ending))
            {
                Button lblEnd = CreareLabel(cantare.Ending);
                flowStrofe.Controls.Add(lblEnd);
            }
        }

        private Button CreareLabel(string text)
        {
            DoubleClickButton lblStrofa = new DoubleClickButton();
            lblStrofa.DoubleClick += new EventHandler(FireDbClickClickEvent);

            //    DoubleClickButton lblStrofa = new Button();
            //lblStrofa.TextChanged += new EventHandler(MeasureStringMin);
            //  lblStrofa.Width = _screen.WorkingArea.Size.Width / 6;
            //   lblStrofa.Width = 520;
            //  lblStrofa.Height = _screen.WorkingArea.Size.Height / 6;
            int numLines = text.Split('\n').Length - 1;
            //  lblStrofa.Height = 35 * numLines;
            lblStrofa.Text = text;
            lblStrofa.TextAlign = ContentAlignment.MiddleLeft;
            lblStrofa.AutoSize = true;
            lblStrofa.MinimumSize = new Size(520, 30);

            lblStrofa.Margin = new Padding(0);
            lblStrofa.BackColor = Properties.Settings.Default.CuloareFundal;
            lblStrofa.ForeColor = Properties.Settings.Default.CuloareText;

            //lblStrofa.Font = new Font(FontFamily.GenericSansSerif, 15);
            lblStrofa.Click += new EventHandler(FireClickEvent);
            lblStrofa.KeyPress += new KeyPressEventHandler(FireStrofaKEYEvent);
            //lblStrofa.DoubleClick += new EventHandler(FireDbClickClickEvent);


            return lblStrofa;
        }
        private Label CreareNrButton(string text, int nrLines, bool cor)
        {
            Label lblStrofa = new Label();
            //lblStrofa.TextChanged += new EventHandler(MeasureStringMin);
            //  lblStrofa.Width = _screen.WorkingArea.Size.Width / 6;
            lblStrofa.Width = 40;
            //  lblStrofa.Height = _screen.WorkingArea.Size.Height / 6;
            // int numLines = text.Split('\n').Length - 1;
            //     lblStrofa.Height = 35 * nrLines;
            //     lblStrofa.AutoSize = false;
            lblStrofa.TextAlign = ContentAlignment.MiddleLeft;
            lblStrofa.BackColor = Properties.Settings.Default.CuloareFundal;
            lblStrofa.ForeColor = Properties.Settings.Default.CuloareText;

            //lblStrofa.Margin = new Padding(0);
            if (cor)
            {
                lblStrofa.Text = "C  O  R";
            }
            else
            {
                lblStrofa.Text = text;

            }


            lblStrofa.TabStop = false;

            //lblStrofa.Font = new Font(FontFamily.GenericSansSerif, 15);

            //  lblStrofa.Enabled = false;
            //lblStrofa.ForeColor = lblStrofa.Enabled == false ? Color.Blue : Properties.Settings.Default.CuloareText;
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
                    if (ctl is Button)
                        (ctl as Button).BackColor = Properties.Settings.Default.CuloareFundal;
                    else
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
                    if (ctl is Button)
                        (ctl as Button).ForeColor = Properties.Settings.Default.CuloareText;
                    else
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
                    if (formCeas != null)
                        formCeas.ModificaFont();
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
                BindCantari(_listcantari);
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
                    BindCantari(_listcantari);
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
                genericCantare genericCantare = new genericCantare();
                CantareFormatata cantare = (dgwlista.SelectedRows[0].DataBoundItem as CantareFormatata);
                if (String.IsNullOrEmpty(cantare.Cantare.Versuri))
                {
                    genericCantare = CallAPIid(cantare.Cantare.Id);
                }
                if (cantare == null)
                {
                    MessageBox.Show("Alege o cantare");
                    return;
                }
                string versuri="";
                foreach (var str in genericCantare.cantec.continut)
                    versuri = versuri + "\n\n" + str.text;
                OpenCantare frmOpenCantare = new OpenCantare(new Cantare(genericCantare.cantec.titlu, versuri,0));
                frmOpenCantare.ShowDialog();

                if (frmOpenCantare.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (genericCantare.cantec != null)
                    AdaugaCantare(frmOpenCantare.Cantare);
                    else
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
                BindCantari(_listcantari);

            }
        }
        #endregion
        private void FireClickEvent(object sender, EventArgs e)
        {
            if (checkBoxLive.Checked)
            {
                foreach (Control ctl in flowStrofe.Controls)
                    ctl.ForeColor = Properties.Settings.Default.CuloareText;

                Button lblStrofa = sender as Button;
                lblStrofa.ForeColor = Color.Red;
                //lblStrofa.BorderStyle = BorderStyle.FixedSingle;
                lblStrofa.Name = "focus";

                if (_screen != null)
                {

                    formSecondMonitor.BindStrofa(lblStrofa.Text);
                    formSecondMonitor.BringToFront();
                    // deschide formularul de cantare pe monitorul 2 fullscreen
                    ProiecteazaCantare(_screen.WorkingArea);

                }
                else
                    MessageBox.Show($"Monitor does not exists.");
                this.Focus();
            }
        }
        private void FireStrofaKEYEvent(object sender, EventArgs e)
        {
            if (checkBoxLive.Checked)
            {
                foreach (Button ctl in flowStrofe.Controls)
                    ctl.ForeColor = Properties.Settings.Default.CuloareText;

                Button btnStrofa = sender as Button;
                btnStrofa.ForeColor = Color.Red;
                //   btnStrofa.BorderStyle = BorderStyle.FixedSingle;
                btnStrofa.Name = "focus";

                if (_screen != null)
                {

                    formSecondMonitor.BindStrofa(btnStrofa.Text);
                    formSecondMonitor.BringToFront();
                    // deschide formularul de cantare pe monitorul 2 fullscreen
                    ProiecteazaCantare(_screen.WorkingArea);

                }
                else
                    MessageBox.Show($"Monitor does not exists.");
            }
        }
        private void FireDbClickClickEvent(object sender, EventArgs e)
        {
            checkBoxLive.Checked = true;
            foreach (Control ctl in flowStrofe.Controls)
                ctl.ForeColor = Properties.Settings.Default.CuloareText;

            Button btnStrofa = sender as Button;
            btnStrofa.ForeColor = Color.Red;
            //   btnStrofa.BorderStyle = BorderStyle.FixedSingle;
            btnStrofa.Name = "focus";

            if (_screen != null)
            {

                formSecondMonitor.BindStrofa(btnStrofa.Text);
                formSecondMonitor.BringToFront();
                // deschide formularul de cantare pe monitorul 2 fullscreen
                ProiecteazaCantare(_screen.WorkingArea);

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
                foreach (Control ctl in flowStrofe.Controls)
                    ctl.ForeColor = Properties.Settings.Default.CuloareText;
                checkBoxLive.Checked = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formSecondMonitor != null)
                formSecondMonitor.Hide();
            if (_formBiblie != null)
                _formBiblie.Hide();

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
                for (int i = 0; i < flowStrofe.Controls.Count; i++)
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

                        AliniazaCeas();

                        formCeas.Show();
                    }
                    else
                        formCeas.Hide();
                }
                else MessageBox.Show("Numar invalid");
            }
            catch (Exception ex)
            {
                MessageBox.Show("DOAR CIFRE SUNT PERMISE");
            }
        }



        private void txtCautare_TextChanged(object sender, EventArgs e)
        {
            CautaDupaTitlu();
        }

        private void dgwlista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CantareFormatata cantare = (dgwlista.SelectedRows[0].DataBoundItem) as CantareFormatata;
            if (String.IsNullOrEmpty(cantare.Cantare.Versuri))
            {
               var cNet = CallAPIid(cantare.Cantare.Id);
                string[] words = cNet.cantec.ordine.Split(' ');
                foreach (var i in words)
                {
                    var str = cNet.cantec.continut.Where(x=>x.tip == i).SingleOrDefault().text;
                    cantare.ListaStrofe.Add(str.Replace("<br>", "\n")); ;
                }
                
            }
            CreazaSlide(cantare);
        }

        private void MeasureStringMin(object sender, EventArgs e)
        {
            Helper.MeasureStringMin((Label)sender, 20);
        }

        private void checkBoxBetel_CheckedChanged(object sender, EventArgs e)
        {
            BindCantari(_listcantari);
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

        private void txtCautareBiblia_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void AdaugaIstoric(Book carte, int capitol, int verset)
        {
            var button = new MyButton();
            button.Text = carte.short_name + " " + capitol + ":" + verset;
            button.Width = 150;
            button.Height = 30;
            button.Margin = new Padding(0);
            button.carte = carte;
            button.verset = verset;
            button.capitol = capitol;
            button.Click += (s, e) =>
            {
                CautaVerset(carte.book_number, capitol, verset - 1);
                BindingSource binding = new BindingSource();
                binding.DataSource = _listaVersete;
                dgvBiblia.DataSource = binding;
                dgvBiblia.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBiblia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                btnRef.Text = carte.short_name + " " + capitol + ":" + verset;
                //    dgvBiblia.Rows[verset-1].Selected = true;
                dgvBiblia.CurrentCell = dgvBiblia.Rows[verset - 1].Cells[0];

                dgvBiblia.Focus();

            };
            flowLayoutPanelIstoric.Controls.Add(button);
        }
        private void LoadCarti()
        {
            const string stringSqlBooks = "SELECT * FROM Books";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(stringSqlBooks, connection);

                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        int id = Convert.ToInt32(sqlReader["book_number"]);
                        string shortName = (string)sqlReader["short_name"];
                        string longName = (string)sqlReader["long_name"];

                        Book book = new Book(id, shortName, longName);

                        _listaCarti.Add(book);
                    }
                }

            }
        }
        private void BindCarti()
        {
            foreach (var carte in _listaCarti)
            {
                var ctrlCarte = new Button();
                ctrlCarte.Width = 170;
                ctrlCarte.Height = 35;
                ctrlCarte.Margin = new Padding(0);
                ctrlCarte.Text = carte.short_name;
                ctrlCarte.Name = carte.short_name;
                flowLayoutPanelBiblia.Controls.Add(ctrlCarte);
                flowLayoutPanelBiblia.AutoScroll = true;
                flowLayoutPanelBiblia.HorizontalScroll.Enabled = false;
                flowLayoutPanelBiblia.HorizontalScroll.Visible = false;
            }
        }
        private void CautaVerset(int carte, int capitol, int verset)
        {
            _listaVersete.Clear();
            string stringSql = "SELECT * FROM verses WHERE book_number=" + carte + " and chapter=" + capitol;


            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(stringSql, connection);

                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        int book_number = Convert.ToInt32(sqlReader["book_number"]);
                        int chapter = Convert.ToInt32(sqlReader["chapter"]);
                        int verse = Convert.ToInt32(sqlReader["verse"]);
                        string text = (string)sqlReader["text"];

                        text = Regex.Replace(text, "<.*?>", string.Empty);
                        text = Regex.Replace(text, "[.*]>", string.Empty);

                        text = Regex.Replace(text, @"[\u24D0-\u24E9]+", string.Empty);

                        Verses versett = new Verses(book_number, chapter, verse, text);

                        _listaVersete.Add(versett);
                    }
                }

            }
        }
        private void dgvBiblia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            AfisareBiblie();

        }
        private void AfisareBiblie()
        {

            if (dgvBiblia.SelectedRows.Count > 0 && checkBoxLive.Checked)
            {
                Verses verset = (dgvBiblia.SelectedRows[0].DataBoundItem) as Verses;
                if (_carte is null)
                    _carte = _listaCarti.Where(carte => carte.book_number == verset.book_number).SingleOrDefault();
                if (_formBiblie == null)
                {
                    _formBiblie = new FrmBiblie(_screen);

                    _formBiblie.StartPosition = FormStartPosition.Manual;
                    _formBiblie.Left = _screen.WorkingArea.Left + 10;
                    _formBiblie.Top = _screen.WorkingArea.Top + 10;
                    _formBiblie.Width = _screen.WorkingArea.Width + 10;
                    _formBiblie.Height = _screen.WorkingArea.Height + 10;
                    _formBiblie.WindowState = FormWindowState.Maximized;
                    _formBiblie.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

                }
                _formBiblie.Show();
                _formBiblie.BindVerset(_carte, verset);
                _formBiblie.BringToFront();
                this.BringToFront();

            }
        }
        private void dgvBiblia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (formSecondMonitor != null)
                    formSecondMonitor.Hide();
                if (_formBiblie != null)
                    _formBiblie.Hide();

                foreach (Label ctl in flowStrofe.Controls)
                    ctl.ForeColor = Color.White;
                checkBoxLive.Checked = false;

            }
            if (e.KeyCode == Keys.Enter)
            {
                checkBoxLive.Checked = true;
                AfisareBiblie();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxLive.Checked)
            {
                if (formSecondMonitor != null)
                    formSecondMonitor.Hide();
                if (_formBiblie != null)
                    _formBiblie.Hide();

                foreach (Control ctl in flowStrofe.Controls)
                    ctl.ForeColor = Properties.Settings.Default.CuloareText;
            }
            dgvBiblia.Focus();
        }

        private void dgvBiblia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            checkBoxLive.Checked = true;
            AfisareBiblie();
        }

        private void txtCautareBiblia_KeyUp(object sender, KeyEventArgs e)
        {
            _carte = null;
            try
            {

                string carteString = txtCautareBiblia.Text.Split()[0].ToLower();
                var ccarteString = carteString.Replace(" ", string.Empty);


                _carte = _listaCarti.Where(x => x.long_name.ToLower().StartsWith(ccarteString) || x.Short_name.ToLower().StartsWith(ccarteString)).FirstOrDefault();
                //                _carte = _listaCarti.Where(x => x.Short_name.ToLower().StartsWith(ccarteString)).FirstOrDefault();

                if (_carte != null)
                {
                    btnRef.Text = _carte.short_name;
                }
                else
                {
                    _carte = null;
                    btnRef.Text = "Cartea nu exista";
                }


                if (e.KeyCode == Keys.Enter)
                {
                    var txtCautare = Regex.Replace(txtCautareBiblia.Text.ToLower(), @"\s+", " ");
                    int refe = txtCautare.ToLower().Split().Length;
                    string[] referinta;
                    if (refe > 2)
                        referinta = txtCautare.ToLower().Split();
                    else
                        referinta = (txtCautare.ToLower() + " 1").Split();
                    int versetNumar = Convert.ToInt32(referinta[2]) - 1;


                    //_carte = _listaCarti.Where(x => x.long_name.ToLower().Contains(referinta[0]) || x.short_name.ToLower().Contains(referinta[0])).FirstOrDefault();
                    if (_carte != null)
                    {
                        btnRef.Text = btnRef.Text + " " + referinta[1];
                        CautaVerset(_carte.book_number, Convert.ToInt32(referinta[1]), Convert.ToInt32(referinta[2]));
                        BindingSource binding = new BindingSource();
                        binding.DataSource = _listaVersete;
                        dgvBiblia.DataSource = binding;
                        dgvBiblia.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dgvBiblia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgvBiblia.Rows[Convert.ToInt32(referinta[2]) - 1].Selected = true;
                        dgvBiblia.CurrentCell = dgvBiblia.Rows[versetNumar].Cells[0];
                        dgvBiblia.Focus();

                        AdaugaIstoric(_carte, Convert.ToInt32(referinta[1]), Convert.ToInt32(referinta[2]));

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare - VERIFICA CUM AI SCRIS");
            }
        }

        private void textBoxCautare_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CautareFraza();
            }
        }
        private void CautareFraza()
        {

            _listaVersete.Clear();
            string cuvant = textBoxCautare.Text;
            string stringSql = "SELECT * FROM verses WHERE text like '%" + cuvant + "%'";


            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(stringSql, connection);

                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        int book_number = Convert.ToInt32(sqlReader["book_number"]);
                        int chapter = Convert.ToInt32(sqlReader["chapter"]);
                        int verse = Convert.ToInt32(sqlReader["verse"]);
                        string text = (string)sqlReader["text"];

                        text = Regex.Replace(text, "<.*?>", string.Empty);
                        text = Regex.Replace(text, "[.*]>", string.Empty);

                        text = Regex.Replace(text, @"[\u24D0-\u24E9]+", string.Empty);

                        Verses versett = new Verses(book_number, chapter, verse, text);

                        _listaVersete.Add(versett);
                    }
                }
                BindingSource binding = new BindingSource();
                binding.DataSource = _listaVersete;
                dgvBiblia.DataSource = binding;
                dgvBiblia.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvBiblia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        #region CEAS
        private void txtLungimeCadru_Leave(object sender, EventArgs e)
        {
            AliniazaCeas();
        }

        private void txtLatimeCadru_Leave(object sender, EventArgs e)
        {
            AliniazaCeas();

        }

        private void radioButtonCentruCeas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCentruCeas.Checked == true)
            {
                aliniere = new Point(_screen.WorkingArea.Left + _screen.WorkingArea.Width / 2 - Properties.Settings.Default.LungimeCadruCeas / 2, _screen.WorkingArea.Height - Properties.Settings.Default.LatimeCadruCeas);
                if (formCeas != null)
                    formCeas.Location = aliniere;
            }
        }

        private void radioButtonStangaCeas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStangaCeas.Checked == true)
            {
                aliniere = new Point(_screen.WorkingArea.Left, _screen.WorkingArea.Height - Properties.Settings.Default.LatimeCadruCeas);
                if (formCeas != null)
                    formCeas.Location = aliniere;
            }
        }

        private void radioButtonDreaptaCeas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDreaptaCeas.Checked == true)
            {
                aliniere = new Point(_screen.WorkingArea.Left + _screen.WorkingArea.Width - Properties.Settings.Default.LungimeCadruCeas, _screen.WorkingArea.Height - Properties.Settings.Default.LatimeCadruCeas);
                if (formCeas != null)
                    formCeas.Location = aliniere;
            }

        }

        private void textBoxMarime_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default["MarimeCeas"] = Convert.ToInt32(textBoxMarime.Text);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            if (formCeas != null)
                formCeas.ModificaFont();
        }

        private void txtLungimeCadru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    AliniazaCeas();
                }
                catch
                { };
            }
        }
        private void AliniazaCeas()
        {
            Properties.Settings.Default["LatimeCadruCeas"] = Convert.ToInt32(txtLatimeCadru.Text);
            Properties.Settings.Default["LungimeCadruCeas"] = Convert.ToInt32(txtLungimeCadru.Text);
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            if (radioButtonCentruCeas.Checked == true)
            {
                aliniere = new Point(_screen.WorkingArea.Left + _screen.WorkingArea.Width / 2 - Properties.Settings.Default.LungimeCadruCeas / 2, _screen.WorkingArea.Height - Properties.Settings.Default.LatimeCadruCeas);
                formCeas.Location = aliniere;
            }
            if (radioButtonStangaCeas.Checked == true)
            {
                aliniere = new Point(_screen.WorkingArea.Left, _screen.WorkingArea.Height - Properties.Settings.Default.LatimeCadruCeas);
                formCeas.Location = aliniere;
            }
            if (radioButtonDreaptaCeas.Checked == true)
            {
                aliniere = new Point(_screen.WorkingArea.Left + _screen.WorkingArea.Width - Properties.Settings.Default.LungimeCadruCeas, _screen.WorkingArea.Height - Properties.Settings.Default.LatimeCadruCeas);
                formCeas.Location = aliniere;
            }

            formCeas.Width = Properties.Settings.Default.LungimeCadruCeas;
            formCeas.Height = Properties.Settings.Default.LatimeCadruCeas;


        }

        private void txtLatimeCadru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    AliniazaCeas();
                }
                catch
                { };
            }
        }

        private void txtLungimeCadru_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    AliniazaCeas();
                }
                catch
                { };
            }
        }


        private void btnCuloareFundalCeas_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;


            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["CuloareFundalCeas"] = colorDlg.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                if (formCeas != null)
                {
                    formCeas.ModificaFont();
                    formCeas.BackColor = Properties.Settings.Default.CuloareFundalCeas;
                }

            }
        }

        private void btnCuloareTextCeas_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.Red;


            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default["CuloareTextCeas"] = colorDlg.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                if (formCeas != null)
                    formCeas.ModificaFont();
            }
        }
        #endregion

        private void buttonCautaNet_Click(object sender, EventArgs e)
        {
            CautaPeNet();
        }
        private void CautaPeNet()
        {
            string numeDeCautatPeNet = textBoxNet.Text;
            CallAPINume();

        }
        public void CallAPINume()
        {
            WebClient _client = new WebClient();
            _client.BaseAddress = "https://www.resursecrestine.ro/ajax/api/proiectie/cauta-cantec?q=" + textBoxNet.Text;
            var response = _client.DownloadString("");
            var message = JsonConvert.DeserializeObject<cantarile>(response);
            List<Cantare> listcantari = new List<Cantare>();
            if (message.cantari != null)
            foreach (var cant in message.cantari)
            {
                listcantari.Add(new Cantare(Convert.ToInt32(cant.id), StripHTML(cant.text), "", 0));
            }
            else
                listcantari.Add(new Cantare(Convert.ToInt32(1), "Nu s-a gasit", "", 0));

            BindCantari(listcantari);

            //List<CantareNet> listCantariNet = JsonConvert.DeserializeObject<List<CantareNet>>(response);
            //foreach (var cantareNet in jsonCantariNet)
            //{
            //    Cantare cantare = new Cantare {
            //        Id = cantareNet.Key.ToString(),
            //        Versuri = cantareNet.Value.ToString();

            //    }
            //}

        }
        public genericCantare CallAPIid(int id)
        {
            WebClient _client = new WebClient();
            _client.BaseAddress = "https://www.resursecrestine.ro/ajax/api/proiectie/cere-cantec-dupa-id?id=" + id + "&subtitrari=false";
            var response = _client.DownloadString("");
            var cantare = JsonConvert.DeserializeObject<genericCantare>(response);
            return cantare;



            //  BindCantari(listcantari);

            //List<CantareNet> listCantariNet = JsonConvert.DeserializeObject<List<CantareNet>>(response);
            //foreach (var cantareNet in jsonCantariNet)
            //{
            //    Cantare cantare = new Cantare {
            //        Id = cantareNet.Key.ToString(),
            //        Versuri = cantareNet.Value.ToString();

            //    }
            //}

        }
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        private void textBoxNet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CautaPeNet();
            }
        }
    }
    public class MyButton : Button
    {
        public int verset { get; set; }
        public int capitol { get; set; }
        public Book carte { get; set; }
    }
    public class DoubleClickButton : Button
    {
        public DoubleClickButton()
        {
            SetStyle(ControlStyles.StandardClick |
ControlStyles.StandardDoubleClick, true);
        }
    }
}
