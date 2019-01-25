using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP_Trading_App_2.CommonComponent
{
    public class ASPCommon
    {
        public static String GenerateNewKode(string Header, int Lenght, int Id)
        {
            int currLen = Lenght - Id.ToString().Length;
            String nol = "";
            for (int i = 0; i < currLen; i++)
            {
                nol = String.Concat(nol, "0");
            }
            return Header + nol + Id;
        }
    }
}
