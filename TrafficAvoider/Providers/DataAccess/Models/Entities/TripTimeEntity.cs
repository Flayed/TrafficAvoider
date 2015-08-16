using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficAvoider.Providers.DataAccess.Models.Entities
{
    [Table("TripTime")]
    public class TripTimeEntity
    {
        public long Id { get; set; }
        public DateTime TimeOfTrip { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan AverageDuration { get; set; }
    }
}
