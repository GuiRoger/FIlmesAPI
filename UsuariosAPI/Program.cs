using FilmesDomain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosDbConnection.Context;
using UsuariosDbConnection.Repositorys;
using UsuariosDomain.Interfaces;
using UsuariosServices.Interfaces;
using UsuariosServices.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
builder.Services.AddIdentity<IdentityUser<int>,IdentityRole<int>>()
    .AddEntityFrameworkStores<ApiUserContextDb>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ApiUserContextDb>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
