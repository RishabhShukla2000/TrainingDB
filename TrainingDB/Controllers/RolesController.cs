using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingDB.Models;



namespace TrainingDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly TrainingDBContext _context;

        public RolesController(TrainingDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            return Ok(await _context.Roles.ToListAsync());
        }
    }
}
