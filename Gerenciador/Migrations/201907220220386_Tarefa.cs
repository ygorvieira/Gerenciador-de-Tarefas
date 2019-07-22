namespace Gerenciador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarefa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tarefas", "DataEntrega", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tarefas", "DataEntrega", c => c.DateTime(nullable: false));
        }
    }
}
