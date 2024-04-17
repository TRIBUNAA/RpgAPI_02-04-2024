using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LV.Models;
using LV.Models.Enuns;
using LV.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        // criar construtor

        public DataContext (DbContextOptions <DataContext> options) : base (options)
        //classe para criar bd

        {

        }

        public DbSet<Personagem> TB_PERSONAGENS { get; set; }
        public DbSet<Armas> TB_ARMAS { get; set; }
        //mapeando tabela
        public DbSet<Usuario> TB_USUARIOS { get; set; }
        public DbSet<Habilidade> TB_HABILIDADES { get; set; }

        public DbSet<PersonagemHabilidade> TB_PERSONAGENS_HABILIDADES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //define  q acontece no banco
        {
            modelBuilder.Entity<Personagem> (). ToTable("TB_PERSONAGENS");
            modelBuilder.Entity <Armas> ().ToTable("TB_ARMAS");
            modelBuilder.Entity <Usuario> ().ToTable("TB_USUARIOS");
            modelBuilder.Entity <Habilidade> ().ToTable("TB_HABILIDADES");
            modelBuilder.Entity <PersonagemHabilidade> ().ToTable("TB_PERSONAGENS_HABILIDADES");

            //Relacionamento One to Many (um para muitos)
            modelBuilder.Entity<Usuario>()
            .HasMany(e => e.Personagens)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .IsRequired(false);

             modelBuilder.Entity<Personagem>()
            .HasOne(e => e.Armas)
            .WithOne(e => e.Personagem)
            .HasForeignKey<Armas>(e => e.PersonagemId)
            .IsRequired();


            modelBuilder.Entity<Personagem>().HasData
            (
                new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro, UsuarioId =1 },
                new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro, UsuarioId =1 },
                new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo, UsuarioId =1 },
                new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago, UsuarioId =1 },
                new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro, UsuarioId =1 },
                new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo, UsuarioId =1 },
                new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago, UsuarioId =1 }
            );
                // ctrl . no Enum
            
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Armas> (). ToTable("TB_ARMAS");
            modelBuilder.Entity <Armas> ().HasData
            (
                new Armas () {Id = 1, Nome = "Espada", Dano= 20, PersonagemId = 1 }, 
                new Armas () {Id = 2, Nome = "Machado", Dano=12, PersonagemId = 2 },
                new Armas () {Id = 3, Nome = "Lança", Dano=18, PersonagemId = 3 },
                new Armas () {Id = 4, Nome = "Cajado", Dano=25, PersonagemId = 4 },
                new Armas () {Id = 5, Nome = "Arco e flecha", Dano= 15, PersonagemId = 5 },
                new Armas () {Id = 6, Nome = "Karambit", Dano= 30, PersonagemId = 6 },
                new Armas () {Id = 7, Nome = "Ak-47", Dano= 10, PersonagemId = 7 }
            );

            modelBuilder.Entity<PersonagemHabilidade>()
            .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId});

            modelBuilder.Entity<Habilidade>().HasData
            (
                new Habilidade (){Id=1, Nome="Clone", Dano= 35},
                new Habilidade (){Id=2, Nome="Adormecer", Dano= 20},
                new Habilidade (){Id=3, Nome="Congelar", Dano= 41},
                new Habilidade (){Id=4, Nome="Hipnotizar", Dano=10 },
                new Habilidade (){Id=5, Nome="Ressurreição", Dano= 15},
                new Habilidade (){Id=6, Nome="Tornado de fogo", Dano= 48},
                new Habilidade (){Id=7, Nome="Explosão", Dano= 49}

            );
          modelBuilder.Entity<PersonagemHabilidade>().HasData(

            new PersonagemHabilidade () {PersonagemId = 1, HabilidadeId =1 },
            new PersonagemHabilidade () {PersonagemId = 2, HabilidadeId =2 },
            new PersonagemHabilidade () {PersonagemId = 3, HabilidadeId =3 },
            new PersonagemHabilidade () {PersonagemId = 4, HabilidadeId =4 },
            new PersonagemHabilidade () {PersonagemId = 5, HabilidadeId =5 },
            new PersonagemHabilidade () {PersonagemId = 6, HabilidadeId =6 },
            new PersonagemHabilidade () {PersonagemId = 7, HabilidadeId =7 }
            
          );



            // Inicio da criação de usuario padrão 
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
            user.id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            //fim da criação do usuário padrão.

            //define que se o perfil nao for informado, o valor padrão será jogador
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Jogador");

        } //fim do método OnModelCreating
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar"). HaveMaxLength(200);
            //cria campos de texto/ muda string para varchar no banco
            
        }

          
    
    }
} 
