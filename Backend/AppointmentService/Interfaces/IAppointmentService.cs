using AppointmentService.DTOs;

namespace AppointmentService.Interfaces
{
    public interface IAppointmentService
    {
        Task<string> SetAppointment(AppointmentDto  appointmentDto, int userId);
    }
}
