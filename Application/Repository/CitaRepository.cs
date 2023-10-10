using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Domain.Interface;
using Dominio.Entities;
using Persistence;

namespace Application.Repository
{
    public class CitaRepository : GenericRepository<Cita>, ICita
    {
        private readonly VeterinariaContext _Context;
        public CitaRepository(VeterinariaContext context) : base(context)
        {
            _Context = context;
        }
    }
}