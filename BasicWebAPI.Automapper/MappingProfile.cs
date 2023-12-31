﻿using AutoMapper;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using BasicWebAPI.DtoModels.ContactDto;
using BasicWebAPI.DtoModels.CountryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
        }
    }
}
