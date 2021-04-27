using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Persistence
{
    public class Room
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public Int32 Rows { get; set; }

        [Required]
        public Int32 Columns { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
