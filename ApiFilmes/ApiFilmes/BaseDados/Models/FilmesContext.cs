using ApiFilmes.BaseDados.Models;
using ApiFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilmes.Database.Models
{
    public partial class FilmesContext : DbContext
    {
        public FilmesContext()
        {
        }

        public FilmesContext(DbContextOptions<FilmesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Filme> Filmes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Diretor> Diretores { get; set; }
        public virtual DbSet<Ator> Atores { get; set; }
        public virtual DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=api_filmes;Username=postgres;Password=masterkey");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tabela Genero
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_generos");

                entity.ToTable("genero");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });


            // Tabela Diretor
            modelBuilder.Entity<Diretor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_diretores");

                entity.ToTable("diretor");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");
            });

            // Tabela Filme
            modelBuilder.Entity<Filme>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_filmes");

                entity.ToTable("filme");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("titulo");

                entity.Property(e => e.AnoLancamento)
                    .HasColumnName("ano_lancamento");

                entity.Property(e => e.DuracaoMin)
                    .HasColumnName("duracao_min");

                entity.Property(e => e.ClassificacaoEtaria)
                    .HasMaxLength(10)
                    .HasColumnName("classificacao_etaria");

                entity.Property(e => e.Sinopse)
                    .HasColumnName("sinopse");

                entity.Property(e => e.GeneroId)
                    .HasColumnName("genero_id");

                entity.Property(e => e.DiretorId)
                    .HasColumnName("diretor_id");

                // Relacionamento N:1 com Genero
                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.GeneroId)
                    .HasConstraintName("fk_filmes_genero");

                // Relacionamento N:1 com Diretor
                entity.HasOne(d => d.Diretor)
                    .WithMany(p => p.Filmes)
                    .HasForeignKey(d => d.DiretorId)
                    .HasConstraintName("fk_filmes_diretor");
            });

            // Tabela Ator
            modelBuilder.Entity<Ator>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_atores");

                entity.ToTable("ator");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nome");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("data_nascimento");
            });

            // Tabela Avaliacao
            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pk_avaliacoes");

                entity.ToTable("avaliacao");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");

                entity.Property(e => e.FilmeId)
                    .HasColumnName("filme_id");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario");

                entity.Property(e => e.DataAvaliacao)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("data_avaliacao")
                    .HasDefaultValueSql("now()");

                // Relacionamento N:1 com Filme
                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Avaliacoes)
                    .HasForeignKey(d => d.FilmeId)
                    .HasConstraintName("fk_avaliacoes_filme");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
