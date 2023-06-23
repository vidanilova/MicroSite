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
using Micro.Entities;
using Micro.Models;

namespace Micro.Controllers
{
    public class BoxesController : ApiController
    {
        private MicroPoiskEntities1 db = new MicroPoiskEntities1();

        // GET: api/Boxes
        [ResponseType(typeof(List<ResponseBox>))]
        public IHttpActionResult GetBoxes(int id)
        {
            Box box = db.Boxes.Find(id);
            if (box == null)
            {
                return NotFound();
            }

            return Ok(box);
        }
        public IQueryable <Box> GetBoxes()
        {
            return db.Boxes;
        }

        // GET: api/Boxes/5
        [ResponseType(typeof(Box))]
        public IHttpActionResult GetBox(int id)
        {
            Box box = db.Boxes.Find(id);
            if (box == null)
            {
                return NotFound();
            }

            return Ok(box);
        }

        // PUT: api/Boxes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBox(int id, Box box)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != box.id_box)
            {
                return BadRequest();
            }

            db.Entry(box).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoxExists(id))
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

        // POST: api/Boxes
        [ResponseType(typeof(Box))]
        public IHttpActionResult PostBox(Box box)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boxes.Add(box);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BoxExists(box.id_box))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = box.id_box }, box);
        }

        // DELETE: api/Boxes/5
        [ResponseType(typeof(Box))]
        public IHttpActionResult DeleteBox(int id)
        {
            Box box = db.Boxes.Find(id);
            if (box == null)
            {
                return NotFound();
            }

            db.Boxes.Remove(box);
            db.SaveChanges();

            return Ok(box);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoxExists(int id)
        {
            return db.Boxes.Count(e => e.id_box == id) > 0;
        }
    }
}