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
    public class RetirosController : ApiController
    {
        private DBModels db = new DBModels();

        // GET: api/Retiros
        public IQueryable<Retiros> GetRetiros()
        {
            return db.Retiros;
        }

        // GET: api/Retiros/5
        [ResponseType(typeof(Retiros))]
        public IHttpActionResult GetRetiros(int id)
        {
            Retiros retiros = db.Retiros.Find(id);
            if (retiros == null)
            {
                return NotFound();
            }

            return Ok(retiros);
        }

        // PUT: api/Retiros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRetiros(int id, Retiros retiros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retiros.NumeroSolicitud)
            {
                return BadRequest();
            }

            db.Entry(retiros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetirosExists(id))
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

        // POST: api/Retiros
        [ResponseType(typeof(Retiros))]
        public IHttpActionResult PostRetiros(Retiros retiros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Retiros.Add(retiros);
            db.SaveChanges();

            Suministros suministro = db.Suministros.Find(retiros.CodigoProducto);

            if (suministro != null)
            {
                suministro.CantidadActual -= retiros.CantidadRetiro;

                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = retiros.NumeroSolicitud }, retiros);
        }

        // DELETE: api/Retiros/5
        [ResponseType(typeof(Retiros))]
        public IHttpActionResult DeleteRetiros(int id)
        {
            Retiros retiros = db.Retiros.Find(id);
            if (retiros == null)
            {
                return NotFound();
            }

            db.Retiros.Remove(retiros);
            db.SaveChanges();

            return Ok(retiros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RetirosExists(int id)
        {
            return db.Retiros.Count(e => e.NumeroSolicitud == id) > 0;
        }
    }
}