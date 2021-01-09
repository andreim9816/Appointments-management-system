namespace Appointments_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedonetomanyrelationshipuserappointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Details", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Details");
        }
    }
}
