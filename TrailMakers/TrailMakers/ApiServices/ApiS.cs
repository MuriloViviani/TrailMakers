using System;
using System.Collections.Generic;
using TrailMakers.ApiServices.Services;
using TrailMakers.Entity;

namespace TrailMakers.ApiServices
{
    public class ApiS : IApiS
    {
        public List<News> GetNewsAsync()
        {
            return new List<News>()
            {
                new News()
                {
                    Id = 0,
                    Name = "Novas trilhas disponiveis",
                    IntroText = "Novas trilhas disponiveis para o público",
                    NewsText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer luctus neque non dui rhoncus pharetra. Suspendisse odio nulla, aliquet at dapibus eu, condimentum eget felis. Quisque efficitur purus id mi laoreet hendrerit. Suspendisse consequat augue ullamcorper quam aliquet, eget fermentum nunc porttitor. Nam fringilla elementum pharetra. Integer tempor velit velit, non vulputate enim fringilla vel. Donec elementum id lacus in molestie. Pellentesque pellentesque sollicitudin enim, vel porttitor felis mollis ac. Donec laoreet dui sit amet metus dignissim, id iaculis diam dignissim. Duis vel ex non augue vulputate sollicitudin quis sed nulla.

Vestibulum dapibus, velit ac maximus tempus, tellus sem mollis eros, scelerisque vehicula libero odio sit amet diam. Vivamus lacinia tempor libero, imperdiet molestie turpis ornare id. Ut molestie, dolor id interdum vehicula, nisl elit mollis massa, ut porta lorem nunc vitae mauris. Phasellus sagittis est eget iaculis luctus. Praesent ultrices molestie molestie. Nam tortor diam, convallis sit amet nibh ac, rutrum mollis elit. Nulla a orci sit amet purus tempor bibendum.",
                    ImgWebPath = "",
                    Timestamp = DateTime.Now
                },
                new News()
                {
                    Id = 1,
                    Name = "Trilhas Apagadas",
                    IntroText = "Novas trilhas disponiveis para o público",
                    NewsText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer luctus neque non dui rhoncus pharetra. Suspendisse odio nulla, aliquet at dapibus eu, condimentum eget felis. Quisque efficitur purus id mi laoreet hendrerit. Suspendisse consequat augue ullamcorper quam aliquet, eget fermentum nunc porttitor. Nam fringilla elementum pharetra. Integer tempor velit velit, non vulputate enim fringilla vel. Donec elementum id lacus in molestie. Pellentesque pellentesque sollicitudin enim, vel porttitor felis mollis ac. Donec laoreet dui sit amet metus dignissim, id iaculis diam dignissim. Duis vel ex non augue vulputate sollicitudin quis sed nulla.

Vestibulum dapibus, velit ac maximus tempus, tellus sem mollis eros, scelerisque vehicula libero odio sit amet diam. Vivamus lacinia tempor libero, imperdiet molestie turpis ornare id. Ut molestie, dolor id interdum vehicula, nisl elit mollis massa, ut porta lorem nunc vitae mauris. Phasellus sagittis est eget iaculis luctus. Praesent ultrices molestie molestie. Nam tortor diam, convallis sit amet nibh ac, rutrum mollis elit. Nulla a orci sit amet purus tempor bibendum.",
                    ImgWebPath = "",
                    Timestamp = DateTime.Now
                }
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
                    Distance = 5.5d,
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
                    Distance = 1.2d,
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
                    Distance = 6.2d,
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
                    Distance = 11.2d,
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
    }
}
