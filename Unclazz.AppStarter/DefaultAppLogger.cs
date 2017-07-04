using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class DefaultAppLogger : IAppLogger
    {
        readonly Logger _logger;
        readonly DefaultAppStatistics _stats;
        internal DefaultAppLogger(Logger logger, DefaultAppStatistics stats)
        {
            _logger = logger;
            _stats = stats;
        }

        public void Error(string format, params object[] args)
        {
            _stats.ErrorDetected = true;
            _logger.Error(format, args);
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            _stats.ErrorDetected = true;
            _logger.Error(ex, format, args);
        }

        public void Error(string message)
        {
            _stats.ErrorDetected = true;
            _logger.Error(message);
        }

        public void Error(Exception ex, string message)
        {
            _stats.ErrorDetected = true;
            _logger.Error(ex, message);
        }

        public void Info(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Trace(string format, params object[] args)
        {
            _logger.Trace(format, args);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Warn(string format, params object[] args)
        {
            _stats.WarningDetected = true;
            _logger.Warn(format, args);
        }

        public void Warn(Exception ex, string format, params object[] args)
        {
            _stats.WarningDetected = true;
            _logger.Warn(ex, format, args);
        }

        public void Warn(string message)
        {
            _stats.WarningDetected = true;
            _logger.Warn(message);
        }

        public void Warn(Exception ex, string message)
        {
            _stats.WarningDetected = true;
            _logger.Warn(ex, message);
        }
    }
}
