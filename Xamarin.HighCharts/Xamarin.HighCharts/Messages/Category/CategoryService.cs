

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Highcharts.Domain.ValueObjects;
using Xamarin.HighCharts.Base.Messages;
using Xamarin.HighCharts.Domain.ValueObjects;
using Xamarin.HighCharts.InfraStructure.DependencyService;
using Xamarin.HighCharts.Messages.Base;
using Xamarin.HighCharts.Repository.Database.Interfaces;
using Xamarin.HighCharts.WCFHighChartsService;
using System.Linq.Expressions;
using System.Linq;

namespace Xamarin.HighCharts.Messages
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public IValueObjectRepository<Category> Repository
        {
            get { return DependencyResolver.Container.GetService<IValueObjectRepository<Category>>(); }
        }
        /// <summary>
        ///  Insert new category in service.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool AddCategory(Category category)
        {

            try
            {
                var json = JsonConvert.SerializeObject(category);


                var asyncCallStatus = new AsyncCallStatus<AddCategoryCompletedEventArgs>();
                Client.AddCategoryCompleted += (sender, args) =>
                {
                    var status = args.UserState as AsyncCallStatus<AddCategoryCompletedEventArgs>;
                    if (status != null)
                        status.CompletedEventArgs = args;

                    AutoResetEvent.Set();
                };

                Client.AddCategoryAsync(json);
                AutoResetEvent.WaitOne();

                return true;


            }
            catch (Exception operationException)
            {
                CurrentException = operationException;
                return false;
            }
        }


        /// <summary>
        /// Retreview default category for aplication
        /// </summary>

        public void GetAllCategoryInCloud()
        {

            try
            {

                var categoryRepository = DependencyResolver.Container.GetService<ICategoryRepository>();

                var asyncCallStatus = new AsyncCallStatus<GetAllCategoryCompletedEventArgs>();
                Client.GetAllCategoryCompleted += (sender, args) =>
                {
                    var status = args.UserState as AsyncCallStatus<GetAllCategoryCompletedEventArgs>;
                    if (status != null)
                        status.CompletedEventArgs = args;

                    AutoResetEvent.Set();
                };

                Client.GetAllCategoryAsync(string.Empty, asyncCallStatus);
                AutoResetEvent.WaitOne();

                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(asyncCallStatus.CompletedEventArgs.Result);


                
                
                var allCategoryDataBase = categoryRepository.FindAll().ToList();
                foreach (var cat in categories)
                {
                    if (!allCategoryDataBase.Where(p => p.Description == cat.Description).Any())
                        Repository.Save(cat);
                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
