namespace FinancialChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Message");
        }
    }
}
