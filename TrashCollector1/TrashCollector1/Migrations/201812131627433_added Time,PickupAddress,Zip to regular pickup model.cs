namespace TrashCollector1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTimePickupAddressZiptoregularpickupmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegularPickups", "PickupAddress", c => c.String());
            AddColumn("dbo.RegularPickups", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegularPickups", "Zip");
            DropColumn("dbo.RegularPickups", "PickupAddress");
        }
    }
}
