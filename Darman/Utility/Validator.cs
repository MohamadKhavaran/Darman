using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Darman.Utility
{
    public static class Validator
    {
        public static bool frmValidator(Control ctrl)
        {
            string Message = "";
            bool isValid = true;
            foreach (Control item in ctrl.Controls)
            {
                if (item.AccessibleDescription == "*" && item.Text == "")
                {
                    Message = $"فیلد{item.AccessibleName} نمی تواند خالی باشد";
                    MyMessage.ErrorMessage(Message);
                    isValid = false;
                    return isValid;
                }
                if (item.Controls.Count != 0)
                {
                    frmValidator(item);
                }
            }
            return isValid;
        }
        public static bool CheckSSID(string SSID)
        {
            if (SSID.Length < 10)
            {
                MyMessage.ErrorMessage("فیلد کد ملی به درستی وارد نشده است ");
                return false;
            }
            return true;
        }
    }

}
