using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclazz.AppStarter;

namespace Test.Unclazz.AppStarter.Mock
{
    class MockAppStatistics : IAppStatistics
    {
        internal MockAppStatistics(DateTime startedOn)
        {
            StartedOn = startedOn;
        }
        public bool ShortNameUsed => false;

        public bool ErrorDetected => false;

        public bool WarningDetected => false;

        public DateTime StartedOn { get; }

        public TimeSpan ElapsedTime => DateTime.Now - StartedOn;
    }
}
