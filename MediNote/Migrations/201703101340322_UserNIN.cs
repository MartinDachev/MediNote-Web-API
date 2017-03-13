namespace MediNote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNIN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserNIN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserNIN");
        }
    }
}
