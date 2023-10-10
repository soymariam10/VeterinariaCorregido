using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //toma la entidad pais y mapea toda la estructura del dto
            CreateMap<Pais,PaisDto>()
            .ReverseMap();//permite convertir de entidad a dto y viceversa

        }
    }
}