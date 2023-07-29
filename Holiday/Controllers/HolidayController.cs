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
        public List<Holiday1> ListHolidays() 
        { 
            var holidays1 = _context.holidays.Where(h => h.RecStatus == 'N').ToList();
            return holidays1;
        }
        //[HttpGet("{id}")]
        //public IActionResult GetHoliday(int id)
        //{
        //    var holiday = _context.Holidays.FirstOrDefault(h => h.Id == id && h.RecStatus == 'N');
        //    if (holiday == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(holiday);
        //}
        [HttpPost]
        public Object CreateHoliday(Holiday1 holiday)
        {
            _context.holidays.Add(holiday);
            int v = _context.SaveChanges();

            return new { Messsage = "Inserted", Rows = v };
        }
        [HttpDelete("{name}")]
        public Object DeleteHoliday(string name)
        {
            var holiday = _context.holidays.FirstOrDefault(h => h.Name == name && h.DeletedDate == null);
            if (holiday == null)
            {
               return new { Messsage = "Không tìm thấy kì nghỉ lễ này" };
            }
            holiday.IsDeleted = true;
            holiday.DeletedDate = DateTime.Now;
            holiday.RecStatus = 'D';

            _context.SaveChanges();

            return (new { message = "Kì nghỉ lễ đã được xóa." });
        }
    }
}
