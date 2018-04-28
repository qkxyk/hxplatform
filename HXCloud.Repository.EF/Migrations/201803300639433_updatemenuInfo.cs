namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemenuInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysMenu", "MenuType", c => c.Int());
            DropColumn("dbo.SysMenu", "ProjectType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SysMenu", "ProjectType", c => c.Int());
            DropColumn("dbo.SysMenu", "MenuType");
        }
    }
}
