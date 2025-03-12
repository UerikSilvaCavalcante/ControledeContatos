using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControledeContatos.Models;
using Microsoft.EntityFrameworkCore.Design;
using ControledeContatos.Data.Map;
using ControledeContatos.Enums;


namespace ControledeContatos.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext(DbContextOptions<BancoContext> options) : base(options)
		{

		}

		public DbSet<ContatoModel> Contatos { get; set; }
		public DbSet<UsuarioModel> Usuarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			UsuarioModel defaultUser = new UsuarioModel();
			defaultUser.Id = 1;
			defaultUser.Nome = "Admin";
			defaultUser.Login = "admin";
			defaultUser.Perfil = PerfilEnum.Admin;
			defaultUser.Email = "turistajose1@gmail.com";
			defaultUser.Senha = "admin123";
			defaultUser.SetSenhaHash();
			defaultUser.DataCadastro = DateTime.UtcNow;
			modelBuilder.ApplyConfiguration(new ContatoMap());
			modelBuilder.Entity<UsuarioModel>().HasData(
				defaultUser
			);
			base.OnModelCreating(modelBuilder);
		}
	}

}
