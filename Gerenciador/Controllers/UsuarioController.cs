using Gerenciador.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Gerenciador.Controllers
{
    public class UsuarioController : ApiController
    {
        private GerenciadorContext ctx = new GerenciadorContext();

        [Route("api/Usuario/getusuarios")]
        public IQueryable GetUsuarios()
        {
            return ctx.Usuarios;
        }

        [ResponseType(typeof(Usuario))]
        [Route("api/Usuario/getusuario/{id}")]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = FindUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new Usuario { UsuarioID = usuario.UsuarioID }, usuario);
        }

        private Usuario FindUsuario(int id)
        {
            return (from u in ctx.Usuarios
                    where u.UsuarioID == id
                    select u).FirstOrDefault();
        }
    }
}
