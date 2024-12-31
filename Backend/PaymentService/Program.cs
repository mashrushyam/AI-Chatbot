using Microsoft.EntityFrameworkCore;
using PaymentService.Datas;
using PaymentService.Interfaces;
using PaymentService.Services;
using Shared;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<PaymentDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
    options.AddPolicy("UserAdminAccess", policy => policy.RequireClaim(ClaimTypes.Role, "User", "Admin"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPaymentService, PaymentServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAll");


app.MapControllers();

app.Run();