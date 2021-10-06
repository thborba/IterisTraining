using CatalogoVideos.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoVideos.DAL
{
    public class AppDbContext : DbContext
    {

		public AppDbContext(DbContextOptions<AppDbContext> options)
	   : base(options)
		{
		}
		public virtual DbSet<Video> Videos { get; set; }

		public virtual DbSet<Categoria> Categorias { get; set; }
		public virtual DbSet<Responsavel> Responsaveis { get; set; }
		public virtual DbSet<VideoCategoria> VideoCategorias { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Categoria>(entity =>
			{
				entity.Property(x => x.Nome).IsUnicode(false);
			});

			modelBuilder.Entity<Responsavel>(entity =>
			{
				entity.Property(x => x.Nome).IsUnicode(false);
			});

			modelBuilder.Entity<Video>(entity =>
			{
				entity.Property(x => x.Titulo).IsUnicode(false);
				entity.Property(x => x.URL).IsUnicode(false);
				entity.HasOne(x => x.Responsavel).WithMany(y => y.Videos).HasForeignKey(x => x.ResponsavelId);
			});

			modelBuilder.Entity<VideoCategoria>(entity =>
			{
				entity.HasOne(x => x.Video).WithMany(y => y.VideoCategorias).HasForeignKey(x => x.VideoId);
				entity.HasOne(x => x.Categoria).WithMany(y => y.VideoCategorias).HasForeignKey(x => x.CategoriaId);
			});
		}

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
