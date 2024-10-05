using Desafio_BackEnd.Data.Models;
using Desafio_BackEnd.Model;
using DesafioBackEnd_Api.Data.Dtos;
using System.Collections.Generic;

namespace DesafioBackEnd_Api.Data.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> RetornaTodosUsuarios();
        public User RetornaUsuarioPorId(int id);
        public User AdicionaUsuario(CreateUserDTO user);
        public User AtualizaUsuario(int id, UpdateUserDTO user);
        public void DeletaUsuarioPorId(int id);
    }
}
