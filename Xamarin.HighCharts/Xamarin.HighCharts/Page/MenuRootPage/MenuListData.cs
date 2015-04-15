using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.HighCharts.Page.MenuRootPage
{
    public class MenuListData  : List<MenuRootIem>
    {
        public MenuListData()
        {
            this.Add(new MenuRootIem()
            {
                Title = "Login",
             //   IconSource = "contacts.png",
                TargetType = typeof(LoginUserPage)
            });

            this.Add(new MenuRootIem()
            {
                Title = "Register User",
                //   IconSource = "contacts.png",
                TargetType = typeof(RegisterUserPage)
            });



        }
    }
}
