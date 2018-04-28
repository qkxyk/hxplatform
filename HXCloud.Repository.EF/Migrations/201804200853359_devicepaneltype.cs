namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class devicepaneltype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevicePanelType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Account = c.String(),
                        DT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.Token, cascadeDelete: true)
                .Index(t => t.Token);
            
            AddColumn("dbo.DevicePanel", "TypeId", c => c.Int());
            CreateIndex("dbo.DevicePanel", "TypeId");
            AddForeignKey("dbo.DevicePanel", "TypeId", "dbo.DevicePanelType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DevicePanel", "TypeId", "dbo.DevicePanelType");
            DropForeignKey("dbo.DevicePanelType", "Token", "dbo.Group");
            DropIndex("dbo.DevicePanelType", new[] { "Token" });
            DropIndex("dbo.DevicePanel", new[] { "TypeId" });
            DropColumn("dbo.DevicePanel", "TypeId");
            DropTable("dbo.DevicePanelType");
        }
    }
}
