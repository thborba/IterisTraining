using ControleTarefas.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
        }
        public virtual DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.Property(x => x.Titulo).IsUnicode(false);
                entity.Property(x => x.Descricao).IsUnicode(false);
                entity.Property(x => x.Concluido).HasDefaultValue(false);
            });

        }
    }
}
