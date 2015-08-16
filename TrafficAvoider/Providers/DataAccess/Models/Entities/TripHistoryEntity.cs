using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficAvoider.Providers.DataAccess.Models.Entities
{
    [Table("TripHistory")]
    public class TripHistoryEntity
    {
        public long Id { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime TimeStamp { get; set; }
        public TripEntity Trip { get; set; }
    }
}
