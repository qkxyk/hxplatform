namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menu", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Menu", "Token", "dbo.Group");
            DropForeignKey("dbo.MenuAffiliate", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.RoleMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.RoleMenu", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Device", "MenuId", "dbo.Menu");
            DropIndex("dbo.Device", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.Menu", new[] { "Token" });
            DropIndex("dbo.Menu", new[] { "ClientId" });
            DropIndex("dbo.MenuAffiliate", new[] { "MenuId" });
            DropIndex("dbo.RoleMenu", new[] { "RoleId" });
            DropIndex("dbo.RoleMenu", new[] { "MenuId" });
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        level = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Cate = c.Int(nullable: false),
                        ProjectType = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        UseTime = c.DateTime(),
                        ParentId = c.Int(),
                        Token = c.String(nullable: false, maxLength: 128),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.Group", t => t.Token)
                .ForeignKey("dbo.Project", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.Token)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ProjectAffiliate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AffiliateName = c.String(),
                        AffiliateValue = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.RoleProject",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.RoleId })
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.RoleId);
            
            AddColumn("dbo.Device", "ProjectId", c => c.Int());
            CreateIndex("dbo.Device", "ProjectId");
            AddForeignKey("dbo.Device", "ProjectId", "dbo.Project", "Id");
            DropColumn("dbo.Device", "MenuId");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuAffiliate");
            DropTable("dbo.RoleMenu");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuAffiliate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AffiliateName = c.String(),
                        AffiliateValue = c.String(),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        Url = c.String(),
                        level = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Cate = c.Int(nullable: false),
                        MenuType = c.Int(nullable: false),
                        StartTime = c.DateTime(),
                        UseTime = c.DateTime(),
                        ParentId = c.Int(),
                        Token = c.String(nullable: false, maxLength: 128),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Device", "MenuId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Device", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.RoleProject", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleProject", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.ProjectAffiliate", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "ParentId", "dbo.Project");
            DropForeignKey("dbo.Project", "Token", "dbo.Group");
            DropForeignKey("dbo.Project", "ClientId", "dbo.Client");
            DropIndex("dbo.RoleProject", new[] { "RoleId" });
            DropIndex("dbo.RoleProject", new[] { "ProjectId" });
            DropIndex("dbo.ProjectAffiliate", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "ClientId" });
            DropIndex("dbo.Project", new[] { "Token" });
            DropIndex("dbo.Project", new[] { "ParentId" });
            DropIndex("dbo.Device", new[] { "ProjectId" });
            DropColumn("dbo.Device", "ProjectId");
            DropTable("dbo.RoleProject");
            DropTable("dbo.ProjectAffiliate");
            DropTable("dbo.Project");
            CreateIndex("dbo.RoleMenu", "MenuId");
            CreateIndex("dbo.RoleMenu", "RoleId");
            CreateIndex("dbo.MenuAffiliate", "MenuId");
            CreateIndex("dbo.Menu", "ClientId");
            CreateIndex("dbo.Menu", "Token");
            CreateIndex("dbo.Menu", "ParentId");
            CreateIndex("dbo.Device", "MenuId");
            AddForeignKey("dbo.Device", "MenuId", "dbo.Menu", "Id");
            AddForeignKey("dbo.RoleMenu", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleMenu", "MenuId", "dbo.Menu", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menu", "ParentId", "dbo.Menu", "Id");
            AddForeignKey("dbo.MenuAffiliate", "MenuId", "dbo.Menu", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menu", "Token", "dbo.Group", "Id");
            AddForeignKey("dbo.Menu", "ClientId", "dbo.Client", "Id");
        }
    }
}
