using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPRegistroGastos.Models;

namespace TPRegistroGastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : Controller
    {
        private readonly AppDbContext _context;

        public GastoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> Get()
        {
            return await _context.Gastos.OrderByDescending(g => g.Fecha).ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult<Gasto>> Post(Gasto gasto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            if (gasto.Fecha > DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest("La fecha no puede ser futura.");
            }

            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = gasto.Id }, gasto);
        }







    }
}
