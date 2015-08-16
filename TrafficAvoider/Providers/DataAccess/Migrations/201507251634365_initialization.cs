namespace TrafficAvoider.Providers.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EndPoint",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Duration = c.Time(nullable: false, precision: 7),
                        TimeStamp = c.DateTime(nullable: false),
                        Trip_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trip", t => t.Trip_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TripStartTime = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        EndLocation_Id = c.Long(),
                        Owner_Id = c.Long(),
                        StartLocation_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EndPoint", t => t.EndLocation_Id)
                .ForeignKey("dbo.User", t => t.Owner_Id)
                .ForeignKey("dbo.EndPoint", t => t.StartLocation_Id)
                .Index(t => t.EndLocation_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.StartLocation_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripHistory", "Trip_Id", "dbo.Trip");
            DropForeignKey("dbo.Trip", "StartLocation_Id", "dbo.EndPoint");
            DropForeignKey("dbo.Trip", "Owner_Id", "dbo.User");
            DropForeignKey("dbo.Trip", "EndLocation_Id", "dbo.EndPoint");
            DropIndex("dbo.Trip", new[] { "StartLocation_Id" });
            DropIndex("dbo.Trip", new[] { "Owner_Id" });
            DropIndex("dbo.Trip", new[] { "EndLocation_Id" });
            DropIndex("dbo.TripHistory", new[] { "Trip_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Trip");
            DropTable("dbo.TripHistory");
            DropTable("dbo.EndPoint");
        }
    }
}
