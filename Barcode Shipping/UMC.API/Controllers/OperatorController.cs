using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UMC.API.Models;

namespace UMC.API.Controllers
{
    public class OperatorController : ApiController
    {
        private QADbContext db = new QADbContext();

        // GET: api/Operator
        public IQueryable<mst_operator> Getmst_operator()
        {
            return db.mst_operator;
        }

        // GET: api/Operator/5
        [ResponseType(typeof(mst_operator))]
        public async Task<IHttpActionResult> Getmst_operator(string id)
        {
            mst_operator mst_operator = await db.mst_operator.FindAsync(id);
            if (mst_operator == null)
            {
                return NotFound();
            }

            return Ok(mst_operator);
        }

        // PUT: api/Operator/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmst_operator(string id, mst_operator mst_operator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mst_operator.OperatorID)
            {
                return BadRequest();
            }

            db.Entry(mst_operator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mst_operatorExists(id))
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

        // POST: api/Operator
        [ResponseType(typeof(mst_operator))]
        public async Task<IHttpActionResult> Postmst_operator(mst_operator mst_operator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mst_operator.Add(mst_operator);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (mst_operatorExists(mst_operator.OperatorID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mst_operator.OperatorID }, mst_operator);
        }

        // DELETE: api/Operator/5
        [ResponseType(typeof(mst_operator))]
        public async Task<IHttpActionResult> Deletemst_operator(string id)
        {
            mst_operator mst_operator = await db.mst_operator.FindAsync(id);
            if (mst_operator == null)
            {
                return NotFound();
            }

            db.mst_operator.Remove(mst_operator);
            await db.SaveChangesAsync();

            return Ok(mst_operator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mst_operatorExists(string id)
        {
            return db.mst_operator.Count(e => e.OperatorID == id) > 0;
        }
    }
}