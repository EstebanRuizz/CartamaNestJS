﻿using AutoMapper;
using Parque.Application.DTOs.Aliances;
using Parque.Domain.Entites;

namespace Parque.Application.Mappings
{
    public class GeneralProfile : Profile
    {

        public GeneralProfile()
        {
            CreateMap<Aliance, AliancesDTO>().ForMember(p => p.TypeAliance, options => options.MapFrom(origen => origen.IdTypeAliancesNavigation.Name));


        }

    }
}