using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASP_Trading_App_2.CommonComponent
{
    public class ASPMsgCmp
    {
        public static DialogResult InfoMessage(string text)
        {
           return MessageBox.Show(null, text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult WarningMessage(string text)
        {
            return MessageBox.Show(null, text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ErrorMessage(string text)
        {
            return MessageBox.Show(null, text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult QuestionMessage(string text)
        {
            return MessageBox.Show(null, text, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult StopMessage(string text)
        {
            return MessageBox.Show(null, text, "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
