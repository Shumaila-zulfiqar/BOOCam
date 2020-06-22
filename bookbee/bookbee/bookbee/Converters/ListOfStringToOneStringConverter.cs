﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bookbee.Converters


{
    public class ListOfStringToOneStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts a list of strings to one string containing all strings 
        /// separated with a comma.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as List<string>;

            var str = string.Empty;

            if (list != null)
            {
                foreach (var s in list)
                {
                    str += s + ", ";
                }
            }

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}