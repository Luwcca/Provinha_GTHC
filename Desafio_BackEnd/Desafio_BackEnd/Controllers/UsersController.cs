using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;
using DesafioBackEnd_Api.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Desafio_BackEnd.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUserRepository repository) : ControllerBase
{

    private readonly IUserRepository _userRepository = repository;


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<User>> RetornaTodosUsuarios()
    {
        return Ok(_userRepository.RetornaTodosUsuarios());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> RetornaUsuarioPorId(int id)
    {
        var user = _userRepository.RetornaUsuarioPorId(id);

        if (user == null)
            return NotFound("Usuário não encontrado.");

        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<User> AdicionaUsuario([FromBody] CreateUserDTO user)
    {

        try
        {
            var novoUser = _userRepository.AdicionaUsuario(user);

            return Created($"api/user/{novoUser.Id}", novoUser);
        }
        catch (Exception)
        {
            return BadRequest("Dados inválidos.");
        }


    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> AtualizaUsuario(int id, [FromBody] UpdateUserDTO user)
    {
        try
        {
            var userAtualizado = _userRepository.AtualizaUsuario(id, user);

            return Ok(userAtualizado);
        }
        catch (NullReferenceException)
        {
            return NotFound("Usuário não encontrado.");
        }
        catch (Exception)
        {
            return BadRequest("Dados inválidos.");
        }


    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<User> DeletaUsuarioPorId(int id)
    {
        try
        {
            _userRepository.DeletaUsuarioPorId(id);

            return NoContent();
        }
        catch (NullReferenceException)
        {
            return NotFound("Usuário não encontrado.");
        }

    }
}
