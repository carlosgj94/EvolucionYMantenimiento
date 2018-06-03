namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCursos1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoClases",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoClases");
        }
    }
}
