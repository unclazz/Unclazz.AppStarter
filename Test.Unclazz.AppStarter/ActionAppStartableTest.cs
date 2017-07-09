using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclazz.AppStarter;

namespace Test.Unclazz.AppStarter.Mock
{
    [TestFixture]
    public class ActionAppStartableTest
    {
        [Test]
        public void Start_CallsAction_WithAppContext()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            var ctx = new DefaultAppContext(asmProxy, stats, conf, new string[0]);

            ActionAppStartable startable = new ActionAppStartable((c) => {
                called = true;
                Assert.That(object.ReferenceEquals(c, ctx), Is.True);
            });

            // Act
            startable.Start(ctx);

            // Assert
            Assert.That(called, Is.True);
        }
    }
}
