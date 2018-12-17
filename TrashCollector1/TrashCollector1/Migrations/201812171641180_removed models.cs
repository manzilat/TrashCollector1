namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegularPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "RegularPickupId", "dbo.RegularPickups");
            DropForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "SpecialPickupId", "dbo.SpecialPickups");
            DropForeignKey("dbo.SuspendAccounts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "SuspendAccoutId", "dbo.SuspendAccounts");
            DropIndex("dbo.Customers", new[] { "RegularPickupId" });
            DropIndex("dbo.Customers", new[] { "SpecialPickupId" });
            DropIndex("dbo.Customers", new[] { "SuspendAccoutId" });
            DropIndex("dbo.RegularPickups", new[] { "ApplicationUserId" });
            DropIndex("dbo.SpecialPickups", new[] { "ApplicationUserId" });
            DropIndex("dbo.SuspendAccounts", new[] { "ApplicationUserId" });
            AddColumn("dbo.Customers", "PickupDayOfWeek", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Time", c => c.String());
            AddColumn("dbo.Customers", "Description", c => c.String());
            AddColumn("dbo.Customers", "SpecialPickupDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "AccountSuspendDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "AccountSuspendEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "PickupCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "RegularPickupId");
            DropColumn("dbo.Customers", "SpecialPickupId");
            DropColumn("dbo.Customers", "SuspendAccoutId");
            DropTable("dbo.RegularPickups");
            DropTable("dbo.SpecialPickups");
            DropTable("dbo.SuspendAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SuspendAccounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AccountSuspendDate = c.DateTime(nullable: false),
                        AccountSuspendEndDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
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
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.RegularPickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickupDayOfWeek = c.Int(nullable: false),
                        Time = c.String(),
                        PickupAddress = c.String(),
                        Zip = c.String(),
                        Description = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "SuspendAccoutId", c => c.Int());
            AddColumn("dbo.Customers", "SpecialPickupId", c => c.Int());
            AddColumn("dbo.Customers", "RegularPickupId", c => c.Int());
            DropColumn("dbo.Customers", "PickupCompleted");
            DropColumn("dbo.Customers", "AccountSuspendEndDate");
            DropColumn("dbo.Customers", "AccountSuspendDate");
            DropColumn("dbo.Customers", "SpecialPickupDate");
            DropColumn("dbo.Customers", "Description");
            DropColumn("dbo.Customers", "Time");
            DropColumn("dbo.Customers", "PickupDayOfWeek");
            CreateIndex("dbo.SuspendAccounts", "ApplicationUserId");
            CreateIndex("dbo.SpecialPickups", "ApplicationUserId");
            CreateIndex("dbo.RegularPickups", "ApplicationUserId");
            CreateIndex("dbo.Customers", "SuspendAccoutId");
            CreateIndex("dbo.Customers", "SpecialPickupId");
            CreateIndex("dbo.Customers", "RegularPickupId");
            AddForeignKey("dbo.Customers", "SuspendAccoutId", "dbo.SuspendAccounts", "id");
            AddForeignKey("dbo.SuspendAccounts", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "SpecialPickupId", "dbo.SpecialPickups", "id");
            AddForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Customers", "RegularPickupId", "dbo.RegularPickups", "Id");
            AddForeignKey("dbo.RegularPickups", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
