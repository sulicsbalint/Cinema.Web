using System;
using System.Collections.Generic;

namespace Cinema.Web.Models
{
    public class BookViewModel
    {
        public List<Seat> Seats { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int Id { get; set; }

        public string RoomName { get; set; }

        public DateTime StartTime { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }
    }
}
