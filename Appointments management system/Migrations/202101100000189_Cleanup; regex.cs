namespace Appointments_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cleanupregex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clinics", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Doctors", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Doctors", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Details", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Appointments", "AppointmentHour", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "Details", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "Details", c => c.String());
            AlterColumn("dbo.Appointments", "AppointmentHour", c => c.String());
            AlterColumn("dbo.Doctors", "Details", c => c.String());
            AlterColumn("dbo.Doctors", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Doctors", "LastName", c => c.String());
            AlterColumn("dbo.Doctors", "FirstName", c => c.String());
            AlterColumn("dbo.Clinics", "PhoneNumber", c => c.String());
        }
    }
}
