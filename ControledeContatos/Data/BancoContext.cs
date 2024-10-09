using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControledeContatos.Models;
using Microsoft.EntityFrameworkCore.Design;
using ControledeContatos.Data.Map;


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

            modelBuilder.ApplyConfiguration(new ContatoMap());
            base.OnModelCreating(modelBuilder);
        }
    }

}
