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
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly GestaoCondominioDbContext _context;
        public FamiliaRepository(GestaoCondominioDbContext context)
        {
            _context = context;
        }
        public void Add(Familia entity)
        {
            _context.Familias.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Familia entity)
        {
            _context.Familias.Remove(entity);
            _context.SaveChanges();
        }

        public void Edit(Familia entity)
        {
            _context.Familias.Update(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Familia> Get()
        {
            return _context.Familias.ToList();
        }

        public Familia GetById(int id)
        {
            return _context.Familias.Find(id);
        }
    }
}
