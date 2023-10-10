using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class Cliente : BaseEntity
    {
        [Required]
        public string ? Nombre { get; set; }
        [Required]
        public string ? Apellido { get; set; }
        [Required]
        public string ? Email { get; set; }
        public ICollection<ClienteDireccion> ? ClienteDirecciones { get; set; }
        public ICollection<ClienteTelefono> ? ClientesTelefonos { get; set; }
        public ICollection<Mascota> ? Mascostas { get; set; }
        public ICollection<Cita> ? Citas { get; set; }
    }
