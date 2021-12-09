namespace APITecsup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gaseosas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gaseosas",
                c => new
                    {
                        GaseosaID = c.Int(nullable: false, identity: true),
                        GaseosaNombre = c.String(maxLength: 100),
                        GaseosaMarca = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.GaseosaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gaseosas");
        }
    }
}
