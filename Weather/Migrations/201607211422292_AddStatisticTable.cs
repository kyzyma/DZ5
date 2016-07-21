namespace Weather.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatisticTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        city = c.String(),
                        count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Statistics");
        }
    }
}
