using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pg_api;

namespace pg_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Segun parametros pageNumber y pageSize retorna data (por el momento fijos)
        [HttpGet("Clients")]
        public async Task<ActionResult<IEnumerable<Clients>>> GetClients(int pageNumber = 1, int pageSize = 10)
        {
            var clients = await _context.Clients
                .Skip((pageNumber - 1) * pageSize) // salta a la cantidad de elementos necesaria
                .Take(pageSize)  //Obtiene la pagina
                .ToListAsync(); // lista los resultados 
            return clients;
        }

        [HttpGet("clientspaged")]
        public async Task<ActionResult<IEnumerable<Clients>>> GetClientsSP(int pageNumber = 1, int pageSize = 10)
        {
            var sql = $"EXEC GetClientsPaged {pageNumber}, {pageSize}";

            var clients = await _context.Clients.FromSqlRaw(sql).ToListAsync(); // ejecutamos la sentencia SQL 

            return clients;
        }

    }
}
