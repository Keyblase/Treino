using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treino.Core.Entidades;

namespace Treino.Data
{
    public class DataContexto : DbContext
    {
        public DataContexto(DbContextOptions<DataContexto> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database.EnsureCreated();

            //Nome das tabelas            
            modelBuilder.Entity<UsuarioEntity>().ToTable("Usuarios");
            modelBuilder.Entity<EspecieEntity>().ToTable("Especies");
            modelBuilder.Entity<FilmeEntity>().ToTable("Filmes");
            modelBuilder.Entity<LocalEntity>().ToTable("Locais");
            modelBuilder.Entity<PessoaEntity>().ToTable("Pessoas");
            modelBuilder.Entity<VeiculoEntity>().ToTable("Veiculos");

            //Relacionamentos N para N / Chave composta
            //modelBuilder.Entity<CursoMaterialEntity>()
            //    .HasKey(e => new { e.Id, e.CursoId, e.MaterialId });
            //modelBuilder.Entity<FormacaoCursoEntity>()
            //    .HasKey(e => new { e.Id, e.FormacaoId, e.CursoId });

            // Desativar delete em cascata para todos os relacionamentos
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //Configuracao inicial 
            modelBuilder.Entity<EspecieEntity>().HasNoKey();
            modelBuilder.Entity<FilmeEntity>().HasNoKey();
            modelBuilder.Entity<LocalEntity>().HasNoKey();
            modelBuilder.Entity<PessoaEntity>().HasNoKey();
            modelBuilder.Entity<VeiculoEntity>().HasNoKey();


            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity
                {
                    Id = new Guid("6730a71f-3802-4ae5-97a3-8408a8a18470"),
                    Nome = "Administrador teste",
                    Email = "administrador@teste.com.br",
                    Senha = "12345678",
                });

            modelBuilder.Entity<PessoaEntity>()
            .Property(e => e.Filmes)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<EspecieEntity> Especies{ get; set; }
        public DbSet<FilmeEntity> Filmes { get; set; }
        public DbSet<LocalEntity> Locais { get; set; }
        public DbSet<PessoaEntity> Pessoas { get; set; }
        public DbSet<VeiculoEntity> Veiculos { get; set; }

    }
}
