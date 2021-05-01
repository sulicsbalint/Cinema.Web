using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Persistence
{
    public class Movie
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Director { get; set; }

        [Required]
        public String Star { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Required]
        public Int32 Duration { get; set; }

        public byte[] Image { get; set; }

        public byte[] Cover { get; set; }

        [Required]
        public DateTime Added { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
