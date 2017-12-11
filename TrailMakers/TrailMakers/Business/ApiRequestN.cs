using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrailMakers.ApiServices;
using TrailMakers.Business.Interface;
using TrailMakers.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
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
            var list = JsonConvert.DeserializeObject<List<Historic>>(await fileService.LoadTextAsync("historic.json"));

            if (list != null)
            {
                foreach (var item in list)
                {
                    item.Distance = "Distância: " + item.Distance;

                    if (item.Poi != null)
                    {
                        item.Poi = FixPOI(item.Poi);
                    }

                    var mainPos = SetMainPositions(item.TrailPath);
                    item.MainLatitude = mainPos[0];
                    item.MainLongitude = mainPos[1];
                }
            }

            return list;
        }

        public async void AddToUserHistoricAsync(Historic trail)
        {
            var list = new List<Historic>();
            if (fileService.CheckFile("historic.json", false))
                list = JsonConvert.DeserializeObject<List<Historic>>(await fileService.LoadTextAsync("historic.json"));

            list.Add(trail);

            await fileService.SaveTextAsync("historic.json", JsonConvert.SerializeObject(list));
        }

        public Trail GetTrailByIdAsync(int ID)
        {
            return apiService.GetTrailByIDAsync(ID);
        }

        public async Task<List<Trail>> SearchTrailsAsync(string username, string trailName)
        {
            var list = await apiService.GetTrailSearchAsync();
            if (list != null)
            {
                foreach (var item in list)
                {
                    var aux = item.Time.ToString("hh:mm").Split(':');
                    item.TimeShownd = aux[0] + "Hrs " + aux[1] + "Min";

                    item.DistShownd = "Distância: " + item.Distance;

                    if (item.POIList != null)
                    {
                        item.POIList = FixPOI(item.POIList);
                    }
                }
            }

            return list;
        }

        private double[] SetMainPositions(List<Location> positions)
        {
            double[] LongLat = new double[2];

            foreach (var pos in positions)
            {
                LongLat[0] += pos.Latitude;
                LongLat[1] += pos.Longitude;
            }

            LongLat[0] /= positions.Count;
            LongLat[1] /= positions.Count;

            return LongLat;
        }

        private List<POI> FixPOI(List<POI> points)
        {
            foreach (var poi in points)
            {
                if (poi.Type.Equals(DataAndHelper.Data.PinType.Danger))
                {
                    poi.IconUlr = DANGER_MAP_ICON;
                    poi.PoiID = 1;
                    poi.Description = "CUIDADO! \nAlgo de estranho foi reportado aqui!\n\npode ser que existal algum buraco, ponto de alagamento ou coisas parecidas por perto! é necessário cautela!";
                }
                else if (poi.Type.Equals(DataAndHelper.Data.PinType.Help))
                {
                    poi.IconUlr = HELP_REQUEST_MAP_ICON;
                    poi.PoiID = 3;
                    poi.Description = "Oh não!\nParece que alguem precisa de ajuda, você poderia ajuda-lo?";
                }
                else if (poi.Type.Equals(DataAndHelper.Data.PinType.Turism))
                {
                    poi.IconUlr = PICTURE_POINT_MAP_ICON;
                    poi.PoiID = 5;
                    poi.Description = "OMG!\nEsse é um ponto da trilha maravilhoso para recordar!\n\nCaso esteja em busca de ótimas fotos para suas redes sociais ou para seu perfil aqui é um ótimo lugar!";
                }
                else if (poi.Type.Equals(DataAndHelper.Data.PinType.Begin))
                {
                    poi.IconUlr = BEGIN_MAP_ICON;
                    poi.PoiID = 0;
                    poi.Description = "Ponto de inicio da trilha";
                }
                else if (poi.Type.Equals(DataAndHelper.Data.PinType.End))
                {
                    poi.IconUlr = END_MAP_ICON;
                    poi.PoiID = 2;
                    poi.Description = "Fim da trilha =)";
                }
                else if (poi.Type.Equals(DataAndHelper.Data.PinType.Rest))
                {
                    poi.IconUlr = REST_MAP_ICON;
                    poi.PoiID = 4;
                    poi.Description = "Finalmente!\n Aqui parece ser um ótimo ponto para descansar um pouco depois de um tempo de exercício! (Phew!)";
                }
                else if (poi.Type.Equals(DataAndHelper.Data.PinType.Water))
                {
                    poi.IconUlr = WATER_MAP_ICON;
                    poi.PoiID = 6;
                    poi.Description = "Parece que existe um ponto para que você possa encher seu cantiu por aqui!\n\nPode ser algo de bom proveito =D";
                }

                if (!fileService.CheckFile(poi.IconUlr, true))
                {
                    fileService.SaveImage(poi.IconUlr.Replace("/", "_").Replace(".", "_"), poi.IconUlr);
                }
            }

            return points;
        }
    }
}
