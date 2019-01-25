namespace ASP_Trading_App_2.Forms.Master.General
{
    partial class ASPMKaryawanForm
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
            this.CbAktif = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EditNmMKaryawan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditKdMKaryawan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EditAlamat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EditKdMJabatan = new System.Windows.Forms.TextBox();
            this.EditNoHP = new System.Windows.Forms.MaskedTextBox();
            this.EditNmMJabatan = new System.Windows.Forms.TextBox();
            this.BtnBrowseJabatan = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.IdMKaryawan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KdMKaryawan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NmMKaryawan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMJabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NmMJabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktif = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoProgram)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditSearch
            // 
            this.EditSearch.TextChanged += new System.EventHandler(this.EditSearch_TextChanged);
            // 
            // CbOrder
            // 
            this.CbOrder.Items.AddRange(new object[] {
            "ASC",
            "DESC"});
            this.CbOrder.SelectionChangeCommitted += new System.EventHandler(this.CbOrder_SelectionChangeCommitted);
            // 
            // CbColumns
            // 
            this.CbColumns.SelectionChangeCommitted += new System.EventHandler(this.CbColumns_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Size = new System.Drawing.Size(800, 456);
            this.panel1.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.Controls.SetChildIndex(this.TitleForm, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.Controls.SetChildIndex(this.dataGridView, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(52, 222);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnBrowseJabatan);
            this.groupBox1.Controls.Add(this.EditNmMJabatan);
            this.groupBox1.Controls.Add(this.EditNoHP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.EditKdMJabatan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.EditAlamat);
            this.groupBox1.Controls.Add(this.CbAktif);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EditNmMKaryawan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EditKdMKaryawan);
            this.groupBox1.Size = new System.Drawing.Size(736, 163);
            // 
            // BtnExit
            // 
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnExit.Location = new System.Drawing.Point(1, 393);
            // 
            // BtnCancel
            // 
            this.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnCancel.Location = new System.Drawing.Point(1, 351);
            // 
            // BtnSave
            // 
            this.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnSave.Location = new System.Drawing.Point(1, 309);
            // 
            // BtnDelete
            // 
            this.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnDelete.Location = new System.Drawing.Point(1, 143);
            // 
            // BtnEdit
            // 
            this.BtnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnEdit.Location = new System.Drawing.Point(1, 100);
            // 
            // BtnNew
            // 
            this.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnNew.Location = new System.Drawing.Point(1, 57);
            // 
            // LogoProgram
            // 
            this.LogoProgram.Location = new System.Drawing.Point(1, 3);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(47, 455);
            // 
            // CbAktif
            // 
            this.CbAktif.AutoSize = true;
            this.CbAktif.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAktif.Location = new System.Drawing.Point(441, 56);
            this.CbAktif.Name = "CbAktif";
            this.CbAktif.Size = new System.Drawing.Size(56, 22);
            this.CbAktif.TabIndex = 7;
            this.CbAktif.Text = "Aktif";
            this.CbAktif.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nama";
            // 
            // EditNmMKaryawan
            // 
            this.EditNmMKaryawan.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNmMKaryawan.Location = new System.Drawing.Point(66, 56);
            this.EditNmMKaryawan.Name = "EditNmMKaryawan";
            this.EditNmMKaryawan.Size = new System.Drawing.Size(223, 23);
            this.EditNmMKaryawan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kode";
            // 
            // EditKdMKaryawan
            // 
            this.EditKdMKaryawan.BackColor = System.Drawing.SystemColors.Window;
            this.EditKdMKaryawan.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditKdMKaryawan.Location = new System.Drawing.Point(66, 27);
            this.EditKdMKaryawan.Name = "EditKdMKaryawan";
            this.EditKdMKaryawan.Size = new System.Drawing.Size(145, 23);
            this.EditKdMKaryawan.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Alamat";
            // 
            // EditAlamat
            // 
            this.EditAlamat.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditAlamat.Location = new System.Drawing.Point(66, 85);
            this.EditAlamat.Name = "EditAlamat";
            this.EditAlamat.Size = new System.Drawing.Size(303, 23);
            this.EditAlamat.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "No. HP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Jabatan";
            // 
            // EditKdMJabatan
            // 
            this.EditKdMJabatan.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditKdMJabatan.Location = new System.Drawing.Point(441, 27);
            this.EditKdMJabatan.Name = "EditKdMJabatan";
            this.EditKdMJabatan.Size = new System.Drawing.Size(82, 23);
            this.EditKdMJabatan.TabIndex = 4;
            this.EditKdMJabatan.Leave += new System.EventHandler(this.EditKdMJabatan_Leave);
            // 
            // EditNoHP
            // 
            this.EditNoHP.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNoHP.Location = new System.Drawing.Point(66, 115);
            this.EditNoHP.Mask = "0000-0000-00000";
            this.EditNoHP.Name = "EditNoHP";
            this.EditNoHP.Size = new System.Drawing.Size(131, 23);
            this.EditNoHP.TabIndex = 3;
            this.EditNoHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // EditNmMJabatan
            // 
            this.EditNmMJabatan.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNmMJabatan.Location = new System.Drawing.Point(525, 27);
            this.EditNmMJabatan.Name = "EditNmMJabatan";
            this.EditNmMJabatan.Size = new System.Drawing.Size(155, 23);
            this.EditNmMJabatan.TabIndex = 5;
            this.EditNmMJabatan.Leave += new System.EventHandler(this.EditNmMJabatan_Leave);
            // 
            // BtnBrowseJabatan
            // 
            this.BtnBrowseJabatan.Image = global::ASP_Trading_App_2.Properties.Resources.icons8_Search_16px;
            this.BtnBrowseJabatan.Location = new System.Drawing.Point(681, 27);
            this.BtnBrowseJabatan.Name = "BtnBrowseJabatan";
            this.BtnBrowseJabatan.Size = new System.Drawing.Size(28, 23);
            this.BtnBrowseJabatan.TabIndex = 6;
            this.BtnBrowseJabatan.UseVisualStyleBackColor = true;
            this.BtnBrowseJabatan.Click += new System.EventHandler(this.BtnBrowseJabatan_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMKaryawan,
            this.No,
            this.KdMKaryawan,
            this.NmMKaryawan,
            this.IdMJabatan,
            this.NmMJabatan,
            this.Alamat,
            this.NoHP,
            this.Aktif});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.Location = new System.Drawing.Point(256, 222);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(532, 223);
            this.dataGridView.TabIndex = 5;
            // 
            // IdMKaryawan
            // 
            this.IdMKaryawan.HeaderText = "Id";
            this.IdMKaryawan.Name = "IdMKaryawan";
            this.IdMKaryawan.ReadOnly = true;
            this.IdMKaryawan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdMKaryawan.Visible = false;
            this.IdMKaryawan.Width = 24;
            // 
            // No
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.No.DefaultCellStyle = dataGridViewCellStyle1;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 31;
            // 
            // KdMKaryawan
            // 
            this.KdMKaryawan.HeaderText = "Kode";
            this.KdMKaryawan.Name = "KdMKaryawan";
            this.KdMKaryawan.ReadOnly = true;
            this.KdMKaryawan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KdMKaryawan.Width = 38;
            // 
            // NmMKaryawan
            // 
            this.NmMKaryawan.HeaderText = "Nama";
            this.NmMKaryawan.Name = "NmMKaryawan";
            this.NmMKaryawan.ReadOnly = true;
            this.NmMKaryawan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NmMKaryawan.Width = 41;
            // 
            // IdMJabatan
            // 
            this.IdMJabatan.HeaderText = "IdMJabatan";
            this.IdMJabatan.Name = "IdMJabatan";
            this.IdMJabatan.ReadOnly = true;
            this.IdMJabatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdMJabatan.Visible = false;
            this.IdMJabatan.Width = 72;
            // 
            // NmMJabatan
            // 
            this.NmMJabatan.HeaderText = "Jabatan";
            this.NmMJabatan.Name = "NmMJabatan";
            this.NmMJabatan.ReadOnly = true;
            this.NmMJabatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NmMJabatan.Width = 54;
            // 
            // Alamat
            // 
            this.Alamat.HeaderText = "Alamat";
            this.Alamat.Name = "Alamat";
            this.Alamat.ReadOnly = true;
            this.Alamat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Alamat.Width = 47;
            // 
            // NoHP
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NoHP.DefaultCellStyle = dataGridViewCellStyle2;
            this.NoHP.HeaderText = "No. HP";
            this.NoHP.Name = "NoHP";
            this.NoHP.ReadOnly = true;
            this.NoHP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NoHP.Width = 47;
            // 
            // Aktif
            // 
            this.Aktif.HeaderText = "Aktif";
            this.Aktif.Name = "Aktif";
            this.Aktif.ReadOnly = true;
            this.Aktif.Width = 38;
            // 
            // ASPMKaryawanForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.ControlBox = false;
            this.Name = "ASPMKaryawanForm";
            this.ShowInTaskbar = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ASPMKaryawanForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoProgram)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox CbAktif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EditNmMKaryawan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EditKdMKaryawan;
        private System.Windows.Forms.TextBox EditNmMJabatan;
        private System.Windows.Forms.MaskedTextBox EditNoHP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EditKdMJabatan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EditAlamat;
        private System.Windows.Forms.Button BtnBrowseJabatan;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMKaryawan;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn KdMKaryawan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NmMKaryawan;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMJabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NmMJabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoHP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktif;
    }
}
