using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using ASP_Trading_App_2.CommonComponent;

namespace ASP_Trading_App_2.CommonComponent.ASPBrowse
{    
    public partial class ASPBrowseForm : Form
    {
        public bool Select;
        public string ColumnSearch;
        public string ValueSearch;
        public string Condition;
        public string Query;

        public string Result = "";
        public string Result2 = "";
        public string Result3 = "";
        public string Result4 = "";
        public string Result5 = "";

        public string FieldResult = "";
        public string FieldResult2 = "";
        public string FieldResult3 = "";
        public string FieldResult4 = "";
        public string FieldResult5 = "";

        private ASPBrowse_DBC GDBBrowse;
        private List<string> fieldName;

        private List<KeyValuePair<string, string>> HeaderTextSet;
        private List<KeyValuePair<string, int>> WidthSet;
        private List<KeyValuePair<string, bool>> VisibleSet;

        public ASPBrowseForm(string tableName)
        {
            InitializeComponent();
            Select = false;
            GDBBrowse = new ASPBrowse_DBC(tableName);
            fieldName = new List<string>();
            HeaderTextSet = new List<KeyValuePair<string, string>>();
            WidthSet = new List<KeyValuePair<string, int>>();
            VisibleSet = new List<KeyValuePair<string, bool>>();
            ColumnSearch = "";
            ValueSearch = "";
            Condition = "";
            Query = "";
        }

        public void AddColumn(string columnName, string headerText, int width, Type type, bool isVisible = true)
        {
            HeaderTextSet.Add(new KeyValuePair<string, string>(columnName, headerText));
            WidthSet.Add(new KeyValuePair<string, int>(columnName, width));
            VisibleSet.Add(new KeyValuePair<string, bool>(columnName, isVisible));
        }

        private void GetResult(int rowIndex)
        {
            DataGridViewRow row = BrowseGrid.Rows[rowIndex];
            if (!FieldResult.Equals(""))
            {
                Result = row.Cells[FieldResult].Value.ToString();
            }

            if (!FieldResult2.Equals(""))
            {
                Result2 = row.Cells[FieldResult2].Value.ToString();
            }

            if (!FieldResult3.Equals(""))
            {
                Result3 = row.Cells[FieldResult3].Value.ToString();
            }

            if (!FieldResult4.Equals(""))
            {
                Result4 = row.Cells[FieldResult4].Value.ToString();
            }

            if (!FieldResult5.Equals(""))
            {
                Result5 = row.Cells[FieldResult5].Value.ToString();
            }
        }

        private void GetTable()
        {
            BrowseGrid.DataSource = null;
            BrowseGrid.Refresh();

            Condition = "  WHERE " + ColumnSearch + " LIKE " + ASPCast.SQLStr("%" + ValueSearch + "%");

            BrowseGrid.DataSource = GDBBrowse.GetTable(Query + Condition);
            TableSetting();
            BrowseGrid.FirstDisplayedCell.Selected = true;
            
            GDBBrowse.aspQuery.MySqlConnect.CloseConnection();
        }

        private void TableSetting()
        {
            // Setting Nama Kolom & Short Mode
            foreach (KeyValuePair<string, string> header in HeaderTextSet)
            {
                BrowseGrid.Columns[header.Key].HeaderText = header.Value;
                BrowseGrid.Columns[header.Key].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Setting Lebar Kolom
            foreach (KeyValuePair<string, int> width in WidthSet)
            {
                BrowseGrid.Columns[width.Key].Width = width.Value;
            }

            // Setting Visibilitas Kolom
            foreach (KeyValuePair<string, bool> visible in VisibleSet)
            {
                BrowseGrid.Columns[visible.Key].Visible = visible.Value;
            }

            // Setting Visibilitas Kolom yang tidak disebutkan pada init browse
            for (int i = 0; i < BrowseGrid.Columns.Count; i++)
            {
                if (!HeaderTextSet.Contains(new KeyValuePair<string, string>(BrowseGrid.Columns[i].Name, BrowseGrid.Columns[i].HeaderText)))
                {
                    BrowseGrid.Columns[i].Visible = false;
                }
            }
        }

        private void ASPBrowseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Dispose();
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (BrowseGrid.SelectedRows.Count > 0)
                {
                    Select = true;
                    GetResult(BrowseGrid.CurrentCell.RowIndex);
                    Dispose();
                }
            }

            if (e.KeyData == (Keys.Control | Keys.F))
            {
                BrowseFind findForm = new BrowseFind();
                ASPComboboxItem.GenerateComboboxColumn(ref findForm.CbColumn, ref BrowseGrid);
                findForm.ShowDialog(this);
                if (findForm.Find)
                {
                    ColumnSearch = findForm.columnSearch;
                    ValueSearch = findForm.valueSearch;
                    GetTable();
                }
            }
        }

        private void ASPBrowseForm_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void BrowseGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Select = true;
            GetResult(BrowseGrid.CurrentCell.RowIndex);
            Dispose();
        }
    }
}
