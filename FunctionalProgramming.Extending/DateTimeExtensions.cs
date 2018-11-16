using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming.Extending
{
    public static class DateTimeExtensions
    {

        public static string ToDeviceFormat(this DateTime dt)
        {
            string result = dt.ToString("yyyyMMddhhhmmss");
            return dt.Year >= 2000 ? result : result.Substring(2);
        }
    }
}
