﻿using AutoMapper;
using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;

namespace Desafio_BackEnd.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<UpdateUserDTO, User>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
    }
}
