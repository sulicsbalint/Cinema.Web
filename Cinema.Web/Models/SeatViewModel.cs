using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Web.Models
{
    public class SeatViewModel
    {
        [Key]
        public Int32 Id { get; set; }

        public Int32 ScreeningId { get; set; }

        [Required]
        public Int32 Row { get; set; }

        [Required]
        public Int32 Column { get; set; }

        [Required]
        public Int32 Status { get; set; }

        public String ReserverName { get; set; }

        public Int32? ReserverPhone { get; set; }

        public static explicit operator SeatViewModel(Seat s) => new SeatViewModel
        {
            Id = s.Id,
            ScreeningId = s.ScreeningId,
            Row = s.Row,
            Column = s.Column,
            Status = s.Status,
            ReserverName = s.ReserverName,
            ReserverPhone = s.ReserverPhone
        };

        public static explicit operator Seat(SeatViewModel vm) => new Seat
        {
            Id = vm.Id,
            ScreeningId = vm.ScreeningId,
            Row = vm.Row,
            Column = vm.Column,
            Status = vm.Status,
            ReserverName = vm.ReserverName,
            ReserverPhone = vm.ReserverPhone
        };
    }
}
