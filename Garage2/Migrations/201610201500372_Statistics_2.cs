namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statistics_2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "NrOfCars");
            DropColumn("dbo.Vehicles", "NrOfBusses");
            DropColumn("dbo.Vehicles", "NrOfBoats");
            DropColumn("dbo.Vehicles", "NrOfAirplanes");
            DropColumn("dbo.Vehicles", "NrOfMotorcycles");
            DropColumn("dbo.Vehicles", "NrOfWheels");
            DropColumn("dbo.Vehicles", "PriceAllVehicles");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "PriceAllVehicles", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfWheels", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfMotorcycles", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfAirplanes", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfBoats", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfBusses", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfCars", c => c.Int(nullable: false));
        }
    }
}
