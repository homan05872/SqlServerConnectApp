# SqlServerConnectApp
C#データベース接続のサンプルです。

# インストールしたNuget Package
目的別
- データベース接続：System.Data.SqlClient
- 設定ファイル：System.Configuration.ConfigurationManager

# サンプルの中身
DB接続サンプルは下記のDB_Connection.csの中に静的メソッドとして定義してあります。

```
SqlServerConnectApp
├─ Program.cs(メイン)
├─ App.config(リポジトリにはない)
└─services
      └─ DB_Connection.cs(DBで接続)
```

# 準備
App.configファイルはリポジトリに用意していないため、クローンした際は、作成し、設定を書く
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="DatabaseConnectionString" value="ここに接続文字列" />
		<!-- 他の設定値もここに追加できます -->
	</appSettings>
</configuration>
```
