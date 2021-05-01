using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Persistence
{
    public class Employee
    {
        [Key]
        public Int32 Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]
        public String Password { get; set; }
    }
}
