namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateprojectClient : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Project", new[] { "ClientId" });
            AlterColumn("dbo.Project", "ClientId", c => c.Int());
            CreateIndex("dbo.Project", "ClientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Project", new[] { "ClientId" });
            AlterColumn("dbo.Project", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Project", "ClientId");
        }
    }
}
