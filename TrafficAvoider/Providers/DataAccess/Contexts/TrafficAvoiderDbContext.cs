using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficAvoider.Providers.DataAccess.Models.Entities;

namespace TrafficAvoider.Providers.DataAccess.Contexts
{
    public class TrafficAvoiderDbContext : DbContext
    {
        public TrafficAvoiderDbContext() : base("TrafficAvoider")
        {
        }

        public DbSet<EndPointEntity> EndPoints { get; set; }
        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<TripHistoryEntity> TripHistory { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
