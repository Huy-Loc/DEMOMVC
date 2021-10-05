namespace DEMOMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_acount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "RoleID", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "RoleID");
        }
    }
}
