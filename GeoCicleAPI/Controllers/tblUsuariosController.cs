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
using GeoCicleAPI.Models;

namespace GeoCicleAPI.Controllers
{
    [RoutePrefix("Registros/Usuario")]

    public class tblUsuariosController : ApiController
    {
        private Model db = new Model();

        // GET: api/Usuario
        [HttpGet]
        [Route("Selecionar")]
        public IQueryable<tblUsuario> GettblUsuario()
        {
            return db.tblUsuario;
        }

        // GET: api/Usuario/5
        [HttpGet]
        [Route("Selecionar/{id}")]
        [ResponseType(typeof(tblUsuario))]
        public IHttpActionResult GettblUsuario(int id)
        {
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return Ok(tblUsuario);
        }

        // PUT: api/Usuario/5
        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblUsuario(int id, tblUsuario tblUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUsuario.idUsuario)
            {
                return BadRequest();
            }

            db.Entry(tblUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblUsuarioExists(id))
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

        // feito por mim
        // feito por mim
        [HttpGet]
        [Route("Selecionar/{email}/{senha}")]
        [ResponseType(typeof(tblUsuario))]
        public IHttpActionResult GettblUsuarioByEmailAndSenha([FromUri] string email, [FromUri] string senha)// ANALISAR COM CUIDADO DEPOIS
        {
            tblUsuario tblUsuario = db.tblUsuario.FirstOrDefault(u => u.email == email && u.senha == senha);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return Ok(tblUsuario);
        }
        // feito por mim
        // feito por mim


        // POST: api/Usuario
        [HttpPost]
        [Route("UsuarioInserir", Name = "UsuarioInserir")]
        [ResponseType(typeof(tblUsuario))]
        public IHttpActionResult PosttblUsuario(tblUsuario tblUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblUsuario.Add(tblUsuario);
            db.SaveChanges();

            return CreatedAtRoute("UsuarioInserir", new { id = tblUsuario.idUsuario }, tblUsuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(tblUsuario))]
        public IHttpActionResult DeletetblUsuario(int id)
        {
            tblUsuario tblUsuario = db.tblUsuario.Find(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            db.tblUsuario.Remove(tblUsuario);
            db.SaveChanges();

            return Ok(tblUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblUsuarioExists(int id)
        {
            return db.tblUsuario.Count(e => e.idUsuario == id) > 0;
        }
    }
}