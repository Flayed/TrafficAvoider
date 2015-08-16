using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficAvoider.Providers.DataAccess.Models.Entities
{
    [Table("Trip")]
    public class TripEntity
    {
        public long Id { get; set; }
        public ICollection<TripTimeEntity> TripTimes { get; set; }
        public UserEntity Owner { get; set; }
        public EndPointEntity StartLocation { get; set; }
        public EndPointEntity EndLocation { get; set; }
    }
}
