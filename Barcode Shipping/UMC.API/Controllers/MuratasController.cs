using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UMC.API.Models;

namespace UMC.API.Controllers
{
    public class MuratasController : ApiController
    {
        private QADbContext db = new QADbContext();

        // GET: api/Muratas
        public IEnumerable<Murata> GetMuratas()
        {
            return db.Database.SqlQuery<Murata>("SELECT TOP(10000) * FROM [barcode_db].[dbo].[Muratas]").ToList();
        }

        // GET: api/GetLabelMurataInBox/5
        public IEnumerable<Murata> GetLabelMurataInBox(string id)
        {
            if (id == null)
            {
                return null;
            }
            var param = new SqlParameter()
            {
                ParameterName = "@boxId",
                SqlDbType = SqlDbType.VarChar,
                Value = id,
            };
            var muratas = db.Database.SqlQuery<Murata>("EXEC [dbo].[sp_Murata_by_BoxId] @boxId", param).ToList();
            if (muratas == null)
            {
                return null;
            }

            return muratas;
        }


        /// <summary>
        /// Label UMC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         // GET: api/GetProducts_Murata_by_ID/5
        [ResponseType(typeof(Murata))]
        public async Task<IHttpActionResult> GetProducts_Murata_by_ID(string id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var param = new SqlParameter()
            {
                ParameterName = "@labelUMC",
                SqlDbType = SqlDbType.VarChar,
                Value = id,
            };
            var murata = await db.Database.SqlQuery<Murata>("EXEC [dbo].[sp_Murata_by_ID] @labelUMC", param).SingleAsync();
            if(murata == null)
            {
                return NotFound();
            }

            return Ok(murata);
        }


        // PUT: api/Muratas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMurata(string id, Murata murata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != murata.ProductionID)
            {
                return BadRequest();
            }

            db.Entry(murata).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MurataExists(id))
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

        // POST: api/Muratas
        [ResponseType(typeof(Murata))]
        public async Task<IHttpActionResult> PostMurata(Murata murata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Muratas.Add(murata);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MurataExists(murata.ProductionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = murata.ProductionID }, murata);
        }

        // DELETE: api/Muratas/5
        [ResponseType(typeof(Murata))]
        public async Task<IHttpActionResult> DeleteMurata(string id)
        {
            Murata murata = await db.Muratas.FindAsync(id);
            if (murata == null)
            {
                return NotFound();
            }

            db.Muratas.Remove(murata);
            await db.SaveChangesAsync();

            return Ok(murata);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MurataExists(string id)
        {
            return db.Muratas.Count(e => e.ProductionID == id) > 0;
        }
    }
}