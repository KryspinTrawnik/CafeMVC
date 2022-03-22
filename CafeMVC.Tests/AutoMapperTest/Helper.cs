using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Tests.AutoMapperTest
{
    public class Helper
    {
        public Helper()
        {

        }

        public static double StringToDouble(string numberToConvert)
        {
           CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            double result = Double.TryParse(numberToConvert, out result) ? Convert.ToDouble(numberToConvert) : 0;

            return result;
        }
    }
}
