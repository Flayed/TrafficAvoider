using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficAvoider.Providers.External.Models
{
    public class TripDto
    {
        public string Description { get; set; }
        private int Duration { get; set; }
        public double DurationInMinutes
        {
            get
            {
                return Math.Round((double)Duration / 60, 2);
            }
        }
        private int DurationInTraffic { get; set; }
        public double DurationInMinutesInTraffic
        {
            get
            {
                return Math.Round((double)DurationInTraffic / 60, 2);
            }
        }
        public string TrafficCongestion { get; set; }

        public TripDto(RootObject rootObject)
        {
            var resource = rootObject.resourceSets.FirstOrDefault().resources.FirstOrDefault();
            if (resource == null) return;

            TrafficCongestion = resource.trafficCongestion;
            Duration = resource.travelDuration;
            DurationInTraffic = resource.travelDurationTraffic;
            Description = string.Join(", ", resource.routeLegs.Select(rl => rl.description));
        }
    }
}
