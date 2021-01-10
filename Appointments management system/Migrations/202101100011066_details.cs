namespace Appointments_management_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class details : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
