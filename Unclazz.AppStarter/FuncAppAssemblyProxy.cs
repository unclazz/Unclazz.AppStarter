using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// <see cref="IAppAssemblyProxy"/>の実装クラスです。
    /// <para>このクラスの<c>Location</c>と<c>FullPath</c>プロパティは、
    /// コンストラクタの引数として指定されたデリゲートにより解決された値となります。</para>
    /// </summary>
    sealed class FuncAppAssemblyProxy : IAppAssemblyProxy
    {
        static FuncAppAssemblyProxy _defaultCache;
        /// <summary>
        /// <see cref="FuncAppAssemblyProxy"/>のデフォルトのインスタンスです。
        /// <para>
        /// このインスタンスの<c>Location</c>は、<c>Assembly.GetEntryAssembly().Location</c>と同等です。
        /// ただし<c>Assembly.GetEntryAssembly() == null</c>の場合は
        /// <c>Assembly.GetAssembly(typeof(FuncAppAssemblyProxy)).Location</c>と同等です。
        /// </para>
        /// <para>
        /// このインスタンスの<c>FullPath</c>は、<c>Location</c>を引数にして
        /// <see cref="Path.GetFullPath(string)"/>を実行した結果と同等です。
        /// </para>
        /// </summary>
        internal static FuncAppAssemblyProxy Default => _defaultCache ??
            (_defaultCache = new FuncAppAssemblyProxy(() =>
            {
                return Assembly.GetEntryAssembly()?.Location ?? 
                Assembly.GetAssembly(typeof(FuncAppAssemblyProxy))?.Location;
            }, Path.GetFullPath));

        readonly Func<string> _funcLocation;
        readonly Func<string, string> _funcGetFullPath;
        string _locationCache;
        string _fullPathCache;
        string _fileNameCache;
        string _fileNameWithoutExtensionCache;
        string _rawFileName;

        internal FuncAppAssemblyProxy(Func<string> funcLocation, Func<string, string> funcGetFullPath)
        {
            _funcLocation = funcLocation ?? throw new ArgumentNullException(nameof(funcLocation));
            _funcGetFullPath = funcGetFullPath ?? throw new ArgumentNullException(nameof(funcGetFullPath));
        }

        public string Location => _locationCache ?? (_locationCache = _funcLocation());

        public string FullPath => _fullPathCache ?? (_fullPathCache = _funcGetFullPath(Location));

        public string FileName => _fileNameCache ?? (_fileNameCache = Path.GetFileName(FullPath));

        public string FileNameWithoutExtension => _fileNameWithoutExtensionCache ?? (_fileNameWithoutExtensionCache = Path.GetFileNameWithoutExtension(FullPath));

        string RawFileName => _rawFileName ?? (_rawFileName = Path.GetFileName(Location));

        public bool SpecifiedByShortFileName => FileName != RawFileName;
    }
}
