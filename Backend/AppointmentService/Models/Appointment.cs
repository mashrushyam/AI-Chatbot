using System.ComponentModel.DataAnnotations;

namespace AppointmentService.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
    }
}
