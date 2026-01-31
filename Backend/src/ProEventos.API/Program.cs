using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Implementation;
using ProEventos.Application.Interface;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Implementation;
using ProEventos.Persistence.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProEventosContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("ProEventos.Persistence")));

//APPLICATION
builder.Services.AddScoped<IEventoService, EventoService>();


//REPOSITORIO
builder.Services.AddScoped<IEventoPersistence, EventoPersistenceImplementation>();
builder.Services.AddScoped<IGeralPersistence, GeralPersistenceImplementation>();



builder.Services.AddControllers();

builder.Services.AddCors();

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

app.UseCors(cors =>
    cors.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
