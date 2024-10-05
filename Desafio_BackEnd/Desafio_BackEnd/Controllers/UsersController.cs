using AutoMapper;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_BackEnd.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(UserContext context, IMapper mapper) : ControllerBase
{

    private readonly UserContext _userContext = context;
    private readonly IMapper _mapper = mapper;


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<User>> RetornaTodosUsuarios()
    {
        return Ok(_userContext.Users);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> RetornaUsuarioPorId(int id)
    {
        var user = _userContext.Users.Find(id);

        if (user == null)
            return NotFound("Usuário não encontrado.");

        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<User> AdicionaUsuario([FromBody] CreateUserDTO user)
    {
        var novoUser = _mapper.Map<User>(user);
        try
        {
            _userContext.Users.Add(novoUser);
            _userContext.SaveChanges();
        }
        catch (Exception)
        {
            return BadRequest("Dados inválidos.");
        }

        return Created($"api/user/{novoUser.Id}", novoUser);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> AtualizaUsuario(int id, [FromBody] UpdateUserDTO user)
    {
        var userAntigo = _userContext.Users.Find(id);

        if (userAntigo == null)
            return NotFound("Usuário não encontrado.");

        try
        {
            _mapper.Map(user, userAntigo);
            _userContext.SaveChanges();
        }
        catch (Exception)
        {
            return BadRequest("Dados inválidos.");
        }

        return Ok(userAntigo);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> DeletaUsuarioPorId(int id)
    {
        var user = _userContext.Users.Find(id);

        if (user == null) { return NotFound("Usuário não encontrado."); }

        _userContext.Users.Remove(user);
        _userContext.SaveChanges();

        return NoContent();
    }
}
