namespace DEMOMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_foreikey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Accounts", "RoleID");
            AddForeignKey("dbo.Accounts", "RoleID", "dbo.Roles", "RoleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "RoleID", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleID" });
        }
    }
}
