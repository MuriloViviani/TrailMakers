using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TrailMakers.ApiServices.Services;
using TrailMakers.Entity;

namespace TrailMakers.ApiServices
{
    public class ApiS : IApiS
    {
        public async Task<List<News>> GetNewsAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string retorno = await httpClient.GetStringAsync(ConfigAPI.URL_NEWS);

                return JsonConvert.DeserializeObject<List<News>>(retorno);
            }
        }

        public User GetUserDataAsync(int userID)
        {
            return new User()
            {
                UserId = 1,
                Name = "Murilo",
                Password = "123456",
                Username = "mviviani",
                Age = 20
            };
        }

        public List<Historic> GetUserHistoricAsync(int userId)
        {
            return new List<Historic>()
            {
                new Historic()
                {
                    Id = 0,
                    Name = "Trilha dos palmares",
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),
                    Distance = "5.5",
                    TimeSpent = "5h2m",
                    TrailPath = new List<Location>()
                    {
                        new Location{
                            Latitude = -23.359233,
                            Longitude = -46.735372
                        },
                        new Location{
                            Latitude = -23.358934,
                            Longitude = -46.735474
                        },
                        new Location {
                            Latitude = -23.358448,
                            Longitude = -46.735365
                        },
                        new Location{
                            Latitude = -23.358199,
                            Longitude = -46.735219
                        },
                        new Location{
                            Latitude = -23.357896,
                            Longitude = -46.735614
                        },
                        new Location {
                            Latitude = -23.357607,
                            Longitude = -46.736103
                        }
                    }
                },
                new Historic()
                {
                    Id = 1,
                    Name = "Trilha dos desesperados",
                    Date = DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy"),
                    Distance = "1.2",
                    TimeSpent = "1h50m",
                    TrailPath = new List<Location>()
                    {
                        new Location{
                            Latitude = -23.359233,
                            Longitude = -46.735372
                        },
                        new Location{
                            Latitude = -23.358934,
                            Longitude = -46.735474
                        },
                        new Location {
                            Latitude = -23.358448,
                            Longitude = -46.735365
                        },
                        new Location{
                            Latitude = -23.358199,
                            Longitude = -46.735219
                        },
                        new Location{
                            Latitude = -23.357896,
                            Longitude = -46.735614
                        },
                        new Location {
                            Latitude = -23.357607,
                            Longitude = -46.736103
                        }
                    }
                },
                new Historic()
                {
                    Id = 2,
                    Name = "Calçadão",
                    Date = DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy"),
                    Distance = "6.2",
                    TimeSpent = "2h20m",
                    TrailPath = new List<Location>()
                    {
                        new Location{
                            Latitude = -23.359233,
                            Longitude = -46.735372
                        },
                        new Location{
                            Latitude = -23.358934,
                            Longitude = -46.735474
                        },
                        new Location {
                            Latitude = -23.358448,
                            Longitude = -46.735365
                        },
                        new Location{
                            Latitude = -23.358199,
                            Longitude = -46.735219
                        },
                        new Location{
                            Latitude = -23.357896,
                            Longitude = -46.735614
                        },
                        new Location {
                            Latitude = -23.357607,
                            Longitude = -46.736103
                        }
                    }
                },
                new Historic()
                {
                    Id = 3,
                    Name = "Trilha das uvas",
                    Date = DateTime.Now.AddDays(-6).ToString("dd/MM/yyyy"),
                    Distance = "11.2",
                    TimeSpent = "10h23m",
                    TrailPath = new List<Location>()
                    {
                        new Location{
                            Latitude = -23.359233,
                            Longitude = -46.735372
                        },
                        new Location{
                            Latitude = -23.358934,
                            Longitude = -46.735474
                        },
                        new Location {
                            Latitude = -23.358448,
                            Longitude = -46.735365
                        },
                        new Location{
                            Latitude = -23.358199,
                            Longitude = -46.735219
                        },
                        new Location{
                            Latitude = -23.357896,
                            Longitude = -46.735614
                        },
                        new Location {
                            Latitude = -23.357607,
                            Longitude = -46.736103
                        }
                    }
                }
            };
        }

        public List<Trail> SearchTrailAsync(string username, string trailName)
        {
            // Search by the creator of the trail
            if (!String.IsNullOrEmpty(username))
            {
                return new List<Trail>()
                {
                    new Trail()
                    {
                        ID = 0,
                        TrailName = "Teste",
                        TrailDescription = "Teste de trilhas",
                        Rating = 4,
                        MainLatitude = -23.359240f,
                        MainLongitude = -46.735410f,
                        Distance = "0.5",
                        Time = "1h 45m",
                        User = new User()
                        {
                            Username = "Teste",
                            Age = 20,
                            UserId = 0,
                        }
                    }
                };
            }
            else // Search by the trail name
            {
                return new List<Trail>()
                {
                    new Trail()
                    {
                        ID = 0,
                        TrailName = "Teste 2",
                        TrailDescription = "Teste de trilhas 2",
                        Rating = 4,
                        MainLatitude = -23.359240f,
                        MainLongitude = -46.735410f,
                        Distance = "0.5",
                        Time = "1h 45m",
                        User = new User()
                        {
                            Username = "Teste",
                            Age = 20,
                            UserId = 0,
                        }
                    }
                };
            }
        }

        public Trail GetTrailByIDAsync(int iD)
        {
            return new Trail()
            {
                ID = 0,
                TrailName = "Teste",
                TrailDescription = "Teste de trilhas",
                Rating = 4,
                MainLatitude = -23.359240f,
                MainLongitude = -46.735410f,
                Distance = "0.5",
                Time = "1h 45m",
                User = new User()
                {
                    Username = "Teste",
                    Age = 20,
                    UserId = 0,
                }
            };
        }
    }
}
