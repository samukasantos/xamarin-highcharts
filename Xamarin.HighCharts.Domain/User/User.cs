
using Xamarin.HighCharts.Domain.Interfaces;
using Xamarin.HighCharts.InfraStructure.Domain;
using Xamarin.HighCharts.InfraStructure.Domain.Interfaces;

namespace Xamarin.HighCharts.Domain
{
    public class User : EntityBase<int>, IUser, IAggregateRoot
    {

        #region Properties

        public string Name      { get; set; }
        public string Email     { get; set; }
        public string Password  { get; set; }
        public bool Transaction { get; set; }

        #endregion

        #region Overridable
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                AddRule(UserBusinessRules.UserNameRequired);

            //Category.ThrowExceptionIfInvalid();
        }

        #endregion
    }
}
