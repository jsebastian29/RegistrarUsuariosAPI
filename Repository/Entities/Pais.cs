using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<Departamento> Departamento { get; set; }
    }
}
