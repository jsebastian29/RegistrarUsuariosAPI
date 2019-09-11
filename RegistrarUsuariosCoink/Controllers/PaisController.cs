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
    public class PaisController : ApiController
    {
        private IGenericRepository<Pais> _repository = null;

        public PaisController()
        {
            this._repository = new PaisRepository<Pais>();
        }

        public IEnumerable<Pais> Get()
        {
            var lstPaises = _repository.GetAll();
            return lstPaises;
        }
    }
}
