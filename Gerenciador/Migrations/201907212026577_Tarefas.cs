namespace Gerenciador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarefas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        TarefaID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        IDCategoria = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataEntrega = c.DateTime(nullable: false),
                        IDUsuario = c.Int(nullable: false),
                        IDStatus = c.Int(nullable: false),
                        Categoria_CategoriaID = c.Int(),
                        Status_StatusID = c.Int(),
                        Usuario_UsuarioID = c.Int(),
                    })
                .PrimaryKey(t => t.TarefaID)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaID)
                .ForeignKey("dbo.Status", t => t.Status_StatusID)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioID)
                .Index(t => t.Categoria_CategoriaID)
                .Index(t => t.Status_StatusID)
                .Index(t => t.Usuario_UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "Usuario_UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Tarefas", "Status_StatusID", "dbo.Status");
            DropForeignKey("dbo.Tarefas", "Categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Tarefas", new[] { "Usuario_UsuarioID" });
            DropIndex("dbo.Tarefas", new[] { "Status_StatusID" });
            DropIndex("dbo.Tarefas", new[] { "Categoria_CategoriaID" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Status");
            DropTable("dbo.Categorias");
        }
    }
}
