using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

    public class ClienteTelefono : BaseEntity
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int Numero { get; set; }
        public Cliente ? Clientes { get; set; }
    }
