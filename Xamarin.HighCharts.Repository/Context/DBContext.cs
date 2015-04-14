

using System.Collections.Generic;
using Xamarin.HighCharts.Repository.Context.Interface;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.Repository.Context
{
    public class DBContext<DBConnection> : IDBContext
        where DBConnection : class
    {
        #region Properties

        public IContext<DBConnection> Connection { get; private set; }
        public List<IDatabaseModel> Database  { get; set; }

        #endregion

        #region Constructor

        public DBContext()
        {
            Initialize();
        }

        #endregion

        #region IDBContext members

        public virtual void Initialize()
        {
            if (Connection != null) 
            {
                //Connection
            }
        }

        #endregion
        
    }
}
