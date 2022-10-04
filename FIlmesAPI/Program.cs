

using FilmesDbConnection.Context;
using FilmesDbConnection.Repositorys;
using FilmesDomain.Interfaces;
using FilmesServices.Interfaces;
using FilmesServices.Services;
using GerentesDbConnection.Repositorys;
using GerentesDomain.Interfaces;
using GerentesServices.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IFilmeService,FilmeService>();
builder.Services.AddScoped<IFilmeRepository,FilmeRepository>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<ICinemaRepository, CinemaRepository>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IGerenteService, GerenteService>();
builder.Services.AddScoped<IGerenteRepository, GerenteRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options => 
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

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