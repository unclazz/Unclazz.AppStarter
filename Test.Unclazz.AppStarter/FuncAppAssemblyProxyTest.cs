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
    public class FuncAppAssemblyProxyTest
    {
        [TestCase(@"C:\path\to\TestAssembly.dll", @"C:\path\to\TestAssembly.dll", ExpectedResult = false)]
        [TestCase(@"C:\path\to\TESTAS~1.dll", @"C:\path\to\TestAssembly.dll", ExpectedResult = true)]
        public bool SpecifiedByShortFileName_CheckIfShortFileNameIsUsed(string arg0, string arg1)
        {
            // Arrange
            var asmProxy = new FuncAppAssemblyProxy(() => arg0, s => arg1);

            // Act
            // Assert
            return asmProxy.SpecifiedByShortFileName;
        }
        [TestCase(@"C:\path\to\TestAssembly.dll", ExpectedResult = "TestAssembly.dll")]
        public string AssemblyFileName_ReturnsFileNameWithExtension(string arg0)
        {
            // Arrange
            var asmProxy = new FuncAppAssemblyProxy(() => arg0, s => arg0);

            // Act
            // Assert
            return asmProxy.FileName;
        }
        [TestCase(@"C:\path\to\TestAssembly.dll", ExpectedResult = "TestAssembly")]
        public string AssemblyFileNameWithoutExtension_ReturnsFileNameWithoutExtension(string arg0)
        {
            // Arrange
            var asmProxy = new FuncAppAssemblyProxy(() => arg0, s => arg0);

            // Act
            // Assert
            return asmProxy.FileNameWithoutExtension;
        }
    }
}
