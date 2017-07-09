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
Statistics | IAppStatistics | アプリケーションの起動日時やそこからの経過時間、エラーの検知状況などの情報を保持するオブジェクト
Logger | IAppLogger | 実行中のアプリケーションのために初期化されたロガー

