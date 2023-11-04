# SQLite3 Multiple Ciphers

![build status](https://img.shields.io/github/actions/workflow/status/utelle/SQLite3MultipleCiphers-NuGet/dotnet.yml?branch=main) [![latest version](https://img.shields.io/nuget/v/SQLitePCLRaw.bundle_sqlite3mc)](https://www.nuget.org/packages/SQLitePCLRaw.bundle_sqlite3mc) [![downloads](https://img.shields.io/nuget/dt/SQLitePCLRaw.bundle_sqlite3mc)](https://www.nuget.org/packages/SQLitePCLRaw.bundle_sqlite3mc) ![license](https://img.shields.io/github/license/utelle/SQLite3MultipleCiphers-NuGet)

This library provides C#/.NET bindings for [SQLite3 Multiple Ciphers](https://utelle.github.io/SQLite3MultipleCiphers/). It leverages [SQLitePCLRaw](https://github.com/ericsink/SQLitePCL.raw#readme) to create the bindings.

## Installation

The latest version is available on [NuGet](https://www.nuget.org/packages/SQLitePCLRaw.bundle_sqlite3mc).

```sh
dotnet add package SQLitePCLRaw.bundle_sqlite3mc
```

:warning: **Warning!** Don't use multiple SQLitePCLRaw bundles in the same project. See the instructions below for details.

## Usage

Because the bindings are built using SQLitePCLRaw, you can use them with various .NET libraries.

### Microsoft.Data.Sqlite

For [Microsoft.Data.Sqlite](https://learn.microsoft.com/dotnet/standard/data/sqlite/), be sure to use the [Microsoft.Data.Sqlite.Core](https://www.nuget.org/packages/Microsoft.Data.Sqlite.Core) package instead of the main one to avoid using multiple bundles.

```cs
using Microsoft.Data.Sqlite;

using var connection = new SqliteConnection("Data Source=example.db;Password=Password12!");
connection.Open();

var command = connection.CreateCommand();
command.CommandText = "select sqlite3mc_version()";
var version = (string)command.ExecuteScalar()!;

Console.WriteLine(version);
```

### Dapper

Use [Dapper](https://dapperlib.github.io/Dapper/) with Microsoft.Data.Sqlite by following the same instructions detailed above.

```cs
using Dapper;
using Microsoft.Data.Sqlite;

using var connection = new SqliteConnection("Data Source=example.db;Password=Password12!");
var version = connection.ExecuteScalar<string>("select sqlite3mc_version()");
Console.WriteLine(version);
```

### EF Core

[EF Core](https://learn.microsoft.com/ef/core/) is built on top of Microsoft.Data.Sqlite. Be sure to use the [Microsoft.EntityFrameworkCore.Sqlite.Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite.Core) package instead of the main one to avoid using multiple bundles.

```
options.UseSqlite("Data Source=example.db;Password=Password12!");
```

### SQLite-net

With [SQLite-net](https://github.com/praeclarum/sqlite-net#readme), be sure to use the [sqlite-net-base](https://www.nuget.org/packages/sqlite-net-base) package instead of the main one to avoid using multiple bundles.

```cs
using SQLite;

SQLitePCL.Batteries_V2.Init();

var connection = new SQLiteConnection(new("example.db", storeDateTimeAsTicks: true, key: "Password12!"));
var version = connection.ExecuteScalar<string>("select sqlite3mc_version()");
Console.WriteLine(version);
```

### Low-level bindings

If you *really* want to use the low-level bindings directly, you can. But these are primarly intended to be used by libraries like Microsoft.Data.Sqlite and SQLite-net.

```cs
using static SQLitePCL.raw;

SQLitePCL.Batteries_V2.Init();

var rc = sqlite3_open("example.db", out var db);
if (rc != SQLITE_OK) return;
using (db)
{
    rc = sqlite3_key(db, "Password12!"u8);
    if (rc != SQLITE_OK) return;

    rc = sqlite3_prepare_v2(db, "select sqlite3mc_version()", out var stmt);
    if (rc != SQLITE_OK) return;
    using (stmt)
    {
        rc = sqlite3_step(stmt);
        if (rc != SQLITE_ROW) return;

        var version = sqlite3_column_text(stmt, 0).utf8_to_string();
        Console.WriteLine(version);
    }
}
```

## See also

- [SQLite3 Multiple Ciphers](https://utelle.github.io/SQLite3MultipleCiphers/)
- [Microsoft.Data.Sqlite](https://learn.microsoft.com/dotnet/standard/data/sqlite/)
- [SQLite-net](https://github.com/praeclarum/sqlite-net#readme)
