using Microsoft.EntityFrameworkCore;
using PrescriptionService.Models;

namespace PrescriptionService.Datas
{
    public class PrescriptionDbContext : DbContext
    {
        public PrescriptionDbContext(DbContextOptions<PrescriptionDbContext> options) : base(options) { }  
        public DbSet<Prescription> Prescriptions { get; set; }
    }

}
