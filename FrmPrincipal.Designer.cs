namespace ProiectareCantari
{
    partial class FrmPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxClock = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMarime = new System.Windows.Forms.TextBox();
            this.textBoxMarimeCantari = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnCuloareFundal = new System.Windows.Forms.Button();
            this.btnCuloareText = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCANTARI = new System.Windows.Forms.TabPage();
            this.checkBoxBetel = new System.Windows.Forms.CheckBox();
            this.dgwlista = new System.Windows.Forms.DataGridView();
            this.labelTitlu = new System.Windows.Forms.Label();
            this.btnAdaugaCantareNoua = new System.Windows.Forms.Button();
            this.buttonModifica = new System.Windows.Forms.Button();
            this.flowStrofe = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.btnSterge = new System.Windows.Forms.Button();
            this.tabPageBiblia = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBiblia = new System.Windows.Forms.DataGridView();
            this.txtCautareBiblia = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanelBiblia = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRef = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageCANTARI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwlista)).BeginInit();
            this.tabPageBiblia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiblia)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(909, 278);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 74);
            this.button1.TabIndex = 3;
            this.button1.Text = "Opreste Vizualizarea";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button1_KeyDown);
            // 
            // checkBoxClock
            // 
            this.checkBoxClock.AutoSize = true;
            this.checkBoxClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxClock.Location = new System.Drawing.Point(895, 492);
            this.checkBoxClock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxClock.Name = "checkBoxClock";
            this.checkBoxClock.Size = new System.Drawing.Size(131, 28);
            this.checkBoxClock.TabIndex = 4;
            this.checkBoxClock.Text = "Afisare ceas";
            this.checkBoxClock.UseVisualStyleBackColor = true;
            this.checkBoxClock.CheckedChanged += new System.EventHandler(this.checkBoxClock_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(900, 534);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Marime:";
            // 
            // textBoxMarime
            // 
            this.textBoxMarime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarime.Location = new System.Drawing.Point(980, 534);
            this.textBoxMarime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMarime.Name = "textBoxMarime";
            this.textBoxMarime.Size = new System.Drawing.Size(41, 29);
            this.textBoxMarime.TabIndex = 6;
            this.textBoxMarime.Text = "48";
            this.textBoxMarime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMarime_KeyDown);
            // 
            // textBoxMarimeCantari
            // 
            this.textBoxMarimeCantari.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarimeCantari.Location = new System.Drawing.Point(984, 35);
            this.textBoxMarimeCantari.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMarimeCantari.Name = "textBoxMarimeCantari";
            this.textBoxMarimeCantari.Size = new System.Drawing.Size(41, 29);
            this.textBoxMarimeCantari.TabIndex = 8;
            this.textBoxMarimeCantari.Text = "72";
            this.textBoxMarimeCantari.Visible = false;
            this.textBoxMarimeCantari.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMarimeCantari_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(905, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Marime:";
            this.label2.Visible = false;
            // 
            // btnCuloareFundal
            // 
            this.btnCuloareFundal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuloareFundal.Location = new System.Drawing.Point(904, 86);
            this.btnCuloareFundal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCuloareFundal.Name = "btnCuloareFundal";
            this.btnCuloareFundal.Size = new System.Drawing.Size(134, 35);
            this.btnCuloareFundal.TabIndex = 9;
            this.btnCuloareFundal.Text = "Culoare Fundal";
            this.btnCuloareFundal.UseVisualStyleBackColor = true;
            this.btnCuloareFundal.Click += new System.EventHandler(this.btnCuloareFundal_Click);
            // 
            // btnCuloareText
            // 
            this.btnCuloareText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuloareText.Location = new System.Drawing.Point(904, 126);
            this.btnCuloareText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCuloareText.Name = "btnCuloareText";
            this.btnCuloareText.Size = new System.Drawing.Size(134, 35);
            this.btnCuloareText.TabIndex = 10;
            this.btnCuloareText.Text = "Culoare Text";
            this.btnCuloareText.UseVisualStyleBackColor = true;
            this.btnCuloareText.Click += new System.EventHandler(this.btnCuloareText_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBiblia);
            this.tabControl1.Controls.Add(this.tabPageCANTARI);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(9, 10);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(882, 604);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPageCANTARI
            // 
            this.tabPageCANTARI.Controls.Add(this.checkBoxBetel);
            this.tabPageCANTARI.Controls.Add(this.dgwlista);
            this.tabPageCANTARI.Controls.Add(this.labelTitlu);
            this.tabPageCANTARI.Controls.Add(this.btnAdaugaCantareNoua);
            this.tabPageCANTARI.Controls.Add(this.buttonModifica);
            this.tabPageCANTARI.Controls.Add(this.flowStrofe);
            this.tabPageCANTARI.Controls.Add(this.txtCautare);
            this.tabPageCANTARI.Controls.Add(this.btnSterge);
            this.tabPageCANTARI.Location = new System.Drawing.Point(4, 29);
            this.tabPageCANTARI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCANTARI.Name = "tabPageCANTARI";
            this.tabPageCANTARI.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageCANTARI.Size = new System.Drawing.Size(613, 571);
            this.tabPageCANTARI.TabIndex = 1;
            this.tabPageCANTARI.Text = "Lista Cantari";
            this.tabPageCANTARI.UseVisualStyleBackColor = true;
            // 
            // checkBoxBetel
            // 
            this.checkBoxBetel.AutoSize = true;
            this.checkBoxBetel.Checked = true;
            this.checkBoxBetel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBetel.Location = new System.Drawing.Point(239, 15);
            this.checkBoxBetel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxBetel.Name = "checkBoxBetel";
            this.checkBoxBetel.Size = new System.Drawing.Size(79, 24);
            this.checkBoxBetel.TabIndex = 8;
            this.checkBoxBetel.Text = "BETEL";
            this.checkBoxBetel.UseVisualStyleBackColor = true;
            this.checkBoxBetel.CheckedChanged += new System.EventHandler(this.checkBoxBetel_CheckedChanged);
            // 
            // dgwlista
            // 
            this.dgwlista.AllowUserToAddRows = false;
            this.dgwlista.AllowUserToDeleteRows = false;
            this.dgwlista.AllowUserToResizeColumns = false;
            this.dgwlista.AllowUserToResizeRows = false;
            this.dgwlista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwlista.ColumnHeadersHeight = 29;
            this.dgwlista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgwlista.ColumnHeadersVisible = false;
            this.dgwlista.EnableHeadersVisualStyles = false;
            this.dgwlista.Location = new System.Drawing.Point(15, 54);
            this.dgwlista.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgwlista.MultiSelect = false;
            this.dgwlista.Name = "dgwlista";
            this.dgwlista.ReadOnly = true;
            this.dgwlista.RowHeadersVisible = false;
            this.dgwlista.RowHeadersWidth = 51;
            this.dgwlista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgwlista.RowTemplate.Height = 24;
            this.dgwlista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwlista.Size = new System.Drawing.Size(300, 427);
            this.dgwlista.TabIndex = 7;
            this.dgwlista.VirtualMode = true;
            this.dgwlista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwlista_CellDoubleClick);
            // 
            // labelTitlu
            // 
            this.labelTitlu.Location = new System.Drawing.Point(349, 13);
            this.labelTitlu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitlu.Name = "labelTitlu";
            this.labelTitlu.Size = new System.Drawing.Size(150, 24);
            this.labelTitlu.TabIndex = 6;
            this.labelTitlu.Text = "TITLU CANTARII";
            this.labelTitlu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdaugaCantareNoua
            // 
            this.btnAdaugaCantareNoua.Location = new System.Drawing.Point(27, 531);
            this.btnAdaugaCantareNoua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdaugaCantareNoua.Name = "btnAdaugaCantareNoua";
            this.btnAdaugaCantareNoua.Size = new System.Drawing.Size(281, 37);
            this.btnAdaugaCantareNoua.TabIndex = 5;
            this.btnAdaugaCantareNoua.Text = "Adauga Cantare noua";
            this.btnAdaugaCantareNoua.UseVisualStyleBackColor = true;
            this.btnAdaugaCantareNoua.Click += new System.EventHandler(this.AdaugaCantareNoua_Click);
            // 
            // buttonModifica
            // 
            this.buttonModifica.Location = new System.Drawing.Point(27, 498);
            this.buttonModifica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonModifica.Name = "buttonModifica";
            this.buttonModifica.Size = new System.Drawing.Size(88, 28);
            this.buttonModifica.TabIndex = 4;
            this.buttonModifica.Text = "Modifica";
            this.buttonModifica.UseVisualStyleBackColor = true;
            this.buttonModifica.Click += new System.EventHandler(this.buttonModifica_Click);
            // 
            // flowStrofe
            // 
            this.flowStrofe.AutoScroll = true;
            this.flowStrofe.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowStrofe.Location = new System.Drawing.Point(337, 52);
            this.flowStrofe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowStrofe.Name = "flowStrofe";
            this.flowStrofe.Size = new System.Drawing.Size(260, 516);
            this.flowStrofe.TabIndex = 3;
            this.flowStrofe.WrapContents = false;
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(10, 14);
            this.txtCautare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(218, 26);
            this.txtCautare.TabIndex = 2;
            this.txtCautare.TextChanged += new System.EventHandler(this.txtCautare_TextChanged);
            // 
            // btnSterge
            // 
            this.btnSterge.Location = new System.Drawing.Point(202, 498);
            this.btnSterge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(106, 28);
            this.btnSterge.TabIndex = 1;
            this.btnSterge.Text = "STERGE";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // tabPageBiblia
            // 
            this.tabPageBiblia.Controls.Add(this.btnRef);
            this.tabPageBiblia.Controls.Add(this.flowLayoutPanelBiblia);
            this.tabPageBiblia.Controls.Add(this.label3);
            this.tabPageBiblia.Controls.Add(this.dgvBiblia);
            this.tabPageBiblia.Controls.Add(this.txtCautareBiblia);
            this.tabPageBiblia.Location = new System.Drawing.Point(4, 29);
            this.tabPageBiblia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageBiblia.Name = "tabPageBiblia";
            this.tabPageBiblia.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageBiblia.Size = new System.Drawing.Size(874, 571);
            this.tabPageBiblia.TabIndex = 0;
            this.tabPageBiblia.Text = "BIBLIA";
            this.tabPageBiblia.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exemplu: Mat 3 5";
            // 
            // dgvBiblia
            // 
            this.dgvBiblia.AllowUserToAddRows = false;
            this.dgvBiblia.AllowUserToDeleteRows = false;
            this.dgvBiblia.AllowUserToResizeColumns = false;
            this.dgvBiblia.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBiblia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBiblia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBiblia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvBiblia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBiblia.ColumnHeadersVisible = false;
            this.dgvBiblia.Location = new System.Drawing.Point(255, 120);
            this.dgvBiblia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBiblia.MultiSelect = false;
            this.dgvBiblia.Name = "dgvBiblia";
            this.dgvBiblia.ReadOnly = true;
            this.dgvBiblia.RowHeadersVisible = false;
            this.dgvBiblia.RowHeadersWidth = 51;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBiblia.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBiblia.RowTemplate.Height = 24;
            this.dgvBiblia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBiblia.Size = new System.Drawing.Size(590, 376);
            this.dgvBiblia.TabIndex = 1;
            this.dgvBiblia.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBiblia_RowEnter);
            this.dgvBiblia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBiblia_KeyDown);
            // 
            // txtCautareBiblia
            // 
            this.txtCautareBiblia.Location = new System.Drawing.Point(48, 44);
            this.txtCautareBiblia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCautareBiblia.Name = "txtCautareBiblia";
            this.txtCautareBiblia.Size = new System.Drawing.Size(196, 26);
            this.txtCautareBiblia.TabIndex = 0;
            this.txtCautareBiblia.TextChanged += new System.EventHandler(this.txtCautareBiblia_TextChanged);
            this.txtCautareBiblia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCautareBiblia_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(613, 571);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cantari INTERNET";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(19, 67);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(300, 427);
            this.dataGridView1.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 26);
            this.textBox1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(465, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 41);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanelBiblia
            // 
            this.flowLayoutPanelBiblia.AutoScroll = true;
            this.flowLayoutPanelBiblia.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelBiblia.Location = new System.Drawing.Point(27, 120);
            this.flowLayoutPanelBiblia.Name = "flowLayoutPanelBiblia";
            this.flowLayoutPanelBiblia.Size = new System.Drawing.Size(200, 376);
            this.flowLayoutPanelBiblia.TabIndex = 3;
            this.flowLayoutPanelBiblia.WrapContents = false;
            // 
            // btnRef
            // 
            this.btnRef.Location = new System.Drawing.Point(434, 78);
            this.btnRef.Name = "btnRef";
            this.btnRef.Size = new System.Drawing.Size(247, 27);
            this.btnRef.TabIndex = 4;
            this.btnRef.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 775);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCuloareText);
            this.Controls.Add(this.btnCuloareFundal);
            this.Controls.Add(this.textBoxMarimeCantari);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMarime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxClock);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Afisare Cantari   - by Cristty";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrincipal_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCANTARI.ResumeLayout(false);
            this.tabPageCANTARI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwlista)).EndInit();
            this.tabPageBiblia.ResumeLayout(false);
            this.tabPageBiblia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiblia)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxClock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMarime;
        private System.Windows.Forms.TextBox textBoxMarimeCantari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnCuloareFundal;
        private System.Windows.Forms.Button btnCuloareText;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBiblia;
        private System.Windows.Forms.TabPage tabPageCANTARI;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.FlowLayoutPanel flowStrofe;
        private System.Windows.Forms.Button buttonModifica;
        private System.Windows.Forms.Button btnAdaugaCantareNoua;
        private System.Windows.Forms.Label labelTitlu;
        private System.Windows.Forms.DataGridView dgwlista;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBoxBetel;
        private System.Windows.Forms.DataGridView dgvBiblia;
        private System.Windows.Forms.TextBox txtCautareBiblia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBiblia;
        private System.Windows.Forms.Button btnRef;
    }
}