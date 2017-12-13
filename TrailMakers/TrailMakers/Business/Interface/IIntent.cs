using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMakers.Business.Interface
{
    public interface IIntent
    {
        void Navigator(string link);
        void PlaceNavigation(string latitude, string longitude);
    }
}
