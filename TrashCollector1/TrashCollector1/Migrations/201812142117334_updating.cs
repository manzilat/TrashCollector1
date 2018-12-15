namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        CustomerAccountId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MoneyOwed = c.Double(nullable: false),
                        WeeklyPickUpDay = c.String(),
                        CurrentlySuspended = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerAccountId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            DropColumn("dbo.Customers", "MoneyOwed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MoneyOwed", c => c.Double());
            DropForeignKey("dbo.CustomerAccounts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerAccounts", new[] { "CustomerId" });
            DropTable("dbo.CustomerAccounts");
        }
    }
}
