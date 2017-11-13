using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.Entity;

namespace TrailMakers.Business.Interface
{
    public interface IApiRequestN
    {
        Task<List<News>> GetNewsAsync();
        List<Trail> SearchTrailsAsync(string username, string trailName);
        Trail GetTrailByIdAsync(int ID);
        List<Historic> GetUserHistoricAsync();
        User GetUserDataAsync(int userID);
    }
}
