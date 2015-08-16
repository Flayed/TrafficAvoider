using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficAvoider.Providers.DataAccess.Models.Entities
{
    [Table("EndPoint")]
    public class EndPointEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
