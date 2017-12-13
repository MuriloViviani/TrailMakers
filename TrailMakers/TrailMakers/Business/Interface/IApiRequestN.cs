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
        Task<bool> AddToUserHistoricAsync(Historic trail);
        Task<User> GetUserDataAsync();
        bool SetUserData(User user);
        Task<Historic> GetLastTrail();
        void SetLastTrail(Historic historic);
    }
}
