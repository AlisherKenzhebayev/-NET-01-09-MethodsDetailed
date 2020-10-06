// <copyright file="ExtensionDouble.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NET_01_09_MethodsInDetails
{
    using System;
    using System.Linq;

    public static class ExtensionDouble
    {
        // sign - exponent(11) - fraction (52)
        public static string DoubleToBoolString(this double s)
        {
            switch (s)
            {
                case double.NaN:
                    return "1111111111111000000000000000000000000000000000000000000000000000";
                case double.MaxValue:
                    return "0111111111101111111111111111111111111111111111111111111111111111";
                case double.MinValue:
                    return "1111111111101111111111111111111111111111111111111111111111111111";
                case double.NegativeInfinity:
                    return "1111111111110000000000000000000000000000000000000000000000000000";
                case double.PositiveInfinity:
                    return "0111111111110000000000000000000000000000000000000000000000000000";
                case double.Epsilon:
                    return "0000000000000000000000000000000000000000000000000000000000000001";
                case 0.0:
                {
                    // -0.0 is handled using the fact that -Inf + Inf = Nan
                    var v = (double.PositiveInfinity / s) + double.PositiveInfinity;
                    return double.IsNaN(v)
                        ? "1000000000000000000000000000000000000000000000000000000000000000"
                        : "0000000000000000000000000000000000000000000000000000000000000000";
                }
            }

            var retSign = "0";
            if (s < 0)
            {
                retSign = "1";
                s = -s;
            }

            var offset = 0;
            if (s > 0 && s < 1)
            {
                while ((long)Math.Truncate(s) == 0)
                {
                    s *= 2;
                    offset += 1;
                }
            }

            var integer = (long)Math.Truncate(s);
            var floating = s - integer;

            var retInteger = IntToBool(integer, false);
            var powTwo = retInteger.Length + 1023 - offset;
            var retExponent = IntToBool(powTwo);
            var temp = string.Empty;
            var iter = 0;
            while (floating != 0 && iter < 52)
            {
                iter++;
                floating *= 2;
                var c = Math.Truncate(floating);
                floating -= c;

                temp += (char)((c % 2) + 48);
            }

            // Fraction is = 1.retFraction
            var retFraction = retInteger + temp;

            return retSign + retExponent.PadLeft(11, '0') + retFraction.PadRight(52, '0');
        }

        private static string IntToBool(long input, bool full = true)
        {
            var temp = string.Empty;
            while (full ? input >= 1 : input > 1)
            {
                temp += (char)((input % 2) + 48);
                input /= 2;
            }

            return new string(temp.Reverse().ToArray());
        }
    }
}