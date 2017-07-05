using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    static class EntryAssemblyUtility
    {
        public static string AssemblyLocation { get; internal set; } = Assembly.GetEntryAssembly()?.Location;
        public static string AssemblyFullPath { get; internal set; } = Path.GetFullPath(AssemblyLocation ?? ".");
        public static string AssemblyFileName
        {
            get
            {
                return Path.GetFileName(AssemblyFullPath);
            }
        }
        public static string AssemblyFileNameWithoutExtension
        {
            get
            {
                return Path.GetFileNameWithoutExtension(AssemblyFullPath);
            }
        }
        public static bool SpecifiedByShortFileName
        {
            get
            {
                return AssemblyLocation != AssemblyFullPath;
            }
        }
    }
}
