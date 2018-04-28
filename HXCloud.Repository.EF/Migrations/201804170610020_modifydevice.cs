namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifydevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Device", "DeviceNo", c => c.String());
            AddColumn("dbo.Device", "PId", c => c.Int(nullable: false));
            AddColumn("dbo.Device", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Device", "Position");
            DropColumn("dbo.Device", "PId");
            DropColumn("dbo.Device", "DeviceNo");
        }
    }
}
