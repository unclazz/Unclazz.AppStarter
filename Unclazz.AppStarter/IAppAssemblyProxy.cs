using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アセンブリ情報取得を代行するためのアセンブリ・プライベートなインターフェースです。
    /// <para>単体テストにおいて<see cref="Assembly"/>クラスのプロキシを用意する必要があるため、
    /// このインターフェースが用意されました。</para>
    /// </summary>
    interface IAppAssemblyProxy
    {
        /// <summary>
        /// アセンブリのパスです。
        /// <para>
        /// <see cref="Location"/>はショートファイル名に基づくパスを返す場合があります。
        /// <see cref="FullPath"/>は必ずロングファイル名に基づくパスを返します。
        /// </para>
        /// </summary>
        string Location { get; }
        /// <summary>
        /// アセンブリのフルパスです。
        /// <para>
        /// <see cref="Location"/>はショートファイル名に基づくパスを返す場合があります。
        /// <see cref="FullPath"/>は必ずロングファイル名に基づくパスを返します。
        /// </para>
        /// </summary>
        string FullPath { get; }
        /// <summary>
        /// アセンブリのファイル名（ディレクトリのパスを含まない）です。
        /// <para>
        /// <see cref="FileName"/>は必ずロングファイル名に基づくファイル名を返します。
        /// </para>
        /// </summary>
        string FileName { get; }
        /// <summary>
        /// <see cref="FileName"/>から拡張子を除去した文字列です。
        /// </summary>
        string FileNameWithoutExtension { get; }
        /// <summary>
        /// アセンブリがショートファイル名で指定されている場合<c>true</c>です。
        /// </summary>
        bool SpecifiedByShortFileName { get; }
    }
}
