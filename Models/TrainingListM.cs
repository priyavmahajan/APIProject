using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainingListM
    {
        [Key]
        public int TrainingId { get; set; }
        [Display(Name = "Topic")]
        public string Topic { get; set; }

        // public int UserId { get; set; }
        [Display(Name = "Trainer Name")]
        public string TrainerName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; } 


        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; } 

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        public static IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
