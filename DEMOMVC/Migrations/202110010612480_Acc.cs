namespace DEMOMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Acc : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Account", newName: "Accounts");
            DropPrimaryKey("dbo.Accounts");
            AddColumn("dbo.Accounts", "UserName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, unicode: false));
            AddPrimaryKey("dbo.Accounts", "UserName");
            DropColumn("dbo.Accounts", "Usename");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Usename", c => c.String(nullable: false, maxLength: 50));
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "Password", c => c.String(maxLength: 50, unicode: false));
            DropColumn("dbo.Accounts", "UserName");
            AddPrimaryKey("dbo.Accounts", "Usename");
            RenameTable(name: "dbo.Accounts", newName: "Account");
        }
    }
}
