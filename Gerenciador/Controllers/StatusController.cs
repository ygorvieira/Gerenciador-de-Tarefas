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
    public class StatusController : ApiController
    {
        private GerenciadorContext ctx = new GerenciadorContext();

        [Route("api/Status/GetAllStatus")]
        public IQueryable GetAllStatus()
        {
            return ctx.Status;
        }

        [Route("api/Status/GetStatus/{id}")]
        [ResponseType(typeof(Status))]
        public IHttpActionResult GetStatus(int id)
        {
            Status status = FindStatus(id);

            if (status == null)
            {
                return NotFound();
            }

            return Ok(status);
        }

        [ResponseType(typeof(Status))]
        public IHttpActionResult PostStatus(Status status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Status.Add(status);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new Status { StatusID = status.StatusID }, status);
        }

        private Status FindStatus(int id)
        {
            return (from s in ctx.Status
                    where s.StatusID == id
                    select s).FirstOrDefault();
        }
    }
}
