namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Receipt_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "Price", c => c.Int(nullable: false));
        }
    }
}
