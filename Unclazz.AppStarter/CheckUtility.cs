using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    static class CheckUtility
    {
        internal static void MustNotBeEmpty<T>(IEnumerable<T> value, string name)
        {
            if ((value ?? throw new ArgumentNullException(name)).Count() == 0)
            {
                throw new ArgumentException(string.Format("\"{0}\" must not be empty.", name), name);
            }
        }
        internal static void MustNotBeEmpty(string value, string name)
        {
            MustNotBeEmpty<char>(value, name);
        }
        internal static void MustBeGreaterThan(int value, int threshold, string name)
        {
            if (!(value > threshold))
            {
                throw new ArgumentOutOfRangeException(name,
                    string.Format("\"{0}\" must be greater than {1}.", name, threshold));
            }
        }
        internal static void MustBeGreaterThanOrEqual(int value, int threshold, string name)
        {
            if (!(value >= threshold))
            {
                throw new ArgumentOutOfRangeException(name,
                    string.Format("\"{0}\" must be greater than or equal {1}.", name, threshold));
            }
        }
        internal static void MustBeGreaterThan0(int value, string name)
        {
            MustBeGreaterThan(value, 0, name);
        }
        internal static void MustBeGreaterThanOrEqual0(int value, string name)
        {
            MustBeGreaterThanOrEqual(value, 0, name);
        }
    }
}
