using Desafio_BackEnd.Model;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_BackEnd.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly List<Aluno> alunos;

    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
        alunos = new List<Aluno>
        {
            new Aluno { Id = 1, Nome = "Jefferson", Email = "jefferson@gmail.com"},
            new Aluno { Id = 2, Nome = "Jefferson", Email = "jefferson@gmail.com"}
        };

    }

    [HttpGet("RetornaTodosAlunos")]
    public ActionResult<IEnumerable<Aluno>> RetornaTodosAlunos()
    {
        return Ok(alunos);
    }
}
