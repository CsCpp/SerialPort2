using System;
using System.Globalization;

//строка имеет вид
// $12.23,45,65,12.3
//     u     i    t
// $  начало строки
namespace SerialChargeTracker
{
    public static class BatteryParser  // static, чтобы не создовать экземпляр
    {
        public static BatteryData Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            input = input.Trim();
            if (!input.StartsWith("$")) return null;

            var style = NumberStyles.Any;
            var culture = CultureInfo.InvariantCulture;

            var pars = input.Substring(1).Split(',');
            // Вариант с 3 параметрами (U, I, T)
            if (pars.Length == 3 &&
                 double.TryParse(pars[0], style, culture, out double u) &&
                 double.TryParse(pars[1], style, culture, out double i) &&
                 double.TryParse(pars[2], style, culture, out double t))
            {
                return new BatteryData(u, i, t);
            }
            // Вариант с 4 параметрами (Date, U, I, T)
            else if (pars.Length == 4 &&
                DateTime.TryParse(pars[0], culture, DateTimeStyles.None, out DateTime d1) &&
                double.TryParse(pars[1], style, culture, out double u1) &&
                double.TryParse(pars[2], style, culture, out double i1) &&
                double.TryParse(pars[3], style, culture, out double t1))

            {
                return new BatteryData(u1, i1, t1, d1);
            }

            return null;
        }
    }
}

