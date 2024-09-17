using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITest2.Models;

namespace APITest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoObjectsController : ControllerBase
    {
        private readonly InfoObjectDbContext _context;

        public InfoObjectsController(InfoObjectDbContext context)
        {
            _context = context;
        }

        // GET: api/InfoObjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoObject>>> GetInfoObjects()
        {
            return await _context.InfoObjects.ToListAsync();
        }

        // GET: api/InfoObjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoObject>> GetInfoObject(int id)
        {
            var infoObject = await _context.InfoObjects.FindAsync(id);

            if (infoObject == null)
            {
                return NotFound();
            }

            return infoObject;
        }

        // PUT: api/InfoObjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoObject(int id, InfoObject infoObject)
        {
            if (id != infoObject.Id)
            {
                return BadRequest();
            }

            _context.Entry(infoObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoObjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InfoObjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoObject>> PostInfoObject(InfoObject infoObject)
        {
            _context.InfoObjects.Add(infoObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoObject", new { id = infoObject.Id }, infoObject);
        }

        // DELETE: api/InfoObjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoObject(int id)
        {
            var infoObject = await _context.InfoObjects.FindAsync(id);
            if (infoObject == null)
            {
                return NotFound();
            }

            _context.InfoObjects.Remove(infoObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoObjectExists(int id)
        {
            return _context.InfoObjects.Any(e => e.Id == id);
        }
    }
}
