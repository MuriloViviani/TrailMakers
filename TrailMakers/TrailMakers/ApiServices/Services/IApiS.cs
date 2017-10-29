using System.Collections.Generic;
using TrailMakers.Entity;

namespace TrailMakers.ApiServices.Services
{
    public interface IApiS
    {
        List<News> GetNewsAsync();
        List<Historic> GetUserHistoricAsync(int userId);
        User GetUserDataAsync(int userID);
    }
}
