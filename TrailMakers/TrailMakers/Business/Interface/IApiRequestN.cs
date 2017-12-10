using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.Entity;

namespace TrailMakers.Business.Interface
{
    public interface IApiRequestN
    {
        Task<List<News>> GetNewsAsync();
        Task<List<Trail>> SearchTrailsAsync(string username, string trailName);
        Trail GetTrailByIdAsync(int ID);
        Task<List<Historic>> GetUserHistoricAsync();
        void AddToUserHistoricAsync(Historic trail);
        User GetUserDataAsync(int userID);
    }
}
