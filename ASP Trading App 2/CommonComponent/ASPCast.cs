using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.Types;

namespace ASP_Trading_App_2.CommonComponent
{
    public class ASPCast
    {
        public static bool IntToBool(int Int)
        {
            bool result = false;
            if (Int == 1)
            {
                result = true;
            }
            else if (Int == 0)
            {
                result = false;
            }
            return result;
        }

        public static string BoolToStrCheck(Boolean value)
        {
            string Result = "";
            if (value)
            {
                Result = "v";
            }
            else
            {
                Result = "x";
            }
            return Result;
        }

        public static bool StrToBoolCheck(string value)
        {
            bool Result;
            if (value.Equals("v"))
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }

        public static int BoolToInt(bool Bool)
        {
            int result = 0;
            if (Bool == true)
            {
                result = 1;
            }
            else if (Bool == false)
            {
                result = 0;
            }
            return result;
        }

        public static string SQLDoubleToStr(double value)
        {
            return "'" + value.ToString() + "'";
        }

        public static string SQLIntToStr(int value)
        {
            return "'" + value.ToString() + "'";
        }

        public static string SQLBoolToStr(bool value)
        {
            string Result = "";
            if (value)
            {
                Result = "'1'";
            }
            else
            {
                Result = "'0'";
            }
            return Result;
        }

        public static string SQLDateTimeToStr(MySqlDateTime value)
        {
            return "'" + value.ToString() + "'";
        }

        public static string SQLStr(string value)
        {
            return "'" + value + "'";
        }
    }
}
