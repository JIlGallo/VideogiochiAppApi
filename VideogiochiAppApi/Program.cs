using VideogiochiAppApi.Data;
using Microsoft.EntityFrameworkCore;
using VideogiochiAppApi.Interfaces;
using VideogiochiAppApi.Repository;
using VideogiochiAppApi.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IVideogiocoRepository, VideogiocoRepository>();
builder.Services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
builder.Services.AddScoped<IPaeseRepository, PaeseRepository>();

// Aggiungi AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Applica le migrazioni del database
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<DataContext>();

//    // Seed Data
//    SeedData.Initialize(context);
//}

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
