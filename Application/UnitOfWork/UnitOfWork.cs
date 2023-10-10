using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interface;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VeterinariaContext ? _Context;
        public UnitOfWork(VeterinariaContext context){
            _Context = context;
        }






        private PaisRepository ? _Pais;
        private CitaRepository ? _Cita;







        public IPais? Paises => _Pais ??= new PaisRepository(_Context!);

        public ICita? Citas => _Cita ??= new CitaRepository(_Context!);








        public void Dispose()
        {
            _Context!.Dispose();
            GC.SuppressFinalize(this); 
        }

        public Task<int> SaveAsync()
        {
            return _Context!.SaveChangesAsync();
        }
    }
}