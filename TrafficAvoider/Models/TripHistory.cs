using System;
using TrafficAvoider.Lib.Helpers;
using TrafficAvoider.Providers.DataAccess.Models.Entities;

namespace TrafficAvoider.Models
{
    public class TripHistory
    {
        public long Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime TimeStamp { get; set; }
        public Trip Trip { get; set; }

        public TripHistoryEntity ToEntity()
        {
            return AutoMapper.Map<TripHistoryEntity, TripHistory>(this);
        }

        public void FromEntity(TripHistoryEntity tripHistoryEntity)
        {
            AutoMapper.Map(tripHistoryEntity, this, (source, destination) =>
            {
                destination.Trip.FromEntity(source.Trip);
            });
        }
    }
}
