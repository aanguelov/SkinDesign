using SkinDesign.Entities;
using System.Linq;

namespace SkinDesign.Interfaces
{
    public interface IProceduresData
    {
        IQueryable<Procedure> GetAll();

        Procedure GetById(int id);

        void Add(Procedure procedure);

        void Delete(int id);

        void Save();
    }
}
