

using System.Collections.Generic;
using System.Linq;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository;
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.Repository.Database.User;
using Xamarin.HighCharts.Repository.Database.User.Interfaces;

namespace Xamarin.HighCharts.DataAccess.Repositories
{
    public class UserRepository : Repository<User, UserDatabase>, IUserRepository
    {
    
        #region Methods

        public override IDatabaseModel ConvertToDatabaseType(IAggregateRoot aggregateRoot)
        {
            var user = aggregateRoot as IUser;
            if (user == null) return null;

            return new UserDatabase
            {
                Id          = (aggregateRoot as EntityBase<User>).Id,
                Name        = user.Name,
                Email       = user.Email,
                Password    = user.Password,
                Transaction = user.Transaction
            };
        }

        public override User FindByToken(string id)
        {
            return FindAll().FirstOrDefault(c => c.UUID == id);
        }

        public User FindById(int id)
        {
            return FindAll().FirstOrDefault(c => c.Id == id);
        }

        #endregion

        #region IUserRepository members
        public IEnumerable<User> FindAll()
        {
            var users     = new List<User>();
            var dataItems = DBContext.FindAll<UserDatabase>();

            foreach (var item in dataItems)
                users.Add(ConvertToDomain(item));

            return users;
        }

        private User ConvertToDomain(IDatabaseModel databaseModel) 
        {
            var current = databaseModel as IUserDatabase;
            if (current == null) return null;

            return new User
            {
                Id          = databaseModel.Id,
                Name        = current.Name,
                Password    = current.Password,
                Email       = current.Email,
                Transaction = current.Transaction
            };
        }

        #endregion

    }
}
