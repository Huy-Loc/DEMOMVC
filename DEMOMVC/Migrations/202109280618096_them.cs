namespace DEMOMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "StudentComent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "StudentComent");
        }
    }
}
