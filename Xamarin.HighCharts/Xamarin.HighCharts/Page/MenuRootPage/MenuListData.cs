
using ChartsF.Pages;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.HighCharts.Page.MenuRootPage
{
    public class MenuListData  : List<MenuRootIem>
    {
        #region Constructor
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
                Title = "User Register",
                //IconSource = "ic_usuario.png",
                TargetType = typeof(RegisterUserPage)
            });

			this.Add(new MenuRootIem()
				{
					Title = "Category",
					//   IconSource = "contacts.png",
					TargetType = typeof(CategoryPage)
				});

			this.Add(new MenuRootIem()
				{
					Title = "Expense",
					//   IconSource = "contacts.png",
                    TargetType = typeof(CarouselExpensePage)
				});

            this.Add(new MenuRootIem()
            {
                Title = "Demonstrative Chart",
                //   IconSource = "contacts.png",
                TargetType = typeof(ChartPageLines)
            });
			
            
        #endregion


        }
    }
}
