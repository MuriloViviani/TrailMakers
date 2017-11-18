using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.ApiServices;
using TrailMakers.Business.Interface;
using TrailMakers.Entity;
using Xamarin.Forms;
using static TrailMakers.DataAndHelper.Data;

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

        public async Task<List<Historic>> GetUserHistoricAsync()
        {
            return await apiService.GetUserHistoricAsync(0);
        }

        public Trail GetTrailByIdAsync(int ID)
        {
            return apiService.GetTrailByIDAsync(ID);
        }

        public async Task<List<Trail>> SearchTrailsAsync(string username, string trailName)
        {
            var list = await apiService.GetTrailSearchAsync();
            foreach (var item in list)
            {
                var aux = item.Time.ToString("hh:mm").Split(':');
                item.TimeShownd = aux[0] + "Hrs " + aux[1] + "Min";

                item.DistShownd = "Distância: " + item.Distance;

                if (item.POIList != null)
                {
                    foreach (var poi in item.POIList)
                    {
                        if (poi.Type.Equals(PinType.Danger))
                            poi.IconUlr = DANGER_MAP_ICON;
                        else if (poi.Type.Equals(PinType.Help))
                            poi.IconUlr = HELP_REQUEST_MAP_ICON;
                        else if (poi.Type.Equals(PinType.Turism))
                            poi.IconUlr = PICTURE_POINT_MAP_ICON;
                        else if (poi.Type.Equals(PinType.Begin))
                            poi.IconUlr = NEW_TRAIL_ICON;
                        else if (poi.Type.Equals(PinType.End))
                            poi.IconUlr = END_MAP_ICON;
                        else if (poi.Type.Equals(PinType.Rest))
                            poi.IconUlr = REST_MAP_ICON;
                        else if (poi.Type.Equals(PinType.Water))
                            poi.IconUlr = WATER_MAP_ICON;

                        if (!fileService.CheckFile(poi.IconUlr, true))
                        {
                            fileService.SaveImage(poi.IconUlr.Replace("/", "_").Replace(".", "_"), poi.IconUlr);
                        }
                    }
                }
            }

            return list;
        }
    }
}
