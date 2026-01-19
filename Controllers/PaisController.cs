using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareaSemana2.Models;

namespace TareaSemana2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly DBContext _context;

        public PaisController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Pais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisModel>>> GetPaises()
        {
            return await _context.Paises.ToListAsync();
        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaisModel>> GetPaisModel(int id)
        {
            var paisModel = await _context.Paises.FindAsync(id);

            if (paisModel == null)
            {
                return NotFound();
            }

            return paisModel;
        }

        // PUT: api/Pais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaisModel(int id, PaisModel paisModel)
        {
            if (id != paisModel.id)
            {
                return BadRequest();
            }

            _context.Entry(paisModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisModelExists(id))
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

        // POST: api/Pais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaisModel>> PostPaisModel(PaisModel paisModel)
        {
            _context.Paises.Add(paisModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaisModel", new { id = paisModel.id }, paisModel);
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaisModel(int id)
        {
            var paisModel = await _context.Paises.FindAsync(id);
            if (paisModel == null)
            {
                return NotFound();
            }

            _context.Paises.Remove(paisModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisModelExists(int id)
        {
            return _context.Paises.Any(e => e.id == id);
        }
    }
}
