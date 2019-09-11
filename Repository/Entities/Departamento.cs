using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        //Foreign Keys
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
