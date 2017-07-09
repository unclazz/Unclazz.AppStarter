using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Unclazz.AppStarter.Mock;
using Unclazz.AppStarter;

namespace Test.Unclazz.AppStarter
{
    [TestFixture]
    public class DefaultAppConfigurationTest
    {
        DateTime _mockStartedOn;
        IAppStatistics _mockAppStatistics;
        string _mockLogFileName;

        [SetUp]
        public void SetUp()
        {
            _mockStartedOn = DateTime.Now;
            _mockAppStatistics = new MockAppStatistics(_mockStartedOn);
            _mockLogFileName = string.Format("{0}_{1:yyyyMMddHHmmssfff}.log",
                FuncAppAssemblyProxy.Default.FileNameWithoutExtension, _mockStartedOn);
        }

        [Test]
        public void Constructor_InitializesEachProperties()
        {
            // Arrange
            // Act
            var c = new DefaultAppConfiguration(FuncAppAssemblyProxy.Default, _mockAppStatistics);

            // Assert
            Assert.That(c.StatusOnFailure, Is.EqualTo(1));
            Assert.That(c.StatusOnSuccess, Is.EqualTo(0));
            Assert.That(c.UseErrorStream, Is.EqualTo(false));
            Assert.That(c.UseLogFile, Is.EqualTo(true));
            Assert.That(c.LogDirectory, Is.EqualTo(Environment.CurrentDirectory));
            Assert.That(c.LogEncoding, Is.EqualTo(Encoding.UTF8));
            Assert.That(c.LogFileName, Is.EqualTo(_mockLogFileName));
            Assert.That(c.MinLogLevel, Is.EqualTo(AppLogLevel.Warn));
        }
        [Test]
        public void SetLogDirectory_WhenArg0IsInvalidValue_ThrowsException()
        {
            // Arrange
            var c = new DefaultAppConfiguration(FuncAppAssemblyProxy.Default, _mockAppStatistics);

            // Act
            // Assert
            c.SetLogDirectory("a");
            Assert.That(() =>
            {
                c.SetLogDirectory(null);
            }, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() =>
            {
                c.SetLogDirectory(string.Empty);
            }, Throws.InstanceOf<ArgumentException>());
        }
        [Test]
        public void SetLogEncoding_WhenArg0IsInvalidValue_ThrowsException()
        {
            // Arrange
            var c = new DefaultAppConfiguration(FuncAppAssemblyProxy.Default, _mockAppStatistics);

            // Act
            // Assert
            c.SetLogEncoding(Encoding.ASCII);
            Assert.That(() =>
            {
                c.SetLogEncoding(null);
            }, Throws.InstanceOf<ArgumentNullException>());
        }
        [Test]
        public void SetLogFileName_WhenArg0IsInvalidValue_ThrowsException()
        {
            // Arrange
            var c = new DefaultAppConfiguration(FuncAppAssemblyProxy.Default, _mockAppStatistics);

            // Act
            // Assert
            c.SetLogFileName("a");
            Assert.That(() =>
            {
                c.SetLogFileName(null);
            }, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() =>
            {
                c.SetLogFileName(string.Empty);
            }, Throws.InstanceOf<ArgumentException>());
        }
        [Test]
        public void SetStatusOnFailure_WhenArg0IsInvalidValue_ThrowsException()
        {
            // Arrange
            var c = new DefaultAppConfiguration(FuncAppAssemblyProxy.Default, _mockAppStatistics);

            // Act
            // Assert
            c.SetStatusOnFailure(0);
            c.SetStatusOnFailure(1);
            Assert.That(() =>
            {
                c.SetStatusOnFailure(-1);
            }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() =>
            {
                c.SetStatusOnFailure(-2);
            }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void SetStatusOnSuccess_WhenArg0IsInvalidValue_ThrowsException()
        {
            // Arrange
            var c = new DefaultAppConfiguration(FuncAppAssemblyProxy.Default, _mockAppStatistics);

            // Act
            // Assert
            c.SetStatusOnSuccess(0);
            c.SetStatusOnSuccess(1);
            Assert.That(() =>
            {
                c.SetStatusOnSuccess(-1);
            }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(() =>
            {
                c.SetStatusOnSuccess(-2);
            }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
