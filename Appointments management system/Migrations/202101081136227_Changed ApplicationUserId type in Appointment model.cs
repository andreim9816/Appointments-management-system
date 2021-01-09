namespace Appointments_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedApplicationUserIdtypeinAppointmentmodel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Appointments", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Appointments", "ApplicationUserId");
            RenameColumn(table: "dbo.Appointments", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Appointments", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Appointments", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Appointments", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Appointments", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Appointments", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Appointments", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ApplicationUser_Id");
        }
    }
}
