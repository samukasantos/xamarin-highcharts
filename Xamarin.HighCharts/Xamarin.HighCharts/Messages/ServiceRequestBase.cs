using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.HighCharts.Domain;
using Xamarin.HighCharts.WCFHighChartsService;

namespace Xamarin.HighCharts.Messages
{
    public class ServiceRequestBase
    {

        private WCFHighChartsServiceClient _client;

        public WCFHighChartsServiceClient Client
        {
            get
            {

                if (_client == null)
                    _client = new WCFHighChartsServiceClient();
                return _client;
            }

        }


        #region Validate User

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Login"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool ValidateUser(string Login, string Password)
        {
            var asyncCallStatus = new AsyncCallStatus<ValidateUserCompletedEventArgs>();
            Client.ValidateUserCompleted += Client_ValidateUserCompleted;
            Client.ValidateUserAsync(Login, Password, asyncCallStatus);
            _autoResetEvent.WaitOne();

            if (asyncCallStatus.CompletedEventArgs.Error != null)
            {
                throw asyncCallStatus.CompletedEventArgs.Error;
            }
            return asyncCallStatus.CompletedEventArgs.Result;


        }

        void Client_ValidateUserCompleted(object sender, ValidateUserCompletedEventArgs e)
        {
            var status = e.UserState as AsyncCallStatus<ValidateUserCompletedEventArgs>;
            if (status != null) status.CompletedEventArgs = e;
            _autoResetEvent.Set();
        }


        #endregion

        #region Create User
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
            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion
        private readonly AutoResetEvent _autoResetEvent = new AutoResetEvent(false);

        public class AsyncCallStatus<T>
        {
            public T CompletedEventArgs { get; set; }
        }


    }
}
