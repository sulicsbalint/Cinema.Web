using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class Screening
    {
        [Key]
        public Int32 Id { get; set; }

        public Int32 MovieId { get; set; }

        [Required]
        public virtual Movie Movie { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public Int32 RoomId { get; set; }

        [Required]
        public virtual Room Room { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
