using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Services
{
    
    public static class Helper
    {
        public static double StringToDouble(string numberToConvert)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            double result = Double.TryParse(numberToConvert, out result) ? Convert.ToDouble(numberToConvert) : 0;

            return result;
        }
    }
}
