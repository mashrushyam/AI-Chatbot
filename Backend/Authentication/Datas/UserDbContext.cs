﻿using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace UserService.Datas
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
