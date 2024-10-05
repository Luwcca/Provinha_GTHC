using Desafio_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_BackEnd.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {     
    }

    public DbSet<User> Users { get; set; }

}
