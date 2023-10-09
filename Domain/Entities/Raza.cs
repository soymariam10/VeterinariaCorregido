using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class Raza : BaseEntity
    {
        [Required]
        public string ? NombreRaza { get; set; }
        public ICollection<Mascota> ? Mascotas { get; set; }

    }
