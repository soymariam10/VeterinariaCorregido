using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;
    public class Departamento : BaseEntity
    {
        [Required]
        public string ? NombreDepartamento { get; set;}
        public int IdPais { get; set;}
        public Pais ? Paises { get; set;}
        public ICollection<Ciudad> ? Ciudades { get; set;}

    }
