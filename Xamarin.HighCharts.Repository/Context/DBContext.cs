

using System.Collections.Generic;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository.Context
{
    public class DBContext<DBConnection> : IDBContext
        where DBConnection : class
    {
        #region Properties

        public IContext<DBConnection> Connection { get; private set; }

        #endregion

        #region Constructor

        public DBContext(){}

        #endregion

        #region IDBContext members

        public virtual void Initialize<DatabaseType>()
            where DatabaseType : IDatabaseModel
        {
            #region SQLite-Net

            if (Connection != null) 
            {
                var connection = Connection.GetConnection() as SQLite.Net.SQLiteConnection;
                connection.CreateTable<DatabaseType>();
            }

            #endregion
        }

        public virtual void Initialize<DatabaseType>()
           where DatabaseType : IDatabaseModel
        {
            #region SQLite-Net

            if (Connection != null)
            {
                var connection = Connection.GetConnection() as SQLite.Net.SQLiteConnection;
                connection.CreateTable<DatabaseType>();
            }

            #endregion
        }

        public void Save(IDatabaseModel databaseModel)
        {
            #region SQLite-Net

            if (Connection != null)
            {
                var connection = Connection.GetConnection() as SQLite.Net.SQLiteConnection;
                connection.Insert(databaseModel);
            }

            #endregion
        }

        public void Update(IDatabaseModel databaseModel)
        {
            #region SQLite-Net

            if (Connection != null)
            {
                var connection = Connection.GetConnection() as SQLite.Net.SQLiteConnection;
                connection.Update(databaseModel);
            }

            #endregion
        }

        public void Delete(IDatabaseModel databaseModel)
        {
            #region SQLite-Net

            if (Connection != null)
            {
                var connection = Connection.GetConnection() as SQLite.Net.SQLiteConnection;
                connection.Delete(databaseModel);
            }

            #endregion
        }


        #endregion
       
    }
}
