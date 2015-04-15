
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.HighCharts.iOS.Service;
using Xamarin.HighCharts.Repository.Context.Interface;


[assembly: Dependency(typeof(iOSSQLite))]
namespace Xamarin.HighCharts.iOS.Service
{
    public class iOSSQLite : IContext<SQLite.Net.SQLiteConnection>
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "XamarinDB.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); 
            string libraryPath   = Path.Combine(documentsPath, "..", "Library"); 
            var path             = Path.Combine(libraryPath, sqliteFilename);
            
            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            return conn;
        }
    }
}
