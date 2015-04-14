
namespace Xamarin.HighCharts.Repository.Context.Interface
{
    public interface IContext<DBConnection>
        where DBConnection : class
    {
        DBConnection GetConnection();
    }
}
