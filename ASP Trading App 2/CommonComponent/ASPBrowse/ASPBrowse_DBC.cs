using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using ASP_Trading_App_2.DBComponent;
using System.Windows.Forms;

namespace ASP_Trading_App_2.CommonComponent.ASPBrowse
{
    public class ASPBrowse_DBC
    {
        public ASPQuery aspQuery;

        private string TableName;
        private string FieldName;

        public ASPBrowse_DBC(string tableName)
        {
            this.TableName = tableName;
            aspQuery = new ASPQuery(this.TableName);
        }

        private void generateFieldName(List<string> fieldName)
        {
            FieldName = "";
            for (int i = 0; i < fieldName.Count; i++)
            {
                if (i == 0)
                {
                    FieldName = fieldName[i];
                }
                else if (i > 0)
                {
                    FieldName = FieldName + ", " + fieldName[i];
                }
            }
        }

        public BindingSource GetTable(string query)
        {
            BindingSource bindingSource = new BindingSource();
            string Query = "SELECT * FROM (\n" +
                           query +
                           ") TblLuar WHERE `Hapus` = 0 LIMIT 0,50";
            if (!aspQuery.Select(Query, ref bindingSource))
            {
                ASPMsgCmp.ErrorMessage("Fail to read get data from Browse Form!");
            }
            return bindingSource;
        }
    }
}
