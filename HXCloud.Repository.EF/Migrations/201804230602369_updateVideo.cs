namespace HXCloud.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceVideo", "VideoSn", c => c.String());
            AddColumn("dbo.DeviceVideo", "Channel", c => c.Int(nullable: false));
            AddColumn("dbo.DeviceVideo", "SecurityCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceVideo", "SecurityCode");
            DropColumn("dbo.DeviceVideo", "Channel");
            DropColumn("dbo.DeviceVideo", "VideoSn");
        }
    }
}
