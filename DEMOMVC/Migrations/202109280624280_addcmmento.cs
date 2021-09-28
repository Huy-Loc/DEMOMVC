namespace DEMOMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcmmento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Comment");
        }
    }
}
