using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaisRepository<T> : IGenericRepository<T> where T : class
    {
        private RegistroUsuariosContext context;
        private DbSet<T> dbSet;

        public PaisRepository()
        {
            context = new RegistroUsuariosContext();
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return context.Database.SqlQuery<T>("SelectAllPaises").ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
