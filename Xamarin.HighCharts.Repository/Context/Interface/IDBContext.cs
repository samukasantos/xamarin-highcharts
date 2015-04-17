
using System.Collections.Generic;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository.Context.Interface
{
    public interface IDBContext    {

        void Initialize<DatabaseType>()
            where DatabaseType : IDatabaseModel;

        void Save(IDatabaseModel databaseModel);
        void Update(IDatabaseModel databaseModel);
        void Delete(IDatabaseModel databaseModel);
        IEnumerable<T> FindAll<T>() where T : IDatabaseModel, new();
        List<DatabaseComplexType> ExecuteCrossQuery<DatabaseComplexType>(string query, params object[] parameters)
            where DatabaseComplexType : new();
    }
}
