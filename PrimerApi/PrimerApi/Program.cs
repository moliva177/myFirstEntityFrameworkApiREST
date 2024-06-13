using Microsoft.EntityFrameworkCore;
using PrimerApi.Data;
using PrimerApi.Interfaces;
using PrimerApi.Interfaces.Services;
using PrimerApi.Mappings;
using PrimerApi.Repos;
using PrimerApi.Services.Avion;
using PrimerApi.Services.Usuario;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//armo el contextDB
builder.Services.AddDbContext<ContextDb>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDatabase"));
});

//inyeccion de servicios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAvionRepository, AvionRepository>();
builder.Services.AddScoped<IAvionService, AvionService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

//agrego permisos de CORS para que puedan consumir la api
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//agrego los cors
app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
