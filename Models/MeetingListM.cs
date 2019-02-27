using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class MeetingListM
    {
        [Key]
        public int MeetingId { get; set; }
        [Display(Name = "Meeting Name")]
        public string MeetingName { get; set; }
       
        [Display(Name = "Organizer Name")]
        public string OrganizerName { get; set; }

        // public int UserId { get; set; }
        [Display(Name = "Agenda")]
        public string Agenda { get; set; }

        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; } = DateTime.Now;


        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; } = DateTime.Now;

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }
       
       public List<string> MeetingAttendeesName { get; set; }

           // public string MeetingAttendeesName { get; set; }
        public static IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
