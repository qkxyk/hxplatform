namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleSysMenu",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        SysMenuId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.SysMenuId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.SysMenu", t => t.SysMenuId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.SysMenuId);
            
            CreateTable(
                "dbo.SysMenu",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ParentId = c.String(maxLength: 128),
                        Token = c.String(nullable: false, maxLength: 128),
                        Url = c.String(),
                        ProjectType = c.Int(),
                        Icon = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.Token, cascadeDelete: true)
                .ForeignKey("dbo.SysMenu", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.Token);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleSysMenu", "SysMenuId", "dbo.SysMenu");
            DropForeignKey("dbo.SysMenu", "ParentId", "dbo.SysMenu");
            DropForeignKey("dbo.SysMenu", "Token", "dbo.Group");
            DropForeignKey("dbo.RoleSysMenu", "RoleId", "dbo.Role");
            DropIndex("dbo.SysMenu", new[] { "Token" });
            DropIndex("dbo.SysMenu", new[] { "ParentId" });
            DropIndex("dbo.RoleSysMenu", new[] { "SysMenuId" });
            DropIndex("dbo.RoleSysMenu", new[] { "RoleId" });
            DropTable("dbo.SysMenu");
            DropTable("dbo.RoleSysMenu");
        }
    }
}
