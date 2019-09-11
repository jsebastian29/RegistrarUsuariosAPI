using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CiudadRepository<T>: IGenericRepository<T> where T: class
    {
        private RegistroUsuariosContext context;
        DbSet<T> dbSet;

        public CiudadRepository()
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
            return context.Database.SqlQuery<T>("SelectCiudadByDepartamentoId @departamentoId",
                new SqlParameter("@departamentoId", id)).ToList();
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
