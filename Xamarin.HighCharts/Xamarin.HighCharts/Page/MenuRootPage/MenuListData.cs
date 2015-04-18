
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
                Title = "Registrar Usuário",
                //   IconSource = "contacts.png",
                TargetType = typeof(RegisterUserPage)
            });

			this.Add(new MenuRootIem()
				{
					Title = "Cadastrar Categoria",
					//   IconSource = "contacts.png",
					TargetType = typeof(CategoryPage)
				});

			this.Add(new MenuRootIem()
				{
					Title = "Despesa",
					//   IconSource = "contacts.png",
					TargetType = typeof(ExpensePage)
				});

            this.Add(new MenuRootIem()
            {
                Title = "Demostrativos",
                //   IconSource = "contacts.png",
                TargetType = typeof(ChartPageLines)
            });
			
            
        #endregion


        }
    }
}
