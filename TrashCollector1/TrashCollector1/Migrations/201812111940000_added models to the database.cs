namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodelstothedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegularPickups",
                c => new
                    {
                        PickupActive = c.Boolean(nullable: false),
                        PickupDayOfWeek = c.Int(nullable: false),
                        PickupStartDate = c.DateTime(nullable: false),
                        PickupEndDate = c.DateTime(nullable: false),
                        PickupPrice = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PickupActive)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegularPickups", "CustomerId", "dbo.Customers");
            DropIndex("dbo.RegularPickups", new[] { "CustomerId" });
            DropTable("dbo.RegularPickups");
        }
    }
}
