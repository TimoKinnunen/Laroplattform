namespace Läroplattform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassRoomDoorCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ClassRoomDoorCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ClassRoomDoorCode");
        }
    }
}
