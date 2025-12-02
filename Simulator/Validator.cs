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
    

            string result = (value ?? string.Empty).Trim();

            if (result.Length > max)
            {
                result = result.Substring(0, max).Trim();
            }

            if (result.Length < min)
            {
                result = result.PadRight(min, placeholder);
            }

            if (result.Length > 0 && char.IsLower(result[0]))
            {
                result = char.ToUpperInvariant(result[0]) + (result.Length > 1 ? result.Substring(1) : string.Empty);
            }

            return result;
        }
    }
}
