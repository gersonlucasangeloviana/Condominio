using GestaoCondominio.Domain.Entities;
using GestaoGestaoCondominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoCondominio.Data.EF
{
    public class GestaoCondominioDbContext :DbContext
    {
        protected GestaoCondominioDbContext(DbContextOptions options) : base(options) { }

        public GestaoCondominioDbContext(DbContextOptions<GestaoCondominioDbContext> options) : this((DbContextOptions)options)
        {
        }
 
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Morador> Moradores { get; set; }
    }
}
