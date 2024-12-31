using AppointmentService.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentService.Datas
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) { }
        
        public DbSet<Appointment> Appointments { get; set; }
    }
}
