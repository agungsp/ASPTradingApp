namespace ASP_Trading_App_2.CommonComponent.ASPBrowse
{
    partial class BrowseFind
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CbColumn = new System.Windows.Forms.ComboBox();
            this.EditSearch = new System.Windows.Forms.TextBox();
            this.BtnFind = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.panel1.Controls.Add(this.BtnFind);
            this.panel1.Controls.Add(this.EditSearch);
            this.panel1.Controls.Add(this.CbColumn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 133);
            this.panel1.TabIndex = 0;
            // 
            // CbColumn
            // 
            this.CbColumn.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbColumn.FormattingEnabled = true;
            this.CbColumn.Location = new System.Drawing.Point(12, 26);
            this.CbColumn.Name = "CbColumn";
            this.CbColumn.Size = new System.Drawing.Size(96, 24);
            this.CbColumn.TabIndex = 0;
            // 
            // EditSearch
            // 
            this.EditSearch.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSearch.Location = new System.Drawing.Point(114, 27);
            this.EditSearch.Name = "EditSearch";
            this.EditSearch.Size = new System.Drawing.Size(225, 23);
            this.EditSearch.TabIndex = 1;
            // 
            // BtnFind
            // 
            this.BtnFind.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFind.Image = global::ASP_Trading_App_2.Properties.Resources.icons8_Search_16px;
            this.BtnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFind.Location = new System.Drawing.Point(258, 57);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(81, 42);
            this.BtnFind.TabIndex = 2;
            this.BtnFind.Text = "Find";
            this.BtnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnFind.UseVisualStyleBackColor = true;
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // BrowseFind
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(351, 113);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrowseFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BrowseFind_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.TextBox EditSearch;
        public System.Windows.Forms.ComboBox CbColumn;
    }
}