using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailMakers.Entity;

namespace TrailMakers.ApiServices.Services
{
    public interface IApiS
    {
        List<News> GetNewsAsync();
    }
}
