using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Holiday.Entities
{
    public class Holiday1
    {
        // DB gồm có
        //id, holidayname. start date, end date, createdat, Deleteat, who create, who delete
        [Key]
        public int Id { get; set; }
        [Required]
        public string Hldname { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public char RecStatus { get; set; } = 'N';

    }
}
