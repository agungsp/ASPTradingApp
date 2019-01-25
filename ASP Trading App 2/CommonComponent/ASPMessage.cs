using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASP_Trading_App_2.CommonComponent
{
    public class ASPMessage
    {
        public const string tm_ErrLogin = "Login Error";
        public const string tm_FormValidation = "Form Validation Message";
        public const string tm_Save = "Save Confirmation";
        public const string tm_Delete = "Delete Confirmation";
        public const string tm_Cancel = "Cancel Confirmation";
        public const string tm_NOTEXIST = "Data Not Found";

        //Warning Message
        public const string wm_NOTEXIST = "{0} {1} tidak ada!";
        public const string wm_ISWRONG = "{0} salah!";
        public const string wm_CANNOTNULL = "{0} tidak boleh kosong!";

        //Confirm Message
        public const string cm_SAVE = "Yakin ingin menyimpan?";
        public const string cm_DELETE = "Yakin ingin menghapus?";
        public const string cm_CANCEL = "Yakin ingin batal?";
    }
}
