# `Unclazz.AppStarter` の README

`Unclazz.AppStarter` はコンソール・アプリケーションのために作成された軽量なアプリケーション・ランチャーAPIです。
このAPIを使用してアプリケーションの起動を行うことで、ユーザ開発者は、コマンドライン引数やアプリケーション構成ファイルで定義された情報へのアクセスはもちろん、
アプリケーションのために初期化されたロガーへのアクセス、ハンドルされない例外のスローやエラーログ出力に伴う終了ステータス・コードの制御などのサポートを得られます。

## 使用例

APIの中核コンポーネントである `App` ユーティリティを利用してあなたのアプリケーションを起動するコードは次のようになります：

```cs
using Unclazz.AppStarter;

class Program
{
	static void Main(string[] args)
	{
		App.Start(new Program().Start, args);
	}

	public void Start(IAppContext ctx)
	{
		// あなたのアプリケーションのロジック
	}
}
```

あなたのアプリケーションのエントリーポイントが `IAppStartable` インターフェースを実装している場合は次のようなコードも可能です：

```cs
using Unclazz.AppStarter;

class Program : IAppStartable
{
	static void Main(string[] args)
	{
		App.Start<Program>(args);
	}

	public void Start(IAppContext ctx)
	{
		// あなたのアプリケーションのロジック
	}
}
```

いずれの場合にもあなたのアプリケーションには `IAppContext` インターフェースのインスタンスが渡されます。
このインターフェースを通じて、コマンドライン引数やアプリケーション構成ファイルで定義された情報へのアクセスはもちろん、
アプリケーションのために初期化されたロガーなどにアクセスすることができます：

プロパティ名 | 型名 | 説明
--- | --- | ---
CommandName | string | 実行中のアセンブリのファイル名（例：YourApp.exe）
CommandPath | string | 実行中のアセンブリのパス（例：C:\path\to\YourApp.exe）
Arguments | IList&lt;string> | コマンドライン引数
AppSettings | IDictionary&lt;string, string> | アプリケーション構成ファイルのappSettingsセクションから読み取られた設定情報の辞書
ConnectionStrings | IDictionary&lt;string, string> | アプリケーション構成ファイルのconnectionStringsセクションから読み取られた設定情報の辞書
Logger | IAppLogger | 実行中のアプリケーションのために初期化されたロガー
Statistics | IAppStatistics | アプリケーションの起動日時やそこからの経過時間、エラーの検知状況などの情報を保持するオブジェクト
Configuration | IAppConfiguration | 後述するアプリケーション・ランチャーの設定情報を保持するオブジェクト

デフォルトでは、あなたのアプリケーションが例外をスローしたり、ロガーを通じてエラーログを出力したりすると、アプリケーションの終了コードは `1` に設定されます。この値を変更する場合は次のように `IAppConfigurer` を通じてアプリケーション・ランチャーの設定を変更します：

```cs
App.Configure(c =>
{
	// エラーのときの終了ステータス・コードを2に変更
	c.SetStatusOnFailure(2);
})
.Start(new Program().Start, args);
```
