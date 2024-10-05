using System.ComponentModel.DataAnnotations;

namespace Desafio_BackEnd.Data.Models;

public class CreateUserDTO
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}
