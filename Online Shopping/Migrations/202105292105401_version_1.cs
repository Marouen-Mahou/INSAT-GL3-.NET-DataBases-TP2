namespace Online_Shopping.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "OrderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "OrderId" });
            AlterColumn("dbo.Products", "OrderId", c => c.Int());
            CreateIndex("dbo.Products", "OrderId");
            AddForeignKey("dbo.Products", "OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OrderId", "dbo.Orders");
            DropIndex("dbo.Products", new[] { "OrderId" });
            AlterColumn("dbo.Products", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "OrderId");
            AddForeignKey("dbo.Products", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
