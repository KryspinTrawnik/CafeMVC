﻿using System;
using System.Collections.Generic;
using System.Globalization;


namespace CafeMVC.Application.Services.Helpers
{

    public class Helper : IEqualityComparer<int>
    {
        public static double StringToDouble(string numberToConvert)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            if (numberToConvert.Contains(",") == true)
            {
                numberToConvert = numberToConvert.Replace(",", ".");
            }
            double result = double.TryParse(numberToConvert, out result) ? Convert.ToDouble(numberToConvert) : 0;

            return result;
        }

        public bool Equals(int x, int y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x == y;
        }

        public int GetHashCode(int obj)
        {
            if (ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.GetHashCode();

            return hashProductCode;
        }

        public static int SumUpListOfInts(List<int> listOfInts)
        {
            int result = 0;
            for(int i = 0; i < listOfInts.Count; i++)
            {
                result += listOfInts[i];
            }
           
            return result;
        }

        public static double SumUpListOfDoubles(List<double> list)
        {
            double result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
            }
            
            return result;

        }
    }
}
