namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madesomechangesinreqularpikupanddetailsmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularPickups", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.RegularPickups", "ApplicationUserId");
            AddForeignKey("dbo.RegularPickups", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.RegularPickups", "PickupPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegularPickups", "PickupPrice", c => c.Double(nullable: false));
            DropForeignKey("dbo.RegularPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.RegularPickups", new[] { "ApplicationUserId" });
            DropColumn("dbo.RegularPickups", "ApplicationUserId");
        }
    }
}
