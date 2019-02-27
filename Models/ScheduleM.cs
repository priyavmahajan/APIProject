using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScheduleM
    {
        // [Key]
        //public int ScheduleId { get ; set ; }
        [Required(ErrorMessage = "Please Enter Date Time")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Please Enter Date Time")]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
      // public int RoomId { get; set; }
    }
}
