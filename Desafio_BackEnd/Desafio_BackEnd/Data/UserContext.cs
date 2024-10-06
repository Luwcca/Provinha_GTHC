using Desafio_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_BackEnd.Data;

public class UserContext : DbContext
{
    //Config do contex para manipulação do banco a partir do EF
    public UserContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {     
    }

    //Manipulação da tabela de Users
    public DbSet<User> Users { get; set; }

}
