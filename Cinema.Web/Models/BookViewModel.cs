using System.Collections.Generic;

namespace Cinema.Web.Models
{
    public class BookViewModel
    {
        public List<Seat> Seats { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int Id { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }
    }
}
