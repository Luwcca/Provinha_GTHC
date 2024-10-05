using AutoMapper;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;
using DesafioBackEnd_Api.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace DesafioBackEnd_Api.Data.Repository;

public class UserRepository(UserContext context, IMapper mapper) : IUserRepository
{

    private readonly UserContext _userContext = context;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<User> RetornaTodosUsuarios() => _userContext.Users;

    public User RetornaUsuarioPorId(int id) => _userContext.Users.Find(id);

    public User AdicionaUsuario(CreateUserDTO user)
    {
        var novoUser = _mapper.Map<User>(user);

        try
        {
            _userContext.Users.Add(novoUser);
            _userContext.SaveChanges();
        }
        catch (Exception) { throw new Exception();}

        return novoUser;
    }

    public User AtualizaUsuario(int id, UpdateUserDTO user)
    {
        var userAntigo = RetornaUsuarioPorId(id) ?? throw new NullReferenceException();

        _mapper.Map(user, userAntigo);

        try { _userContext.SaveChanges(); }
        catch (Exception) { throw new Exception(); }
        

        return userAntigo;
    }

    public void DeletaUsuarioPorId(int id)
    {
        var user = _userContext.Users.Find(id) ?? throw new NullReferenceException();
        _userContext.Users.Remove(user);
        _userContext.SaveChanges();
    }

}
