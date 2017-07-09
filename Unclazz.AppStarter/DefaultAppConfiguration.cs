using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class DefaultAppConfiguration : IAppConfiguration, IAppConfigurer
    {
        public int StatusOnSuccess { get; private set; } = 0;
        public int StatusOnFailure { get; private set; } = 1;
        public bool UseErrorStream { get; private set; } = false;
        public bool UseLogFile { get; private set; } = true;
        public AppLogLevel MinLogLevel { get; private set; } = AppLogLevel.Warn;
        public string LogDirectory { get; private set; }
        public string LogFileName { get; private set; }
        public Encoding LogEncoding { get; private set; } = Encoding.UTF8;

        internal DefaultAppConfiguration(IAppAssemblyProxy asmProxy, IAppStatistics stats)
        {
            LogDirectory = Environment.CurrentDirectory;
            LogFileName = string.Format("{0}_{1:yyyyMMddHHmmssfff}.log",
                asmProxy.FileNameWithoutExtension, stats.StartedOn);
        }

        public IAppConfigurer SetLogDirectory(string path)
        {
            CheckUtility.MustNotBeEmpty(path, nameof(path));
            LogDirectory = path;
            return this;
        }

        public IAppConfigurer SetLogFileName(string fileName)
        {
            CheckUtility.MustNotBeEmpty(fileName, nameof(fileName));
            LogFileName = fileName;
            return this;
        }

        public IAppConfigurer SetMinLogLevel(AppLogLevel lv)
        {
            MinLogLevel = lv;
            return this;
        }

        public IAppConfigurer SetStatusOnFailure(int code)
        {
            CheckUtility.MustBeGreaterThanOrEqual0(code, nameof(code));
            StatusOnFailure = code;
            return this;
        }

        public IAppConfigurer SetStatusOnSuccess(int code)
        {
            CheckUtility.MustBeGreaterThanOrEqual0(code, nameof(code));
            StatusOnSuccess = code;
            return this;
        }

        public IAppConfigurer SetUseErrorStream(bool use)
        {
            UseErrorStream = use;
            return this;
        }
        public IAppConfigurer SetUseLogFile(bool use)
        {
            UseLogFile = use;
            return this;
        }
        public IAppConfigurer SetLogEncoding(Encoding enc)
        {
            LogEncoding = enc ?? throw new ArgumentNullException(nameof(enc));
            return this;
        }
    }
}
