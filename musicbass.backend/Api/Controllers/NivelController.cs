using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using domain;
using infra.DataContext;

namespace api.Controllers
{
    public class NivelController : ApiController
    {
        private musicbassDataContext db = new musicbassDataContext();

        // GET: api/Nivel
        public IQueryable<Nivel> GetNiveis()
        {
            return db.Niveis;
        }

        // GET: api/Nivel/5
        [ResponseType(typeof(Nivel))]
        public IHttpActionResult GetNivel(int id)
        {
            Nivel nivel = db.Niveis.Find(id);
            if (nivel == null)
            {
                return NotFound();
            }

            return Ok(nivel);
        }

        // PUT: api/Nivel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNivel(int id, Nivel nivel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nivel.Id)
            {
                return BadRequest();
            }

            db.Entry(nivel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelExists(id))
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

        // POST: api/Nivel
        [ResponseType(typeof(Nivel))]
        public IHttpActionResult PostNivel(Nivel nivel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Niveis.Add(nivel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nivel.Id }, nivel);
        }

        // DELETE: api/Nivel/5
        [ResponseType(typeof(Nivel))]
        public IHttpActionResult DeleteNivel(int id)
        {
            Nivel nivel = db.Niveis.Find(id);
            if (nivel == null)
            {
                return NotFound();
            }

            db.Niveis.Remove(nivel);
            db.SaveChanges();

            return Ok(nivel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NivelExists(int id)
        {
            return db.Niveis.Count(e => e.Id == id) > 0;
        }
    }
}