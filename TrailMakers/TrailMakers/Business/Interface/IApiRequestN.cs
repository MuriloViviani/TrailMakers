using System.Collections.Generic;
using TrailMakers.Entity;

namespace TrailMakers.Business.Interface
{
    public interface IApiRequestN
    {
        List<News> GetNewsAsync();
        List<Historic> GetUserHistoricAsync();
        User GetUserDataAsync(int userID);
    }
}
