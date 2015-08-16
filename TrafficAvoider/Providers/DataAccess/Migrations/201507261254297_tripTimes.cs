namespace TrafficAvoider.Providers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tripTimes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripTime",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TimeOfTrip = c.DateTime(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        AverageDuration = c.Time(nullable: false, precision: 7),
                        TripEntity_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trip", t => t.TripEntity_Id)
                .Index(t => t.TripEntity_Id);
            
            AddColumn("dbo.EndPoint", "State", c => c.String());
            DropColumn("dbo.Trip", "TripStartTime");
            DropColumn("dbo.Trip", "Days");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trip", "Days", c => c.Int(nullable: false));
            AddColumn("dbo.Trip", "TripStartTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.TripTime", "TripEntity_Id", "dbo.Trip");
            DropIndex("dbo.TripTime", new[] { "TripEntity_Id" });
            DropColumn("dbo.EndPoint", "State");
            DropTable("dbo.TripTime");
        }
    }
}
