using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unclazz.AppStarter;

namespace Test.Unclazz.AppStarter
{
    [TestFixture]
    public class DefaultAppContextTest
    {
        DefaultAppStatistics _mockAppStatistics;
        IAppConfiguration _mockAppConfiguration;

        [SetUp]
        public void SetUp()
        {
            _mockAppStatistics = new DefaultAppStatistics(); ;
            _mockAppConfiguration = new DefaultAppConfiguration(_mockAppStatistics);
        }

        [Test]
        public void Constructor_InitializesEachPropertiesAndLogManagerConfiguration()
        {
            var args = new string[] { "foo", "bar", "baz" };
            var ctx = new DefaultAppContext(_mockAppStatistics, _mockAppConfiguration, args);

            Assert.That(ctx.Arguments.ToArray(), Is.EqualTo(args));
            Assert.That(ctx.CommandName, Is.EqualTo(EntryAssemblyUtility.AssemblyFileName));
            Assert.That(ctx.CommandPath, Is.EqualTo(EntryAssemblyUtility.AssemblyFullPath));

            var targets = LogManager.Configuration.AllTargets;
            var rules = LogManager.Configuration.LoggingRules;
            Assert.That(targets.Count(), Is.EqualTo(2));
            Assert.That(targets.Select(t => t.Name).OrderBy(n => n).ToArray(),
                Is.EqualTo(new string[] { "console", "file" }));
            Assert.That(rules.Count(), Is.EqualTo(2));
            Assert.That(rules.All(r => r.LoggerNamePattern == "*"), Is.True);
            Assert.That(rules.Select(r => r.Targets.Single())
                .Select(t => t.Name).OrderBy(n => n).ToArray(),
                Is.EqualTo(new string[] { "console", "file" }));
        }
    }
}
