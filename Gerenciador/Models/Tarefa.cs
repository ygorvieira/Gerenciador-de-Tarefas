using System;

namespace Gerenciador.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; }
        public string Titulo { get; set; }
        public int IDCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int IDUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IDStatus { get; set; }
        public Status Status { get; set; }
    }
}