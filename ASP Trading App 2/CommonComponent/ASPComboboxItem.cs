using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASP_Trading_App_2.CommonComponent
{
    public class ASPComboboxItem
    {
        public static void GenerateComboboxColumn(ref ComboBox comboBox, ref DataGridView dataGrid)
        {
            int len = dataGrid.Columns.Count;
            List<KeyValuePair<string, string>> items = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < len; i++)
            {
                if (dataGrid.Columns[i].Visible)
                {
                    items.Add(new KeyValuePair<string, string>(dataGrid.Columns[i].Name, dataGrid.Columns[i].HeaderText));
                }
            }

            comboBox.DataSource = null;
            comboBox.DataSource = new BindingSource(items, null);
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value"; // yang tampil ke user
        }
    }
}
