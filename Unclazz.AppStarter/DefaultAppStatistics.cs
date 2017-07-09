using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class DefaultAppStatistics : IAppStatistics
    {
        internal DefaultAppStatistics(IAppAssemblyProxy asmProxy)
        {
            StartedOn = DateTime.Now;
            ShortNameUsed = asmProxy.SpecifiedByShortFileName;
        }
        public bool ShortNameUsed { get; internal set; }
        public bool ErrorDetected { get; internal set; }
        public bool WarningDetected { get; internal set; }
        public DateTime StartedOn { get; internal set; }
        public TimeSpan ElapsedTime
        {
            get
            {
                return DateTime.Now - StartedOn;
            }
        }
    }
}
