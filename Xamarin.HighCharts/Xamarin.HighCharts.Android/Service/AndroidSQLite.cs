
using System.IO;
using Xamarin.Forms;
using Xamarin.HighCharts.Droid.Service;
using Xamarin.HighCharts.Repository.Context.Interface;

[assembly: Dependency(typeof(AndroidSQLite))]
namespace Xamarin.HighCharts.Droid.Service
{

    public class AndroidSQLite : IContext<SQLite.Net.SQLiteConnection>
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "XamarinDB.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            return conn;
        }
    }
}