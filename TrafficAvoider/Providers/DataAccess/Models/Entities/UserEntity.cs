using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficAvoider.Providers.DataAccess.Models.Entities
{
    [Table("User")]
    public class UserEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
