using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistrarUsuariosCoink.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Nombre { get; set; }        
        public string Telefono { get; set; }
        [Required(ErrorMessage = "La Dirección es obligatoria")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El País es obligatorio.")]
        public int PaisId { get; set; }
        [Required(ErrorMessage = "El Departamento es obligatorio.")]
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "la Ciudad es obligatoria.")]
        public int CiudadId { get; set; }
    }
}