﻿using Microsoft.EntityFrameworkCore;
using PaymentService.Models;

namespace PaymentService.Datas
{
    public class PaymentDbContext:DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }
        public DbSet<Payment> Payments { get; set; }
    }
}
