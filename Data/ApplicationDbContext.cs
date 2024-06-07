using Bluetrip.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bluetrip.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<EnderecoModel> Endereco { get; set; }
    public DbSet<PontoTuristicoModel> PontoTuristico { get; set; }
    public DbSet<EventoModel> Evento { get; set; }

    public DbSet<AgendamentoModel> Agendamento { get; set; }

    public DbSet<TuristaModel> Turista { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
