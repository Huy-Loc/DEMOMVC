namespace DEMOMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sualai : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "StudentComent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StudentComent", c => c.String());
        }
    }
}
