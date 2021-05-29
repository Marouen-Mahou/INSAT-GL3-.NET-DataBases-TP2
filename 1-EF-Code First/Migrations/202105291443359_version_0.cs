namespace _1_EF_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marques",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modele = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marques", t => t.Id)
                .ForeignKey("dbo.Personnes", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Personnes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(maxLength: 20),
                        Prenom = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voitures", "Id", "dbo.Personnes");
            DropForeignKey("dbo.Voitures", "Id", "dbo.Marques");
            DropIndex("dbo.Voitures", new[] { "Id" });
            DropTable("dbo.Personnes");
            DropTable("dbo.Voitures");
            DropTable("dbo.Marques");
        }
    }
}
