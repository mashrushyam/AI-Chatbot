using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AppointmentService.DTOs
{
    public class AppointmentDto
    {
        [Required(ErrorMessage ="Date Field Required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateOnly AppointmentDate { get; set; }

        [Required(ErrorMessage = "Time Field Required")]
        [DataType(DataType.Time, ErrorMessage = "Invalid time format.")]
        public TimeOnly AppointmentTime { get; set; }
    }
}
