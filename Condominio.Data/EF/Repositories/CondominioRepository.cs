using GestaoCondominio.Domain.Contracts.Repositories;
using GestaoCondominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Data.EF.Repositories
{
    public class CondominioRepository : ICondominioRepository
    {
        private readonly GestaoCondominioDbContext _context;
        public CondominioRepository(GestaoCondominioDbContext context)
        {
            _context = context;
        }
        public void Add(Condominio entity)
        {
            _context.Condominios.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Condominio entity)
        {
            _context.Condominios.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Condominio entity)
        {
            _context.Condominios.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Condominio> Get()
        {
            return _context.Condominios.ToList();
        }

        public Condominio GetById(int id)
        {
            return _context.Condominios.Find(id);
        }
    }
}
