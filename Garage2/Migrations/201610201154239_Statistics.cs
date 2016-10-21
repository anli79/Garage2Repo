namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Statistics : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "NrOfCars", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfBusses", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfBoats", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfAirplanes", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfMotorcycles", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "NrOfWheels", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "PriceAllVehicles", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "PriceAllVehicles");
            DropColumn("dbo.Vehicles", "NrOfWheels");
            DropColumn("dbo.Vehicles", "NrOfMotorcycles");
            DropColumn("dbo.Vehicles", "NrOfAirplanes");
            DropColumn("dbo.Vehicles", "NrOfBoats");
            DropColumn("dbo.Vehicles", "NrOfBusses");
            DropColumn("dbo.Vehicles", "NrOfCars");
        }
    }
}
