using FilmesDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDbConnection.Context
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);


            builder.Entity<Cinema>()
                .HasOne(cinema=>cinema.Gerente)
                .WithMany(gerentes=>gerentes.Cinemas)
                .HasForeignKey(cinemas => cinemas.GerenteId);


            builder.Entity<Sessao>()
                .HasOne(sessao =>sessao.Filme)
                .WithMany(filme=>filme.Sessoes)
                .HasForeignKey(sessao=>sessao.FilmeId);  
            
            builder.Entity<Sessao>()
                .HasOne(sessao =>sessao.Cinema)
                .WithMany(cinema=>cinema.Sessoes)
                .HasForeignKey(sessao=>sessao.CinemaId);
        }

        public DbSet<Filme> Filmes { get; set; }  
        public DbSet<Cinema> Cinemas { get; set; }  
        public DbSet<Endereco> Enderecos { get; set; }  
        public DbSet<Gerente> Gerentes { get; set; }  
        public DbSet<Sessao> Sessao { get; set; }  


    }
}
