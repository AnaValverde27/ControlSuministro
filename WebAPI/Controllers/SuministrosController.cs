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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SuministrosController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Suministros
        public IQueryable<Suministros> GetSuministros()
        {
            return db.Suministros.OrderBy(s => s.Nombre);
        }

        [HttpGet]
        [Route("api/Suministros/BajoMinima")]
        public IQueryable<Suministros> GetSuministrosBajoMinima()
        {
            return db.Suministros.Where(s => s.CantidadActual < s.CantidadMinima);
        }

        // GET: api/Suministros/5
        [ResponseType(typeof(Suministros))]
        public IHttpActionResult GetSuministros(int id)
        {
            Suministros suministros = db.Suministros.Find(id);
            if (suministros == null)
            {
                return NotFound();
            }

            return Ok(suministros);
        }

        // PUT: api/Suministros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuministros(int id, Suministros suministros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suministros.Codigo)
            {
                return BadRequest();
            }

            db.Entry(suministros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuministrosExists(id))
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

        // POST: api/Suministros
        [ResponseType(typeof(Suministros))]
        public IHttpActionResult PostSuministros(Suministros suministros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suministros.Add(suministros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suministros.Codigo }, suministros);
        }

        // DELETE: api/Suministros/5
        [ResponseType(typeof(Suministros))]
        public IHttpActionResult DeleteSuministros(int id)
        {
            Suministros suministros = db.Suministros.Find(id);
            if (suministros == null)
            {
                return NotFound();
            }

            db.Suministros.Remove(suministros);
            db.SaveChanges();

            return Ok(suministros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuministrosExists(int id)
        {
            return db.Suministros.Count(e => e.Codigo == id) > 0;
        }
    }
}