using TrafficAvoider.Lib.Helpers;
using TrafficAvoider.Providers.DataAccess.Models.Entities;

namespace TrafficAvoider.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserEntity ToEntity()
        {
            return AutoMapper.Map<UserEntity, User>(this);
        }

        public void FromEntity(UserEntity userEntity)
        {
            AutoMapper.Map(userEntity, this);
        }
    }
}
