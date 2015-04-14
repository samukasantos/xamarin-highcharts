
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
        IEnumerable<IDatabaseModel> FindAll();

    }
}
