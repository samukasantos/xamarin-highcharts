
using System.Text.RegularExpressions;

namespace Xamarin.HighCharts.Domain.Extensions
{
    public static class UtilityRules
    {
        public static bool IsEmail(this string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                return regex.Match(email).Success;
            }
            return false;
        }

    }
}
