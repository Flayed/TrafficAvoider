using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficAvoider.Models;
using TrafficAvoider.Providers.External.Models;

namespace TrafficAvoider.Providers.External
{
    public interface ITripProvider
    {
        Task<TripDto> GetRouteAsync(EndPoint startingPoint, EndPoint endingPoint);
    }
}
