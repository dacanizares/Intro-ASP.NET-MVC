namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Generos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Videojuegoes", "GeneroId", c => c.Int(nullable: false));
            CreateIndex("dbo.Videojuegoes", "GeneroId");
            AddForeignKey("dbo.Videojuegoes", "GeneroId", "dbo.Generoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videojuegoes", "GeneroId", "dbo.Generoes");
            DropIndex("dbo.Videojuegoes", new[] { "GeneroId" });
            DropColumn("dbo.Videojuegoes", "GeneroId");
            DropTable("dbo.Generoes");
        }
    }
}
