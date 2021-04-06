using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class ScreeningViewModel
    {
        [Key]
        public Int32 Id { get; set; }

        public Int32 MovieId { get; set; }

        [Required(ErrorMessage = "Kezdési időpont megadás kötelező.")]
        public DateTime StartTime { get; set; }

        public Int32 RoomId { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }

        public static explicit operator ScreeningViewModel(Screening s) => new ScreeningViewModel
        {
            Id = s.Id,
            MovieId = s.MovieId,
            StartTime = s.StartTime,
            RoomId = s.RoomId,
            Seats = s.Seats
        };

        public static explicit operator Screening(ScreeningViewModel vm) => new Screening
        {
            Id = vm.Id,
            MovieId = vm.MovieId,
            StartTime = vm.StartTime,
            RoomId = vm.RoomId,
            Seats = vm.Seats
        };
    }
}
