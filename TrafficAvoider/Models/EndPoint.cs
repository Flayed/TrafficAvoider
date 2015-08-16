using TrafficAvoider.Lib.Helpers;
using TrafficAvoider.Providers.DataAccess.Models.Entities;

namespace TrafficAvoider.Models
{
    public class EndPoint
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public string Waypoint
        {
            get
            {
                return $"{Address}, {City}, {State}";
            }
        }

        public EndPointEntity ToEntity()
        {
            return AutoMapper.Map<EndPointEntity, EndPoint>(this);
        }

        public void FromEntity(EndPointEntity endPointEntity)
        {
            AutoMapper.Map(endPointEntity, this);
        }
    }
}
