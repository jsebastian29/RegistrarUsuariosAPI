using Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegistrarUsuariosCoink.Controllers
{
    public class DepartamentoController : ApiController
    {
        private IGenericRepository<Departamento> _repository = null;

        public DepartamentoController()
        {
            this._repository = new DepartamentoRepository<Departamento>();
        }

        [Route("api/Departamento/GetDepartamentoByPaisId")]
        public IEnumerable<Departamento> GetDepartamentoByPaisId(int id)
        {
            var lstDepartamentos = _repository.GetListById(id);
            return lstDepartamentos;
        }
    }
}
