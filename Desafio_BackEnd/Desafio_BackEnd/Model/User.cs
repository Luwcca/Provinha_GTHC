using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio_BackEnd.Model;


//Adição de index no Email para configurar o IsUnique
[Index(nameof(Email), IsUnique = true)]
public class User
{
    //Data annotatios para facilitar a migration do EF
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [EmailAddress]
    public string Email { get; set; }
}
