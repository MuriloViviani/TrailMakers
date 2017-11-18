using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.Entity;

namespace TrailMakers.ApiServices.Services
{
    public interface IApiS
    {
        Task<List<News>> GetNewsAsync();
        Task<List<Historic>> GetUserHistoricAsync(int userId);
        User GetUserDataAsync(int userID);
        Task<List<Trail>> GetTrailSearchAsync();
    }
}
