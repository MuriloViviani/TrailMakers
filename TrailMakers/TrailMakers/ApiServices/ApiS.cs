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
                    LilText = "Novas trilhas disponiveis para o público",
                    BigText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer luctus neque non dui rhoncus pharetra. Suspendisse odio nulla, aliquet at dapibus eu, condimentum eget felis. Quisque efficitur purus id mi laoreet hendrerit. Suspendisse consequat augue ullamcorper quam aliquet, eget fermentum nunc porttitor. Nam fringilla elementum pharetra. Integer tempor velit velit, non vulputate enim fringilla vel. Donec elementum id lacus in molestie. Pellentesque pellentesque sollicitudin enim, vel porttitor felis mollis ac. Donec laoreet dui sit amet metus dignissim, id iaculis diam dignissim. Duis vel ex non augue vulputate sollicitudin quis sed nulla.

Vestibulum dapibus, velit ac maximus tempus, tellus sem mollis eros, scelerisque vehicula libero odio sit amet diam. Vivamus lacinia tempor libero, imperdiet molestie turpis ornare id. Ut molestie, dolor id interdum vehicula, nisl elit mollis massa, ut porta lorem nunc vitae mauris. Phasellus sagittis est eget iaculis luctus. Praesent ultrices molestie molestie. Nam tortor diam, convallis sit amet nibh ac, rutrum mollis elit. Nulla a orci sit amet purus tempor bibendum.",
                    ImgWebPath = "",
                    Timestamp = DateTime.Now
                },
                new News()
                {
                    Id = 1,
                    Name = "Trilhas Apagadas",
                    LilText = "Novas trilhas disponiveis para o público",
                    BigText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer luctus neque non dui rhoncus pharetra. Suspendisse odio nulla, aliquet at dapibus eu, condimentum eget felis. Quisque efficitur purus id mi laoreet hendrerit. Suspendisse consequat augue ullamcorper quam aliquet, eget fermentum nunc porttitor. Nam fringilla elementum pharetra. Integer tempor velit velit, non vulputate enim fringilla vel. Donec elementum id lacus in molestie. Pellentesque pellentesque sollicitudin enim, vel porttitor felis mollis ac. Donec laoreet dui sit amet metus dignissim, id iaculis diam dignissim. Duis vel ex non augue vulputate sollicitudin quis sed nulla.

Vestibulum dapibus, velit ac maximus tempus, tellus sem mollis eros, scelerisque vehicula libero odio sit amet diam. Vivamus lacinia tempor libero, imperdiet molestie turpis ornare id. Ut molestie, dolor id interdum vehicula, nisl elit mollis massa, ut porta lorem nunc vitae mauris. Phasellus sagittis est eget iaculis luctus. Praesent ultrices molestie molestie. Nam tortor diam, convallis sit amet nibh ac, rutrum mollis elit. Nulla a orci sit amet purus tempor bibendum.",
                    ImgWebPath = "",
                    Timestamp = DateTime.Now
                }
            };
        }
    }
}
