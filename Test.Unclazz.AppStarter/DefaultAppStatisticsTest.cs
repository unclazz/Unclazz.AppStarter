using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclazz.AppStarter;

namespace Test.Unclazz.AppStarter
{
    [TestFixture]
    public class DefaultAppStatisticsTest
    {
        [TestCase(@"C:\path\to\TestAssembly.dll", @"C:\path\to\TestAssembly.dll", ExpectedResult = false)]
        [TestCase(@"C:\path\to\TESTAS~1.dll", @"C:\path\to\TestAssembly.dll", ExpectedResult = true)]
        public bool ShortNameUsed_CheckIfShortFileNameIsUsed(string arg0, string arg1)
        {
            // Arrange
            var asmProxy = new FuncAppAssemblyProxy(() => arg0, s => arg1);

            // Act
            // Assert
            return new DefaultAppStatistics(asmProxy).ShortNameUsed;
        }
    }
}
