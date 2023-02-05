using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Persistence.Context;
using Link_Backend_EF.Persistence.Repositories;
using Link_Backend_EF.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Repositories init
builder.Services.AddScoped<IIllnessRepository, IllnessRepository>();

// Services init
builder.Services.AddScoped<IIllnessService, IllnessService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
