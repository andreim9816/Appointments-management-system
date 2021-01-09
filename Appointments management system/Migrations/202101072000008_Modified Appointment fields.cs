namespace Appointments_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedAppointmentfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "AppointmentHour", c => c.String());
            DropColumn("dbo.Appointments", "AppointmentMinute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentMinute", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "AppointmentHour", c => c.Int(nullable: false));
        }
    }
}
