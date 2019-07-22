using System.Data.Entity;

namespace Gerenciador.Models
{
    public class GerenciadorContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}