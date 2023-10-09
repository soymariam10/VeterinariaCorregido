using System.Runtime.Intrinsics.Arm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;

    public class Cita : BaseEntity
    {
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public TimeSpan Hora { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public Cliente ? Clientes { get; set; }
        [Required]
        public int IdMascota { get; set; }
        public Mascota ? Mascotas { get; set; }
        [Required]
        public int IdServicio { get; set; }
        public Servicio ? Servicios { get; set; }
        
    }
