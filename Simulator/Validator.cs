using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class Validator
    {
        public static int Limiter(int value, int min, int max) 
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static string Shortener(string value, int min, int max, char placeholder)
        {
            if (string.IsNullOrEmpty(value))
                value = new string(placeholder, min);

            if (value.Length < min)
                return value + new string(placeholder, min - value.Length);

            if (value.Length > max)
                return value.Substring(0, max);

            return value;
        }

    }
}
