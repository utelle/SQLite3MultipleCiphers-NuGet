using System.Reflection;
using Dapper;
using Microsoft.Data.Sqlite;

using static SQLitePCL.raw;

public class Tests : IDisposable
{
    public Tests()
    {
        using var connection = new SqliteConnection("Data Source=Test.db;Password=Password12!");

        connection.Execute("create table test(value)");
        connection.Execute("insert into test values ('testing')");
    }

    [Fact]
    public void Can_query()
    {
        using var connection = new SqliteConnection("Data Source=Test.db;Password=Password12!");

        var value = connection.ExecuteScalar<string>("select value from test");

        Assert.Equal("testing", value);
    }

    [Fact]
    public void Database_is_encrypted()
    {
        using var connection = new SqliteConnection("Data Source=Test.db;Password=Wrong1!");

        var ex = Assert.Throws<SqliteException>(connection.Open);

        Assert.Equal(SQLITE_NOTADB, ex.SqliteErrorCode);
    }

    [Fact]
    public void Database_is_SQLCipher4()
    {
        // Test to access database encrypted with SQLCipher version 4
        // Result: 78536 1 1 one one 1 2 one two
        using var connection = new SqliteConnection("Data Source=file:sqlcipher-4.0-testkey.db?cipher=sqlcipher&legacy=4&key=testkey");

        var value = connection.ExecuteScalar<int>("select count(*) from t1");

        Assert.Equal(78536, value);
    }

    [Fact]
    public void Database_is_custom_SQLCipher2()
    {
        // Test to access database encrypted with SQLCipher version 2
        // using 4000 iterations for the HMAC key derivation and a HMAC salt mask of zero
        // Result: 38768 test-0-0 test-0-1 test-1-0 test-1-1
        using var connection = new SqliteConnection("Data Source=file:sqlcipher-2.0-beta-testkey.db?cipher=sqlcipher&legacy=2&fast_kdf_iter=4000&hmac_salt_mask=0&key=testkey");

        var value = connection.ExecuteScalar<int>("select count(*) from t1");

        Assert.Equal(38768, value);
    }

    [Fact]
    public void SQLite3MC_version_matches()
    {
        using var connection = new SqliteConnection("Data Source=:memory:");
        var expected = connection.ExecuteScalar<string>("select substr(sqlite3mc_version(), 26)");

        var actual = typeof(Tests).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
            .SingleOrDefault(a => a.Key == "Sqlite3MCVersion")
            ?.Value;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SQLite_version_matches()
    {
        using var connection = new SqliteConnection("Data Source=:memory:");
        var expected = connection.ExecuteScalar<string>("select sqlite_version()");

        var actual = typeof(Tests).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
            .SingleOrDefault(a => a.Key == "SQLiteVersion")
            ?.Value;

        Assert.Equal(expected, actual);
    }

    public void Dispose()
    {
        SqliteConnection.ClearAllPools();

        var deleted = false;
        while (!deleted)
        {
            try
            {
                File.Delete("Test.db");
                deleted = true;
            }
            catch (IOException)
            {
            }
        }
    }
}
