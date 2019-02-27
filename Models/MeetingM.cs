using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MeetingM
    {
        [Key]
        public int MeetingId { get; set; }
        [Required(ErrorMessage = "Please Enter Meeting Name")]
        [Display(Name = "Meeting Name")]
        public string MeetingName { get; set; }
        //[Required(ErrorMessage = "Please Enter Organizer Name")]
        //[Display(Name = "Organizer Name")]
        //public string OrganizerName { get; set; }
        [Required(ErrorMessage = "Please Enter Agenda")]
        [Display(Name = "Agenda")]
        public string Agenda { get; set; }
        [Required(ErrorMessage = "Please Enter Start Time")]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Please Enter End Time")]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }
        public int RoomId { get; set; }

        public List<int> MeetingAttendeeId { get; set; }
    }
}
