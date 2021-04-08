using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class BookViewModel
    {
        public List<Seat> Seats { get; set; }

        [Required(ErrorMessage = "A név megadása kötelező.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A telefonszám megadása kötelező.")]
        [Phone(ErrorMessage = "A telefonszám formátuma nem megfelelő.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public int Id { get; set; }

        public string RoomName { get; set; }

        public DateTime StartTime { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }
    }
}
