namespace MediNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNINdrop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserNIN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserNIN", c => c.String());
        }
    }
}
