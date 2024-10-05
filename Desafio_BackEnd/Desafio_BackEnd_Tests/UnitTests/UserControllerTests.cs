using AutoMapper;
using Desafio_BackEnd.Controllers;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;
using DesafioBackEnd_Api.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_BackEnd_Tests.UnitTests;

public class UserControllerTests
{
    private readonly Mock<IUserRepository> _mockRespository;
    private readonly UsersController _usersController;
    private readonly CreateUserDTO _createUser;
    private readonly UpdateUserDTO _updateUser;
    private readonly List<User> _users;
    private readonly User _user;

    public UserControllerTests()
    {
        _user = new User { Id = 1, Name = "Test", Email = "teste@email.com" };
        _users =
        [
            _user,
            new User { Id = 2, Name = "Test2", Email = "teste2@email.com" }
        ];

        _createUser = new CreateUserDTO { Name = "Teste3", Email = "teste3@email.com" };
        _updateUser = new UpdateUserDTO { Name = "Update", Email = "update@email.com" };

        _mockRespository = new Mock<IUserRepository>();
        _usersController = new UsersController(_mockRespository.Object);
    }

    [Fact]
    public void RetornaTodosUsuarios_Returns_IEnumerableOfUsers()
    {
        _mockRespository.Setup(x => x.RetornaTodosUsuarios()).Returns(_users);

        var result = _usersController.RetornaTodosUsuarios();

        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result).StatusCode.Equals(200);
    }


    [Fact]
    public void RetornaUsuarioPorId_Returns_User()
    {
        _mockRespository.Setup(x => x.RetornaUsuarioPorId(1)).Returns(_user);

        var result = _usersController.RetornaUsuarioPorId(1);

        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result).StatusCode.Equals(200);
    }

    [Fact]
    public void RetornaUsuarioPorId_Returns_UserNotFound()
    {

        var result = _usersController.RetornaUsuarioPorId(1);

        Assert.NotNull(result);
        Assert.IsType<NotFoundObjectResult>(result.Result).StatusCode.Equals(404);
    }

    [Fact]
    public void AdicionaUsuario_Returns_User()
    {

        _mockRespository.Setup(x => x.AdicionaUsuario(_createUser)).Returns(_user);

        var result = _usersController.AdicionaUsuario(_createUser);

        Assert.NotNull(result);
        Assert.IsType<CreatedResult>(result.Result).StatusCode.Equals(201);
    }

    [Fact]
    public void AdicionaUsuario_Returns_UserBadRequest()
    {

        _mockRespository.Setup(x => x.AdicionaUsuario(_createUser)).Throws(new Exception());


        var result = _usersController.AdicionaUsuario(_createUser);

        Assert.NotNull(result);
        Assert.IsType<BadRequestObjectResult>(result.Result).StatusCode.Equals(400);
    }

    [Fact]
    public void AtualizaUsuario_Returns_User()
    {

        _mockRespository.Setup(x => x.AtualizaUsuario(1, _updateUser)).Returns(_user);


        var result = _usersController.AtualizaUsuario(1, _updateUser);

        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result.Result).StatusCode.Equals(200);
    }

    [Fact]
    public void AtualizaUsuario_Returns_UserNotFound()
    {

        _mockRespository.Setup(x => x.AtualizaUsuario(1, _updateUser)).Throws(new NullReferenceException());


        var result = _usersController.AtualizaUsuario(1, _updateUser);


        Assert.NotNull(result);
        Assert.IsType<NotFoundObjectResult>(result.Result).StatusCode.Equals(404);
    }

    [Fact]
    public void AtualizaUsuario_Returns_UserBadRequest()
    {

        _mockRespository.Setup(x => x.AtualizaUsuario(1, _updateUser)).Throws(new Exception());


        var result = _usersController.AtualizaUsuario(1, _updateUser);


        Assert.NotNull(result);
        Assert.IsType<BadRequestObjectResult>(result.Result).StatusCode.Equals(400);
    }

    [Fact]
    public void DeletaUsuario_Returns_NoContent()
    {

        var result = _usersController.DeletaUsuarioPorId(1);


        Assert.NotNull(result);
        Assert.IsType<NoContentResult>(result.Result).StatusCode.Equals(204);
    }

    [Fact]
    public void DeletaUsuario_Returns_UserNotFound()
    {

        _mockRespository.Setup(x => x.DeletaUsuarioPorId(1)).Throws(new NullReferenceException());


        var result = _usersController.DeletaUsuarioPorId(1);


        Assert.NotNull(result);
        Assert.IsType<NotFoundObjectResult>(result.Result).StatusCode.Equals(404);
    }
}
