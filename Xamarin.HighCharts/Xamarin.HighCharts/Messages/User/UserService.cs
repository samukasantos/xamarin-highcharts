
using Newtonsoft.Json;
using System;
using Xamarin.HighCharts.Base.Messages;
using Xamarin.HighCharts.Domain.Entities;
using Xamarin.HighCharts.Messages.Base;
using Xamarin.HighCharts.WCFHighChartsService;

namespace Xamarin.HighCharts.Messages
{
    public class UserService : ServiceBase, IUserService
    {
        #region IUserService members
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                Client.AddUserAsync(json);

                return true;
            }
            catch (Exception operationException)
            {
                CurrentException = operationException;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateUser(string login, string password)
        {
            var asyncCallStatus = new AsyncCallStatus<ValidateUserCompletedEventArgs>();

            Client.ValidateUserCompleted += (sender, args) =>
            {
                var status = args.UserState as AsyncCallStatus<ValidateUserCompletedEventArgs>;
                if (status != null) 
                    status.CompletedEventArgs = args;

                AutoResetEvent.Set();
            };

            Client.ValidateUserAsync(login, password, asyncCallStatus);
            
            AutoResetEvent.WaitOne();

            if (asyncCallStatus.CompletedEventArgs.Error != null)
            {
                throw asyncCallStatus.CompletedEventArgs.Error;
            }
            return asyncCallStatus.CompletedEventArgs.Result;

        }

        #endregion
    }
}
