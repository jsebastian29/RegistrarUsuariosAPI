using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrarUsuariosCoink.Models
{
    public class ListUsuarioViewModel
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
    }
}