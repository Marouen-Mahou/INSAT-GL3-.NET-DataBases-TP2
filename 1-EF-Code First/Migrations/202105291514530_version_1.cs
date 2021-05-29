namespace _1_EF_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Voitures", "Id", "dbo.Marques");
            DropForeignKey("dbo.Voitures", "Id", "dbo.Personnes");
            DropIndex("dbo.Voitures", new[] { "Id" });
            AddColumn("dbo.Voitures", "MarqueId", c => c.Int(nullable: false));
            AddColumn("dbo.Voitures", "PersonneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Voitures", "MarqueId");
            CreateIndex("dbo.Voitures", "PersonneId");
            AddForeignKey("dbo.Voitures", "MarqueId", "dbo.Marques", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Voitures", "PersonneId", "dbo.Personnes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voitures", "PersonneId", "dbo.Personnes");
            DropForeignKey("dbo.Voitures", "MarqueId", "dbo.Marques");
            DropIndex("dbo.Voitures", new[] { "PersonneId" });
            DropIndex("dbo.Voitures", new[] { "MarqueId" });
            DropColumn("dbo.Voitures", "PersonneId");
            DropColumn("dbo.Voitures", "MarqueId");
            CreateIndex("dbo.Voitures", "Id");
            AddForeignKey("dbo.Voitures", "Id", "dbo.Personnes", "Id");
            AddForeignKey("dbo.Voitures", "Id", "dbo.Marques", "Id");
        }
    }
}
