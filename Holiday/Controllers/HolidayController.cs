using Microsoft.AspNetCore.Mvc;
using Holiday.Entities;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
        [HttpGet]
        public IActionResult GetHolidays() 
        { 
            var holidays = _context.Holidays.Where(h => h.RecStatus == 'N').ToList();
            return View(holidays);
        }
        [HttpGet("{id}")]
        public IActionResult GetHoliday(int id)
        {
            var holiday = _context.Holidays.FirstOrDefault(h => h.Id == id && h.RecStatus == 'N');
            if (holiday == null)
            {
                return NotFound();
            }

            return Ok(holiday);
        }
        [HttpPost]
        public IActionResult CreateHoliday(Holiday1 holiday)
        {
            _context.Holidays.Add(holiday);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetHoliday), new { id = holiday.Id }, holiday);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteHoliday(int id)
        {
            var holiday = _context.Holidays.FirstOrDefault(h => h.Id == id && h.DeletedDate == null);
            if (holiday == null)
            {
                return NotFound();
            }

            holiday.DeletedDate = DateTime.Now;

            _context.SaveChanges();

            return Ok(holiday);
        }
    }
}
