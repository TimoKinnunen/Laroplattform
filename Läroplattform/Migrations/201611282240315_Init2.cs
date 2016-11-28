namespace Läroplattform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsNotInAnyRole", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "ClassRoomDoorCode");
            DropColumn("dbo.AspNetUsers", "UserEmail");
            DropColumn("dbo.AspNetUsers", "IsNotAttachedToInstitution");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsNotAttachedToInstitution", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "UserEmail", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "ClassRoomDoorCode", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsNotInAnyRole");
        }
    }
}
