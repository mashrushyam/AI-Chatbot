using InsuranceService.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceService.Datas
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { } 
        public DbSet<Insurance> Insurances { get; set; }
    }
}
