using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UMC.API.Models;

namespace UMC.API.Controllers
{
    public class ModelsController : ApiController
    {
        private QADbContext db = new QADbContext();

        // GET: api/Models
        public IEnumerable<Model> GetModels()
        {
            return db.Database.SqlQuery<Model>("SELECT * FROM [barcode_db].[dbo].[Models]").ToList();
        }

        // GET: api/Models/5
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> GetModel(string id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModel(string id, Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ModelID)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> PostModel(Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Models.Add(model);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ModelExists(model.ModelID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = model.ModelID }, model);
        }

        // DELETE: api/Models/5
        [ResponseType(typeof(Model))]
        public async Task<IHttpActionResult> DeleteModel(string id)
        {
            Model model = await db.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            db.Models.Remove(model);
            await db.SaveChangesAsync();

            return Ok(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModelExists(string id)
        {
            return db.Models.Count(e => e.ModelID == id) > 0;
        }
    }
}