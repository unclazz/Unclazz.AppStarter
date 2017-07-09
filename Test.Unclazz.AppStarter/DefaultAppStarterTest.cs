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
    public class DefaultAppStarterTest
    {
        [Test]
        [Description("Startメソッド - Case #1 - 正常系")]
        public void Start_Case1()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            var ctx = new DefaultAppContext(asmProxy, stats, conf, new string[0]);
            var exitCode = -1;

            var starter = new DefaultAppStarter(asmProxy, new ActionAppExitProxy(code =>
            {
                exitCode = code;
            }), args => ctx = new DefaultAppContext(asmProxy, stats, conf, args));


            ActionAppStartable startable = new ActionAppStartable((c) => {
                called = true;
            });

            // Act
            starter.Start(startable, new string[0]);

            // Assert
            Assert.That(exitCode, Is.EqualTo(0));
            Assert.That(stats.WarningDetected, Is.False);
            Assert.That(stats.ErrorDetected, Is.False);
            Assert.That(called, Is.True);
        }

        [Test]
        [Description("Startメソッド - Case #2 - 異常系（明示的な例外スロー）")]
        public void Start_Case2()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            var ctx = new DefaultAppContext(asmProxy, stats, conf, new string[0]);
            var exitCode = -1;

            var starter = new DefaultAppStarter(asmProxy, new ActionAppExitProxy(code =>
            {
                exitCode = code;
            }), args => ctx = new DefaultAppContext(asmProxy, stats, conf, args));


            ActionAppStartable startable = new ActionAppStartable((c) => {
                called = true;
                throw new Exception("test");
            });

            // Act
            // Assert
            try
            {
                starter.Start(startable, new string[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.That(exitCode, Is.EqualTo(1));
            Assert.That(stats.WarningDetected, Is.False);
            Assert.That(stats.ErrorDetected, Is.True);
            Assert.That(called, Is.True);
        }

        [Test]
        [Description("Startメソッド - Case #3 - 異常系（エラーログ出力に伴う暗黙的なエラー、異常終了コード＝1）")]
        public void Start_Case3()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            IAppContext ctx = null;
            var exitCode = -1;

            var starter = new DefaultAppStarter(asmProxy, new ActionAppExitProxy(code =>
            {
                exitCode = code;
            }), args => ctx = new DefaultAppContext(asmProxy, stats, conf, args));


            ActionAppStartable startable = new ActionAppStartable((c) => {
                Assert.That(object.ReferenceEquals(c, ctx), Is.True);
                called = true;
                c.Logger.Error("test");
            });

            // Act
            // Assert
            try
            {
                starter.Start(startable, new string[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.That(called, Is.True);
            Assert.That(stats.WarningDetected, Is.False);
            Assert.That(stats.ErrorDetected, Is.True);
            Assert.That(exitCode, Is.EqualTo(1));
        }

        [Test]
        [Description("Startメソッド - Case #4 - 異常系（エラーログ出力に伴う暗黙的なエラー、異常終了コード＝2）")]
        public void Start_Case4()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            conf.SetStatusOnFailure(2);
            IAppContext ctx = null;
            var exitCode = -1;

            var starter = new DefaultAppStarter(asmProxy, new ActionAppExitProxy(code =>
            {
                exitCode = code;
            }), args => ctx = new DefaultAppContext(asmProxy, stats, conf, args));


            ActionAppStartable startable = new ActionAppStartable((c) => {
                Assert.That(object.ReferenceEquals(c, ctx), Is.True);
                called = true;
                c.Logger.Error("test");
            });

            // Act
            // Assert
            try
            {
                starter.Start(startable, new string[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.That(called, Is.True);
            Assert.That(stats.WarningDetected, Is.False);
            Assert.That(stats.ErrorDetected, Is.True);
            Assert.That(exitCode, Is.EqualTo(2));
        }

        [Test]
        [Description("Startメソッド - Case #4 - 異常系（警告ログ出力に伴う暗黙的な警告終了、異常終了コード＝1）")]
        public void Start_Case5()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            IAppContext ctx = null;
            var exitCode = -1;

            var starter = new DefaultAppStarter(asmProxy, new ActionAppExitProxy(code =>
            {
                exitCode = code;
            }), args => ctx = new DefaultAppContext(asmProxy, stats, conf, args));


            ActionAppStartable startable = new ActionAppStartable((c) => {
                Assert.That(object.ReferenceEquals(c, ctx), Is.True);
                called = true;
                c.Logger.Warn("test");
            });

            // Act
            // Assert
            try
            {
                starter.Start(startable, new string[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.That(called, Is.True);
            Assert.That(stats.WarningDetected, Is.True);
            Assert.That(stats.ErrorDetected, Is.False);
            Assert.That(exitCode, Is.EqualTo(0));
        }

        [Test]
        [Description("Startメソッド - Case #4 - 異常系（警告ログ出力に伴う暗黙的な警告終了、異常終了コード＝2）")]
        public void Start_Case6()
        {
            // Arrange
            var called = false;
            var asmProxy = FuncAppAssemblyProxy.Default;
            var stats = new DefaultAppStatistics(asmProxy);
            var conf = new DefaultAppConfiguration(asmProxy, stats);
            conf.SetStatusOnFailure(2);
            IAppContext ctx = null;
            var exitCode = -1;

            var starter = new DefaultAppStarter(asmProxy, new ActionAppExitProxy(code =>
            {
                exitCode = code;
            }), args => ctx = new DefaultAppContext(asmProxy, stats, conf, args));


            ActionAppStartable startable = new ActionAppStartable((c) => {
                Assert.That(object.ReferenceEquals(c, ctx), Is.True);
                called = true;
                c.Logger.Warn("test");
            });

            // Act
            // Assert
            try
            {
                starter.Start(startable, new string[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            Assert.That(called, Is.True);
            Assert.That(stats.WarningDetected, Is.True);
            Assert.That(stats.ErrorDetected, Is.False);
            Assert.That(exitCode, Is.EqualTo(1));
        }
    }
}
