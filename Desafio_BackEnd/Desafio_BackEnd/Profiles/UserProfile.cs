using AutoMapper;
using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;

namespace Desafio_BackEnd.Profiles;

public class UserProfile : Profile
{
    //Profile do mapeamento das dtos para a classe User 
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();

        //Adição de config para atualizar apenas os valores não nulos.
        CreateMap<UpdateUserDTO, User>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
