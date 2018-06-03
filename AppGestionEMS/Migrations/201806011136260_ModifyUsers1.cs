namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyUsers1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GrupoClases");
            AddColumn("dbo.AsignacionDocentes", "UserId", c => c.String());
            AddColumn("dbo.AsignacionDocentes", "Grupo_Id", c => c.Int());
            AddColumn("dbo.Matriculas", "GrupoId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Matriculas", "Curso_Id", c => c.Int());
            AlterColumn("dbo.GrupoClases", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GrupoClases", "Id");
            CreateIndex("dbo.AsignacionDocentes", "Grupo_Id");
            CreateIndex("dbo.Matriculas", "GrupoId");
            CreateIndex("dbo.Matriculas", "UserId");
            CreateIndex("dbo.Matriculas", "Curso_Id");
            AddForeignKey("dbo.AsignacionDocentes", "Grupo_Id", "dbo.GrupoClases", "Id");
            AddForeignKey("dbo.Matriculas", "Curso_Id", "dbo.Cursos", "Id");
            AddForeignKey("dbo.Matriculas", "GrupoId", "dbo.GrupoClases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "GrupoId", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "Curso_Id", "dbo.Cursos");
            DropForeignKey("dbo.AsignacionDocentes", "Grupo_Id", "dbo.GrupoClases");
            DropIndex("dbo.Matriculas", new[] { "Curso_Id" });
            DropIndex("dbo.Matriculas", new[] { "UserId" });
            DropIndex("dbo.Matriculas", new[] { "GrupoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Grupo_Id" });
            DropPrimaryKey("dbo.GrupoClases");
            AlterColumn("dbo.GrupoClases", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Matriculas", "Curso_Id");
            DropColumn("dbo.Matriculas", "UserId");
            DropColumn("dbo.Matriculas", "GrupoId");
            DropColumn("dbo.AsignacionDocentes", "Grupo_Id");
            DropColumn("dbo.AsignacionDocentes", "UserId");
            AddPrimaryKey("dbo.GrupoClases", "Id");
        }
    }
}
