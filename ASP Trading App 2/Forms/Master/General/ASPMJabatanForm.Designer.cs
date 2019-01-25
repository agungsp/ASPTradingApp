namespace ASP_Trading_App_2.Forms.Master.General
{
    partial class ASPMJabatanForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.EditKdMJabatan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EditNmMJabatan = new System.Windows.Forms.TextBox();
            this.CbAktif = new System.Windows.Forms.CheckBox();
            this.IdMJabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KdMJabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NmMJabatan = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.CbOrder.TextChanged += new System.EventHandler(this.EditSearch_TextChanged);
            // 
            // CbColumns
            // 
            this.CbColumns.SelectionChangeCommitted += new System.EventHandler(this.CbColumns_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Size = new System.Drawing.Size(617, 411);
            this.panel1.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox2, 0);
            this.panel1.Controls.SetChildIndex(this.TitleForm, 0);
            this.panel1.Controls.SetChildIndex(this.dataGridView, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbAktif);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EditNmMJabatan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.EditKdMJabatan);
            this.groupBox1.Size = new System.Drawing.Size(551, 136);
            // 
            // BtnExit
            // 
            this.BtnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnExit.Location = new System.Drawing.Point(1, 359);
            this.BtnExit.Size = new System.Drawing.Size(44, 43);
            // 
            // BtnCancel
            // 
            this.BtnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnCancel.Location = new System.Drawing.Point(1, 314);
            this.BtnCancel.Size = new System.Drawing.Size(44, 43);
            // 
            // BtnSave
            // 
            this.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnSave.Location = new System.Drawing.Point(1, 269);
            this.BtnSave.Size = new System.Drawing.Size(44, 43);
            // 
            // BtnDelete
            // 
            this.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            // 
            // BtnEdit
            // 
            this.BtnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnEdit.Location = new System.Drawing.Point(1, 100);
            // 
            // BtnNew
            // 
            this.BtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(81)))));
            this.BtnNew.Location = new System.Drawing.Point(1, 55);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(48, 410);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMJabatan,
            this.No,
            this.KdMJabatan,
            this.NmMJabatan,
            this.Aktif});
            this.dataGridView.Location = new System.Drawing.Point(255, 195);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(348, 204);
            this.dataGridView.TabIndex = 5;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // EditKdMJabatan
            // 
            this.EditKdMJabatan.BackColor = System.Drawing.SystemColors.Window;
            this.EditKdMJabatan.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditKdMJabatan.Location = new System.Drawing.Point(66, 29);
            this.EditKdMJabatan.Name = "EditKdMJabatan";
            this.EditKdMJabatan.Size = new System.Drawing.Size(145, 23);
            this.EditKdMJabatan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nama";
            // 
            // EditNmMJabatan
            // 
            this.EditNmMJabatan.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditNmMJabatan.Location = new System.Drawing.Point(66, 58);
            this.EditNmMJabatan.Name = "EditNmMJabatan";
            this.EditNmMJabatan.Size = new System.Drawing.Size(223, 23);
            this.EditNmMJabatan.TabIndex = 2;
            // 
            // CbAktif
            // 
            this.CbAktif.AutoSize = true;
            this.CbAktif.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAktif.Location = new System.Drawing.Point(66, 87);
            this.CbAktif.Name = "CbAktif";
            this.CbAktif.Size = new System.Drawing.Size(56, 22);
            this.CbAktif.TabIndex = 4;
            this.CbAktif.Text = "Aktif";
            this.CbAktif.UseVisualStyleBackColor = true;
            // 
            // IdMJabatan
            // 
            this.IdMJabatan.HeaderText = "Id";
            this.IdMJabatan.Name = "IdMJabatan";
            this.IdMJabatan.ReadOnly = true;
            this.IdMJabatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IdMJabatan.Visible = false;
            this.IdMJabatan.Width = 24;
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
            // KdMJabatan
            // 
            this.KdMJabatan.HeaderText = "Kode";
            this.KdMJabatan.Name = "KdMJabatan";
            this.KdMJabatan.ReadOnly = true;
            this.KdMJabatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KdMJabatan.Width = 38;
            // 
            // NmMJabatan
            // 
            this.NmMJabatan.HeaderText = "Nama";
            this.NmMJabatan.Name = "NmMJabatan";
            this.NmMJabatan.ReadOnly = true;
            this.NmMJabatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NmMJabatan.Width = 41;
            // 
            // Aktif
            // 
            this.Aktif.HeaderText = "Aktif";
            this.Aktif.Name = "Aktif";
            this.Aktif.ReadOnly = true;
            this.Aktif.Width = 38;
            // 
            // ASPMJabatanForm
            // 
            this.ClientSize = new System.Drawing.Size(617, 411);
            this.ControlBox = false;
            this.Name = "ASPMJabatanForm";
            this.ShowInTaskbar = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ASPMJabatanForm_KeyDown);
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

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox CbAktif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EditNmMJabatan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EditKdMJabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMJabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn KdMJabatan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NmMJabatan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktif;
    }
}
