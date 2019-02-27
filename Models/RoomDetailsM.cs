using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RoomDetailsM : IRoom  // implements IRoom interface

    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
    }
}
