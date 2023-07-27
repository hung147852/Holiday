using Microsoft.AspNetCore.Mvc;
using Holiday.Entities;

namespace Holiday.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidayController
    {
        public ApplicationDbContext _context;
        public HolidayController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]

    }
}
