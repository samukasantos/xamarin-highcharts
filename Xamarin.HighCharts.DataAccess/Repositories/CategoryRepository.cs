
using System.Collections.Generic;
using System.Linq;
using Xamarin.Highcharts.Domain.ValueObjects;
using Xamarin.HighCharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;
using Xamarin.HighCharts.Repository;
using Xamarin.HighCharts.Repository.Database.Category;
using Xamarin.HighCharts.Repository.Database.Category.Interfaces;
using Xamarin.HighCharts.Repository.Database.Interfaces;

namespace Xamarin.HighCharts.DataAccess.Repositories
{
    public class CategoryRepository : ValueObjectRepository<Category, CategoryDatabase>, ICategoryRepository
    {
        #region Methods

        public override IDatabaseModel ConvertToDatabaseType(IValueObject valueObject)
        {
            var category = valueObject as ICategory;
            if (category == null) return null;

            return new CategoryDatabase
            {
                Id = (valueObject as ValueObject).Id,
                Description = category.Description
            };
        }

        public override Category FindById(int id)
        {
            return FindAll().FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region ICategoryRepository members
        public IEnumerable<Category> FindAll()
        {
            var categories = new List<Category>();
            var dataItems = DBContext.FindAll<CategoryDatabase>();

            foreach (var item in dataItems)
                categories.Add(ConvertToDomain(item));

            return categories;
        }

        private Category ConvertToDomain(IDatabaseModel databaseModel)
        {
            var current = databaseModel as ICategoryDatabase;
            if (current == null) return null;

            return new Category
            {
                Id = databaseModel.Id,
                Description =  current.Description
            };
        }

        #endregion
    }
}
