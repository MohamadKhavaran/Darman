using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Darman.Utility
{
    public static class MyMessage
    {
        public static void IsSuccess(string Message)
        {
            MessageBox.Show(Message, "عملیات موفق", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
            
        public static void ErrorMessage(string Message)
        {
            MessageBox.Show(Message, "عملیات ناموفق", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult QuestionMessage(string Message)
        {
            return MessageBox.Show(Message, "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
