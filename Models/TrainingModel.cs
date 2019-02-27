using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TrainingModel 
    {
        [Key]
       public int TrainingId { get; set; }
        [Required(ErrorMessage = "Please Enter Topic")]
        [Display(Name = "Topic")]
        public string Topic { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Start Time")]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
      
        [Required(ErrorMessage = "Please Enter End Time")]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    }
}
