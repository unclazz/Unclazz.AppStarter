using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class DefaultAppContext : IAppContext
    {
        internal DefaultAppContext(IAppAssemblyProxy asmProxy, 
            DefaultAppStatistics stats, IAppConfiguration conf, string[] args)
        {
            // 構成情報、統計情報、コマンド名と引数などのプロパティを初期化
            Statistics = stats;
            Configuration = conf;
            CommandPath = asmProxy.FullPath;
            CommandName = asmProxy.FileName;
            Arguments = args.ToList().AsReadOnly();

            // ショートファイル名でアセンブリが起動されたケースも考慮して構成ファイルをロード
            var exeConf = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
            { ExeConfigFilename = CommandPath + ".config" }, ConfigurationUserLevel.None);

            // appSettingsとconnectionStringsの2セクションを単純な辞書形式に変換
            AppSettings = new ReadOnlyDictionary<string, string>
                (exeConf.AppSettings.Settings
                .Cast<KeyValueConfigurationElement>()
                .ToDictionary(e => e.Key, e => e.Value));
            ConnectionStrings = new ReadOnlyDictionary<string, string>
                (exeConf.ConnectionStrings.ConnectionStrings
                .Cast<ConnectionStringSettings>()
                .ToDictionary(s => s.Name, s => s.ConnectionString));

            // ロガーの初期化を行う
            var logLevel = TranslateLogLevel(conf.MinLogLevel);
            var logConf = new LoggingConfiguration();
            var consoleTarget = new ConsoleTarget("console");
            consoleTarget.Error = conf.UseErrorStream;
            logConf.AddTarget(consoleTarget);
            logConf.LoggingRules.Add(new LoggingRule("*", logLevel, consoleTarget));
            if (conf.UseLogFile)
            {
                var fileTarget = new FileTarget("file");
                fileTarget.Encoding = conf.LogEncoding;
                fileTarget.FileName = Path.Combine(conf.LogDirectory, conf.LogFileName);
                logConf.AddTarget(fileTarget);
                logConf.LoggingRules.Add(new LoggingRule("*", logLevel, fileTarget));
            }
            LogManager.Configuration = logConf;
            Logger = new DefaultAppLogger(LogManager.GetLogger(CommandName), stats);
        }

        LogLevel TranslateLogLevel(AppLogLevel lv)
        {
            switch (lv)
            {
                case AppLogLevel.Error:
                    return LogLevel.Error;
                case AppLogLevel.Warn:
                    return LogLevel.Warn;
                case AppLogLevel.Info:
                    return LogLevel.Info;
                case AppLogLevel.Trace:
                    return LogLevel.Trace;
                default:
                    throw new ArgumentException("Unexpected value specified.");
            }
        }

        public string CommandName { get; internal set; }
        public string CommandPath { get; internal set; }
        public IList<string> Arguments { get; internal set; }
        public IDictionary<string, string> AppSettings { get; internal set; }
        public IDictionary<string, string> ConnectionStrings { get; internal set; }
        public IAppConfiguration Configuration { get; internal set; }
        public IAppLogger Logger { get; internal set; }
        public IAppStatistics Statistics { get; internal set; }
    }
}
