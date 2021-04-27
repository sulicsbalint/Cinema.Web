using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Persistence
{
    public class BookViewModel
    {
        public List<Seat> Seats { get; set; }

        [Required(ErrorMessage = "A név megadása kötelező.")]
        [RegularExpression(@"[A-Z][a-z]+( [A-Z][a-z]+)+", ErrorMessage = "A név formátuma nem megfelelő.")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "A telefonszám megadása kötelező.")]
        [RegularExpression(@"\+36[237]0([0-9]{7})", ErrorMessage = "A telefonszám formátuma nem megfelelő.")]
        public string Phone { get; set; }

        public int Id { get; set; }

        public string RoomName { get; set; }

        public DateTime StartTime { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public bool NoSeat { get; set; }
    }
}
