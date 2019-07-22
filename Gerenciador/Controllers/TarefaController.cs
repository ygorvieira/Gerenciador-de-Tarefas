using Gerenciador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Gerenciador.Controllers
{
    public class TarefaController : ApiController
    {
        private GerenciadorContext ctx = new GerenciadorContext();

        [Route("api/Tarefa/GetTarefas")]
        public IQueryable GetTarefas()
        {
            return ctx.Tarefas;
        }

        [Route("api/Tarefa/GetTarefa/{id}")]
        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult GetTarefa(int id)
        {
            Tarefa tarefa = FindTarefa(id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [ResponseType(typeof(Tarefa))]
        public IHttpActionResult PostTarefa(Tarefa tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Tarefas.Add(tarefa);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new Tarefa { TarefaID = tarefa.TarefaID }, tarefa);
        }

        private Tarefa FindTarefa(int id)
        {
            return (from t in ctx.Tarefas
                    where t.TarefaID == id
                    select t).FirstOrDefault();
        }
    }
}
