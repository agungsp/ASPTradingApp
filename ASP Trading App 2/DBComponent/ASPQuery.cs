using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using ASP_Trading_App_2.CommonComponent;
using System.Data;

namespace ASP_Trading_App_2.DBComponent
{
    public class ASPQuery
    {
        public DBConnection MySqlConnect;
        private String TableName;
        private MySqlCommand Command;
        private MySqlTransaction Transaction;

        public ASPQuery(string tableName)
        {
            MySqlConnect = new DBConnection();
            TableName = tableName;
            Command = MySqlConnect.connection.CreateCommand();
        }

        public void StartTransaction()
        {
            Transaction = MySqlConnect.connection.BeginTransaction();
            Command.Transaction = Transaction;
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public bool ExecCUD(String query)
        {
            bool Result = true;
            if (!MySqlConnect.IsOpen)
            {
                MySqlConnect.OpenConnection();
            }
            try
            {
                Command.Connection = MySqlConnect.connection;
                Command.CommandText = query;
                Command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Result = false;
            }

            return Result;
        }

        public bool Select(String query, ref MySqlDataReader dataReader)
        {
            bool Result = true;
            Command.Connection = MySqlConnect.connection;
            if (!MySqlConnect.IsOpen)
            {
                MySqlConnect.OpenConnection();
            }
            try
            {
                Command.CommandText = query;
                dataReader = Command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                ASPMsgCmp.WarningMessage(ex.Message);
                Result = false;
            }

            return Result;
        }

        public bool Select(String query, ref BindingSource bindingSource)
        {
            bool Result = true;
            MySqlDataAdapter adapter;
            DataTable dataTable = new DataTable();
            if (!MySqlConnect.IsOpen)
            {
                MySqlConnect.OpenConnection();
            }
            try
            {
                adapter = new MySqlDataAdapter(query, MySqlConnect.connection);
                adapter.Fill(dataTable);
                bindingSource.DataSource = dataTable;
            }
            catch (MySqlException ex)
            {
                ASPMsgCmp.WarningMessage(ex.Message);
                Result = false;
            }

            return Result;
        }

        public bool Find(String condition)
        {
            MySqlDataReader dataReader;
            bool Result = true;
            Command.Connection = MySqlConnect.connection;
            if (!MySqlConnect.IsOpen)
            {
                MySqlConnect.OpenConnection();
            }
            try
            {
                Command.CommandText = "SELECT COUNT(*) AS `Row` FROM " + this.TableName + " WHERE " + condition;
                dataReader = Command.ExecuteReader();
                dataReader.Read();
                if (dataReader.GetInt16("Row") <= 0)
                {
                    Result = false;
                }
            }
            catch (MySqlException ex)
            {
                Result = false;
            }

            if (MySqlConnect.IsOpen)
            {
                MySqlConnect.CloseConnection();
            }

            return Result;
        }

        public int GetNewId(String columnId)
        {
            MySqlDataReader dataReader;
            int Result = 0;
            String query = "SELECT (IF(COUNT(" + columnId + ") = 0, 0, MAX(" + columnId + ")) + 1) AS `NewId` FROM " + TableName;

            Command.Connection = MySqlConnect.connection;
            if (!MySqlConnect.IsOpen)
            {
                MySqlConnect.OpenConnection();
            }
            try
            {
                Command.CommandText = query;
                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    Result = dataReader.GetInt32("NewId");
                }
            }
            catch (MySqlException ex)
            {

            }

            if (MySqlConnect.IsOpen)
            {
                MySqlConnect.CloseConnection();
            }

            return Result;
        }

        public MySqlDateTime DbDateNow()
        {
            MySqlDataReader dataReader;
            MySqlDateTime Result = new MySqlDateTime();
            String query = "SELECT NOW() AS `Now`";

            Command.Connection = MySqlConnect.connection;
            if (!MySqlConnect.IsOpen)
            {
                MySqlConnect.OpenConnection();
            }
            try
            {
                Command.CommandText = query;
                dataReader = Command.ExecuteReader();

                while (dataReader.Read())
                {
                    Result = dataReader.GetMySqlDateTime("Now");
                }
            }
            catch (MySqlException ex)
            {

            }

            if (MySqlConnect.IsOpen)
            {
                MySqlConnect.CloseConnection();
            }

            return Result;
        }
    }
}
