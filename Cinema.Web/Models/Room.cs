using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class Room
    {
        [Key]
        public Int32 Id { get; set; }

        public Int32 ScreeningId { get; set; }

        [Required]
        public virtual Screening Screening { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Int32 Rows { get; set; }

        [Required]
        public Int32 Columns { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
