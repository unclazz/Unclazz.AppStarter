using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class DefaultAppStarter : IAppStarter
    {
        readonly DefaultAppStatistics _stats;
        readonly DefaultAppConfiguration _conf;

        internal DefaultAppStarter()
        {
            _stats = new DefaultAppStatistics();
            _conf = new DefaultAppConfiguration(_stats);
        }

        public IAppStarter Configure(Action<IAppConfigurer> conf)
        {
            conf(_conf);
            return this;
        }
        public void Start(IAppStartable myApp, params string[] args)
        {
            var ctx = new DefaultAppContext(_stats, _conf, args ?? new string[0]);
            try
            {
                myApp.Start(ctx);
                if (ctx.Statistics.ErrorDetected)
                {
                    Environment.Exit(ctx.Configuration.StatusOnFailure);
                }
                else if (ctx.Statistics.WarningDetected)
                {
                    Environment.Exit(ctx.Configuration.StatusOnFailure - 1);
                }
                Environment.Exit(ctx.Configuration.StatusOnSuccess);
            }
            catch (Exception ex)
            {
                Environment.Exit(ctx.Configuration.StatusOnFailure);
                ctx.Logger.Error(ex, "An error has occurred. And the application has stopped working.");
                throw;
            }
        }
        public void Start<T>(params string[] args) where T : IAppStartable, new()
        {
            Start(new T(), args);
        }
        public void Start(Action<IAppContext> myApp, params string[] args)
        {
            Start(new ActionAppStartable(myApp), args);
        }
    }
}
