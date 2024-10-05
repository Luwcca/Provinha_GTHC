using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio_BackEnd.Model;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [EmailAddress]
    public string Email { get; set; }
}
