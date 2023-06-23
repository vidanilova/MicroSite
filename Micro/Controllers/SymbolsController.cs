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
    public class SymbolsController : ApiController
    {
        private MicroPoiskEntities1 db = new MicroPoiskEntities1();

        // GET: api/Symbols
        [ResponseType(typeof(List<ResponseSymbols>))]
        public IHttpActionResult GetSymbols(int id)
        {
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return NotFound();
            }

            return Ok(symbol);
        }
        public IQueryable<Symbol> GetSymbols()
        {
            return db.Symbols;
        }

        // GET: api/Symbols/5
        [ResponseType(typeof(Symbol))]
        public IHttpActionResult GetSymbol(int id)
        {
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return NotFound();
            }

            return Ok(symbol);
        }

        // PUT: api/Symbols/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSymbol(int id, Symbol symbol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != symbol.id_symbol)
            {
                return BadRequest();
            }

            db.Entry(symbol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SymbolExists(id))
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

        // POST: api/Symbols
        [ResponseType(typeof(Symbol))]
        public IHttpActionResult PostSymbol(Symbol symbol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Symbols.Add(symbol);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SymbolExists(symbol.id_symbol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = symbol.id_symbol }, symbol);
        }

        // DELETE: api/Symbols/5
        [ResponseType(typeof(Symbol))]
        public IHttpActionResult DeleteSymbol(int id)
        {
            Symbol symbol = db.Symbols.Find(id);
            if (symbol == null)
            {
                return NotFound();
            }

            db.Symbols.Remove(symbol);
            db.SaveChanges();

            return Ok(symbol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SymbolExists(int id)
        {
            return db.Symbols.Count(e => e.id_symbol == id) > 0;
        }
    }
}