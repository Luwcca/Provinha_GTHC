using System.ComponentModel.DataAnnotations;

namespace DesafioBackEnd_Api.Data.Dtos;

public class UpdateUserDTO
{
    public string? Name { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}
