

using Xamarin.HighCharts.InfraStructure.Domain;

namespace Xamarin.HighCharts.Domain.Entities
{
    public static class UserBusinessRules
    {
        #region Fields

        //TODO .: Use internationalization for messages.
        public static readonly BusinessRules Required         = new BusinessRules("{0} is required.");
        public static readonly BusinessRules Invalid          = new BusinessRules("{0} is invalid.");
        public static readonly BusinessRules NameRequired     = new BusinessRules(string.Format("Name", Required));
        public static readonly BusinessRules EmailRequired    = new BusinessRules(string.Format("Email", Required));
        public static readonly BusinessRules PasswordRequired = new BusinessRules(string.Format("Password", Required));
        public static readonly BusinessRules InvalidEmail     = new BusinessRules(string.Format("Email", Invalid));
        

        #endregion

    }
}
