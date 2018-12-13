namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedspecialpickupmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialPickups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PickupDate = c.DateTime(nullable: false),
                        Time = c.String(),
                        PickupAddress = c.String(),
                        Zip = c.String(),
                        Description = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.Customers", "RegularPickupId", c => c.String(maxLength: 128));
            AddColumn("dbo.Customers", "SpecialPickupId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "RegularPickupId");
            CreateIndex("dbo.Customers", "SpecialPickupId");
            AddForeignKey("dbo.Customers", "RegularPickupId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "SpecialPickupId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "SpecialPickupId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "RegularPickupId", "dbo.AspNetUsers");
            DropIndex("dbo.SpecialPickups", new[] { "ApplicationUserId" });
            DropIndex("dbo.Customers", new[] { "SpecialPickupId" });
            DropIndex("dbo.Customers", new[] { "RegularPickupId" });
            DropColumn("dbo.Customers", "SpecialPickupId");
            DropColumn("dbo.Customers", "RegularPickupId");
            DropTable("dbo.SpecialPickups");
        }
    }
}
