using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DepartamentoRepository<T> :IGenericRepository<T> where T: class
    {
        private RegistroUsuariosContext context;
        private DbSet<T> dbSet;

        public DepartamentoRepository()
        {
            context = new RegistroUsuariosContext();
            dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetListById(int id)
        {
            return context.Database.SqlQuery<T>("SelectDepartamentoByPaisId @paisId",
                new SqlParameter("@paisId", id)).ToList();
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
