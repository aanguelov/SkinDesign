using SkinDesign.Interfaces;
using SkinDesign.Entities;
using SkinDesign.Data;
using System.Linq;
using System;

namespace SkinDesign.Services
{
    public class ProceduresData : IProceduresData
    {
        private SkinDesignDbContext _context;

        public ProceduresData(SkinDesignDbContext context)
        {
            _context = context;
        }

        public void Add(Procedure procedure)
        {
            _context.Procedures.Add(procedure);
            this.Save();
        }

        public void Delete(int id)
        {
            var procedure = this.GetById(id);
            _context.Remove(procedure);
            this.Save();
        }

        public IQueryable<Procedure> GetAll()
        {
            return _context.Procedures;
        }

        public Procedure GetById(int id)
        {
            return _context.Procedures.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
