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
    public class CiudadController : ApiController
    {
        private IGenericRepository<Ciudad> _repository = null;

        public CiudadController()
        {
            this._repository = new CiudadRepository<Ciudad>();
        }

        [Route("api/Ciudad/GetCiudadByDepartamentoId")]
        public IEnumerable<Ciudad> GetCiudadByDepartamentoId(int id)
        {
            var lstCiudades = _repository.GetListById(id);
            return lstCiudades;
        }

    }
}
