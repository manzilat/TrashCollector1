namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsomepropertiesfrompickupmodel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RegularPickups");
            AddColumn("dbo.RegularPickups", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RegularPickups", "Description", c => c.String());
            AddPrimaryKey("dbo.RegularPickups", "Id");
            DropColumn("dbo.RegularPickups", "PickupStartDate");
            DropColumn("dbo.RegularPickups", "PickupEndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegularPickups", "PickupEndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RegularPickups", "PickupStartDate", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.RegularPickups");
            DropColumn("dbo.RegularPickups", "Description");
            DropColumn("dbo.RegularPickups", "Id");
            AddPrimaryKey("dbo.RegularPickups", "PickupActive");
        }
    }
}
