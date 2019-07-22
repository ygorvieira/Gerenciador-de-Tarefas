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
    public class CategoriaController : ApiController
    {
        private GerenciadorContext ctx = new GerenciadorContext();

        [Route("api/Categoria/getcategorias")]
        public IQueryable GetCategorias()
        {
            return ctx.Categorias;
        }

        [ResponseType(typeof(Categoria))]
        [Route("api/Categoria/getcategoria/{id}")]
        public IHttpActionResult GetCategoria(int id)
        {
            Categoria categoria = FindCategoria(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        public IHttpActionResult PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new Categoria { CategoriaID = categoria.CategoriaID }, categoria);
        }

        private Categoria FindCategoria(int id)
        {
            return (from c in ctx.Categorias
                    where c.CategoriaID == id
                    select c).FirstOrDefault();
        }
    }
}
