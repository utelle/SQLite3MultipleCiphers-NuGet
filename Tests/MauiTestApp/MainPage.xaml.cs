using Dapper;
using Microsoft.Data.Sqlite;

namespace MauiTestApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        try
        {
            var dataSource = "Test.db";

#if ANDROID
            dataSource = Path.Combine(FileSystem.Current.AppDataDirectory, dataSource);
#endif

            using var connection = new SqliteConnection($"Data Source={dataSource};Password=Password12!");

            VersionLbl.Text = connection.ExecuteScalar<string>("SELECT sqlite3mc_version()");
        }
        catch (Exception ex)
        {
            VersionLbl.Text = ex.ToString();
        }
    }
}

