using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace Darman.Utility
{
    public static class ErrorHandling
    {
        public static string Error(Exception ex)
        {
            string Message = "";
            if (ex.GetType() == typeof(FormatException))
            {
                Message = "فرمت وارد شده صحیح نمی باشد";
            }
            else if (ex.GetType() == typeof(ThreadExceptionEventArgs))
            {
                Message = " خطای حافطه ی اختصاص داده شده";
            }
            else if (ex.GetType() == typeof(SqlException))
            {
                SqlException exnum = ex as SqlException;
                int Number = exnum.Number;
                switch (Number)
                {
                    case 2627:
                        Message = "اطلاعات وارد شده تکراری است";
                        break;
                    case 547:
                        Message = "اطلاعات وارد شده نمی تواند حذف شود زیرا در جدول دیگری استفاده شده است";
                        break;
                }
            }
            return Message;
        }
    }
}
