using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASP_Trading_App_2.CommonComponent.ASPBrowse
{
    public partial class BrowseFind : Form
    {
        public string columnSearch;
        public string valueSearch;
        public bool Find;
        public BrowseFind()
        {
            InitializeComponent();
            columnSearch = "";
            valueSearch = "";
            Find = false;
        }

        private void DoFind()
        {
            columnSearch = CbColumn.SelectedValue.ToString();
            valueSearch = EditSearch.Text.Trim();
            Find = true;
            Dispose();
        }

        private void BrowseFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoFind();
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            DoFind();
        }
    }
}
