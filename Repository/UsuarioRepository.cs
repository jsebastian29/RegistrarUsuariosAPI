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
    public class UsuarioRepository<T> : IGenericRepository<T> where T : class
    {
        private RegistroUsuariosContext context;
        private DbSet<T> dbSet;

        public UsuarioRepository()
        {
            context = new RegistroUsuariosContext();
            dbSet = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return context.Database.SqlQuery<T>("SelectAllUsuarios").ToList();
        }

        public T GetById(int id)
        {
           return dbSet.Find(id);
        }

        public IEnumerable<T> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Usuario usuario = (Usuario)(object)entity;

            var item = context.Database.ExecuteSqlCommand("EXEC InsertUsuario @nombre, @telefono, @direccion, @paisId, @departamentoId, @ciudadId",
                new SqlParameter("@nombre", usuario.Nombre),
                new SqlParameter("@telefono", usuario.Telefono),
                new SqlParameter("@direccion", usuario.Direccion),
                new SqlParameter("@paisId", usuario.PaisId),
                new SqlParameter("@departamentoId", usuario.DepartamentoId),
                new SqlParameter("@ciudadId", usuario.CiudadId));

            if (item > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
