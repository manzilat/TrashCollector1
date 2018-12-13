namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "SpecialPickupId", "dbo.SpecialPickups");
            DropForeignKey("dbo.Customers", "SuspendAccoutId", "dbo.SuspendAccounts");
            DropIndex("dbo.Customers", new[] { "SpecialPickupId" });
            DropIndex("dbo.Customers", new[] { "SuspendAccoutId" });
            AlterColumn("dbo.Customers", "SpecialPickupId", c => c.Int());
            AlterColumn("dbo.Customers", "SuspendAccoutId", c => c.Int());
            CreateIndex("dbo.Customers", "SpecialPickupId");
            CreateIndex("dbo.Customers", "SuspendAccoutId");
            AddForeignKey("dbo.Customers", "SpecialPickupId", "dbo.SpecialPickups", "id");
            AddForeignKey("dbo.Customers", "SuspendAccoutId", "dbo.SuspendAccounts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "SuspendAccoutId", "dbo.SuspendAccounts");
            DropForeignKey("dbo.Customers", "SpecialPickupId", "dbo.SpecialPickups");
            DropIndex("dbo.Customers", new[] { "SuspendAccoutId" });
            DropIndex("dbo.Customers", new[] { "SpecialPickupId" });
            AlterColumn("dbo.Customers", "SuspendAccoutId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "SpecialPickupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "SuspendAccoutId");
            CreateIndex("dbo.Customers", "SpecialPickupId");
            AddForeignKey("dbo.Customers", "SuspendAccoutId", "dbo.SuspendAccounts", "id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "SpecialPickupId", "dbo.SpecialPickups", "id", cascadeDelete: true);
        }
    }
}
