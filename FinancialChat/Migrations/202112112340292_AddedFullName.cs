namespace FinancialChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
