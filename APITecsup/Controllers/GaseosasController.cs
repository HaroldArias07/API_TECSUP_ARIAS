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
using APITecsup.Context;
using APITecsup.Models;

namespace APITecsup.Controllers
{
    public class GaseosasController : ApiController
    {
        private ExampleContext db = new ExampleContext();

        // GET: api/Gaseosas
        public IQueryable<Gaseosas> GetGaseosas()
        {
            return db.Gaseosas;
        }

        // GET: api/Gaseosas/5
        [ResponseType(typeof(Gaseosas))]
        public IHttpActionResult GetGaseosas(int id)
        {
            Gaseosas gaseosas = db.Gaseosas.Find(id);
            if (gaseosas == null)
            {
                return NotFound();
            }

            return Ok(gaseosas);
        }

        // PUT: api/Gaseosas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGaseosas(int id, Gaseosas gaseosas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gaseosas.GaseosaID)
            {
                return BadRequest();
            }

            db.Entry(gaseosas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GaseosasExists(id))
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

        // POST: api/Gaseosas
        [ResponseType(typeof(Gaseosas))]
        public IHttpActionResult PostGaseosas(Gaseosas gaseosas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gaseosas.Add(gaseosas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gaseosas.GaseosaID }, gaseosas);
        }

        // DELETE: api/Gaseosas/5
        [ResponseType(typeof(Gaseosas))]
        public IHttpActionResult DeleteGaseosas(int id)
        {
            Gaseosas gaseosas = db.Gaseosas.Find(id);
            if (gaseosas == null)
            {
                return NotFound();
            }

            db.Gaseosas.Remove(gaseosas);
            db.SaveChanges();

            return Ok(gaseosas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GaseosasExists(int id)
        {
            return db.Gaseosas.Count(e => e.GaseosaID == id) > 0;
        }
    }
}