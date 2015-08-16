using System;
using System.Collections.Generic;
using System.Linq;
using TrafficAvoider.Lib.Enum;
using TrafficAvoider.Lib.Helpers;
using TrafficAvoider.Providers.DataAccess.Models.Entities;

namespace TrafficAvoider.Models
{
    public class Trip
    {
        public long Id { get; set; }
        public List<TripTime> TripTimes { get; set; }
        public User Owner { get; set; }
        public EndPoint StartLocation { get; set; }
        public EndPoint EndLocation { get; set; }

        public TripEntity ToEntity()
        {
            return AutoMapper.Map<TripEntity, Trip>(this, (source, destination) =>
            {
                destination.TripTimes = source.TripTimes.Select(tt => tt.ToEntity()).ToList();
                destination.StartLocation = source.StartLocation.ToEntity();
                destination.EndLocation = source.EndLocation.ToEntity();
                destination.Owner = source.Owner.ToEntity();
            });
        }

        public void FromEntity(TripEntity tripEntity)
        {
            AutoMapper.Map(tripEntity, this, (source, destination) =>
            {
                destination.TripTimes = source.TripTimes.Select(tt => new TripTime(tt)).ToList();
                destination.StartLocation.FromEntity(source.StartLocation);
                destination.EndLocation.FromEntity(source.EndLocation);
                destination.Owner.FromEntity(source.Owner);
            });
        }

        public Trip()
        {
            TripTimes = new List<TripTime>();
        }
    }
}
