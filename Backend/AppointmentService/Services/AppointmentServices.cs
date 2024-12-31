using AppointmentService.Datas;
using AppointmentService.DTOs;
using AppointmentService.Interfaces;
using AppointmentService.Models;
using Authentication.Models;
using System.Security.Claims;

namespace AppointmentService.Services
{
    public class AppointmentServices : IAppointmentService
    {
        private readonly AppointmentDbContext context;

        public AppointmentServices(AppointmentDbContext context)
        {
            this.context = context;
        }
        public async Task<string> SetAppointment(AppointmentDto appointmentDto, int userId)
        {
            var appointment = new Appointment
            {
                UserId = userId,
                AppointmentDate = appointmentDto.AppointmentDate,
                AppointmentTime = appointmentDto.AppointmentTime,
            };

            await context.Appointments.AddAsync(appointment);
            await context.SaveChangesAsync();

            return "Appointment Added Successfully...";
        }
    }
}
