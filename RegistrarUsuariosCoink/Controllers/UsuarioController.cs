using RegistrarUsuariosCoink.Models;
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
    public class UsuarioController : ApiController
    {
        private IGenericRepository<Usuario> _repository = null;
        private IGenericRepository<ListUsuarioViewModel> _repository_viewModel = null;

        public UsuarioController()
        {
            this._repository = new UsuarioRepository<Usuario>();
            this._repository_viewModel = new UsuarioRepository<ListUsuarioViewModel>();
        }

        public IEnumerable<ListUsuarioViewModel> Get()
        {
            var lstUsuarios = _repository_viewModel.GetAll();
            return lstUsuarios;
        }

        [Route("api/Usuario/Insert")]
        [HttpPost]
        public bool Add(Usuario usuario)
        {

            if (usuario == null)
            {
                throw new ArgumentNullException("entity");
            }

            return _repository.Insert(usuario);
        }
    }
}
