using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.ApiServices;
using TrailMakers.Business.Interface;
using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.Business
{
    public class ApiRequestN : IApiRequestN
    {
        private ApiS apiService = new ApiS();
        private ISaveAndLoad fileService = DependencyService.Get<ISaveAndLoad>();

        public async Task<List<News>> GetNewsAsync()
        {
            return await apiService.GetNewsAsync();
        }

        public User GetUserDataAsync(int userID)
        {
            return apiService.GetUserDataAsync(userID);
        }

        public List<Historic> GetUserHistoricAsync()
        {
            return apiService.GetUserHistoricAsync(0);
        }
    }
}
