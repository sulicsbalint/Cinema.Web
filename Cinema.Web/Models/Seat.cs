using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class Seat
    {
        [Key]
        public Int32 Id { get; set; }

        public Int32 ScreeningId { get; set; }

        [Required]
        public virtual Screening Screening { get; set; }

        [Required]
        public Int32 Row { get; set; }

        [Required]
        public Int32 Column { get; set; }

        [Required]
        public Int32 Status { get; set; }

        public String ReserverName { get; set; }

        public Int32? ReserverPhone { get; set; }
    }
}
