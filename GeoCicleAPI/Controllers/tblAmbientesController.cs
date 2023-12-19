using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GeoCicleAPI.DTO;
using GeoCicleAPI.Models;

namespace GeoCicleAPI.Controllers
{
    [RoutePrefix("Registros/Ambiente")]

    public class tblAmbientesController : ApiController
    {
        private Model2 db = new Model2();

        // GET: api/Ambiente
        [HttpGet]
        [Route("Selecionar")]
        public IQueryable<tblAmbiente> GettblAmbiente()
        {
            return db.tblAmbiente;
        }

        // GET: api/Ambiente/5
        [HttpGet]
        [Route("Selecionar/{id}")]
        [ResponseType(typeof(tblAmbiente))]
        public IHttpActionResult GettblAmbiente(int id)
        {
            tblAmbiente tblAmbiente = db.tblAmbiente.Find(id);
            if (tblAmbiente == null)
            {
                return NotFound();
            }

            return Ok(tblAmbiente);
        }


        // PUT: api/Ambiente/5
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAmbiente(int id, tblAmbiente tblAmbiente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAmbiente.idLocal)
            {
                return BadRequest();
            }

            db.Entry(tblAmbiente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAmbienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Ambiente
        [HttpPost]
        [Route("Inserir", Name = "Inserir")]
        [ResponseType(typeof(tblAmbiente))]
        public IHttpActionResult PosttblAmbiente(AmbienteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entidade = new tblAmbiente
            {
                nmAmbiente = dto.NomeLocal,
                latitude = dto.Latitude,
                longitude = dto.Longitude
            };

            db.tblAmbiente.Add(entidade);
            db.SaveChanges();

            return CreatedAtRoute("Inserir", new { id = entidade.idLocal }, entidade);
        }

        // DELETE: api/Ambiente/5
        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(tblAmbiente))]
        public IHttpActionResult DeletetblAmbiente(int id)
        {
            tblAmbiente tblAmbiente = db.tblAmbiente.Find(id);
            if (tblAmbiente == null)
            {
                return NotFound();
            }

            db.tblAmbiente.Remove(tblAmbiente);
            db.SaveChanges();

            return Ok(tblAmbiente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAmbienteExists(int id)
        {
            return db.tblAmbiente.Count(e => e.idLocal == id) > 0;
        }
    }
}