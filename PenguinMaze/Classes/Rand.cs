using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinMaze.Classes
{
    static class Rand
    {
        private static Random myInstance = null;
        static Rand()
        {
            myInstance = new Random();
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must
        ///                        be greater than or equal to 0.</param>
        /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than maxValue;
        ///          that is, the range of return values ordinarily includes 0 but not maxValue. However,
        ///          if maxValue equals 0, maxValue is returned.</returns>
        public static int Next(int maxValue)
        {
            return myInstance.Next(maxValue);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.
        ///                             maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue;
        ///          that is, the range of return values includes minValue but not maxValue. If minValue
        ///          equals maxValue, minValue is returned.</returns>
        public static int Next(int minValue, int maxValue)
        {
            return myInstance.Next(minValue, maxValue);
        }
    }
}
