namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_status_and_allowhtml_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
        }
    }
}
