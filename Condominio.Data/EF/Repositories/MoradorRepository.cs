using GestaoCondominio.Domain.Contracts.Repositories;
using GestaoGestaoCondominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCondominio.Data.EF.Repositories
{
    public class MoradorRepository : IMoradorRepository
    {
        private readonly GestaoCondominioDbContext _context;
        public MoradorRepository(GestaoCondominioDbContext context)
        {
            _context = context;
        }
        public void Add(Morador entity)
        {
            _context.Moradores.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Morador entity)
        {
            _context.Moradores.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Morador entity)
        {
            _context.Moradores.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Morador> Get()
        {
            return  _context.Moradores.Include(x => x.Familia).ToList();
        }

        public Morador GetById(int id)
        {
            return _context.Moradores.Find(id);
        }
        public async Task<IEnumerable<Morador>> GetWithFamiliaAsync()
        {
            return await _context.Moradores.Include(x => x.Familia).ToListAsync();
        }
    }
}
