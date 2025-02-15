using Microsoft.EntityFrameworkCore;
using NGWalks.API.Data;
using NGWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//injecting my DbContext class
builder.Services.AddDbContext<NGWalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NGWalksConnectionString")));

// injecting my repository class using inMemory repository class for learning purpose.
//builder.Services.AddScoped<IRegionRepository, InMemoryRegionRepository>();

// injecting my repository class using SQL repository class
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

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
