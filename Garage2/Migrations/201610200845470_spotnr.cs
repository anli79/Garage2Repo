namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spotnr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "SpotNr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "SpotNr");
        }
    }
}
