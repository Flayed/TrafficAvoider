using System;
using TrafficAvoider.Lib.Helpers;
using TrafficAvoider.Providers.DataAccess.Models.Entities;

namespace TrafficAvoider.Models
{
    public class TripTime
    {
        public long Id { get; set; }
        public DateTime TimeOfTrip { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan AverageDuration { get; set; }

        public TripTimeEntity ToEntity()
        {
            return AutoMapper.Map<TripTimeEntity, TripTime>(this);
        }

        public void FromEntity(TripTimeEntity tripTimeEntity)
        {
            AutoMapper.Map(tripTimeEntity, this);
        }

        public TripTime()
        {
        }

        public TripTime(TripTimeEntity tripTimeEntity)
        {
            FromEntity(tripTimeEntity);
        }
    }
}
