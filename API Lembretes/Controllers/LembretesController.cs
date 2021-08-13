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
using API_Lembretes.Models;

namespace API_Lembretes.Controllers
{
    public class LembretesController : ApiController
    {
        private LembretesContext db = new LembretesContext();

        // GET: api/Lembretes
        public IQueryable<Lembrete> GetLembretes()
        {
            return db.Lembretes;
        }

        // GET: api/Lembretes/5
        [ResponseType(typeof(Lembrete))]
        public IHttpActionResult GetLembrete(int id)
        {
            Lembrete lembrete = db.Lembretes.Find(id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return Ok(lembrete);
        }

        // PUT: api/Lembretes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLembrete(int id, Lembrete lembrete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lembrete.Id)
            {
                return BadRequest();
            }

            db.Entry(lembrete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LembreteExists(id))
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

        // POST: api/Lembretes
        [ResponseType(typeof(Lembrete))]
        public IHttpActionResult PostLembrete(Lembrete lembrete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lembretes.Add(lembrete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lembrete.Id }, lembrete);
        }

        // DELETE: api/Lembretes/5
        [ResponseType(typeof(Lembrete))]
        public IHttpActionResult DeleteLembrete(int id)
        {
            Lembrete lembrete = db.Lembretes.Find(id);
            if (lembrete == null)
            {
                return NotFound();
            }

            db.Lembretes.Remove(lembrete);
            db.SaveChanges();

            return Ok(lembrete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LembreteExists(int id)
        {
            return db.Lembretes.Count(e => e.Id == id) > 0;
        }
    }
}