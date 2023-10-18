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