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
    //Implementação do Repositorio para terceirizar o acesso ao banco de dados
    private readonly UserContext _userContext = context;
    private readonly IMapper _mapper = mapper;

    //Retorna todos os usuarios
    public IEnumerable<User> RetornaTodosUsuarios() => _userContext.Users;


    //Usa o find para encontrar o usuario com id especificado, retorna nulo se não encontrar
    public User RetornaUsuarioPorId(int id) => _userContext.Users.Find(id);

    //Usa a DTO para traduzir em um usuário e com o try catch faz a adição do usuário no banco
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


    //Usa a DTO para traduzir em um usuário e com o try catch faz a adição do usuário no banco. 
    //É realizado a pesquisa do user com  o find, caso não encontrado joga uma excessão.
    public User AtualizaUsuario(int id, UpdateUserDTO user)
    {
        var userAntigo = RetornaUsuarioPorId(id) ?? throw new NullReferenceException();

        _mapper.Map(user, userAntigo);

        //Após o mapeamento das atualizações, o SaveChanges identifica as alterações e atualiza o banco com base nisso.
        try { _userContext.SaveChanges(); }
        catch (Exception) { throw new Exception(); }
        

        return userAntigo;
    }


    //Usa o find para encontrar o usuario com id especificado, joga uma excessaão de referencia nula se não encontrar
    public void DeletaUsuarioPorId(int id)
    {
        var user = _userContext.Users.Find(id) ?? throw new NullReferenceException();
        _userContext.Users.Remove(user);
        _userContext.SaveChanges();
    }

}
