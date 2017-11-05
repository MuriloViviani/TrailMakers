using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.Entity;

namespace TrailMakers.Business.Interface
{
    public interface IApiRequestN
    {
        Task<List<News>> GetNewsAsync();
        List<Historic> GetUserHistoricAsync();
        User GetUserDataAsync(int userID);
    }
}
