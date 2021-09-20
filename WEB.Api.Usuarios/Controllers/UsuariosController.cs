using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Api.Usuarios.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB.Api.Usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private static List<UsersDTO> Listusers;
        private static int idUser;
        private static bool start;

        /// <summary>
        /// onsultar usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public UsersDTO Get(int id)
        {
            try
            {
                var idx = Listusers.Cast<UsersDTO>().SingleOrDefault(exp => exp.id == id);
                if (idx != null)
                    return idx;
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        /// <summary>
        /// Adcionar Novo usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="nome"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UsersDTO newUser)
        {
            if (!start)
            {
                Listusers = new List<UsersDTO>();
                start = true;
            }

            idUser++;
            var user = new UsersDTO
            {
                id = idUser,
                Email = newUser.Email,
                Nome = newUser.Nome,
                Senha = newUser.Senha
            };
            Listusers.Add(user);

            return Ok("usuário inserido com sucesso.");
        }

        /// <summary>
        /// Alterar usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, UsersDTO user)
        {
            //Remover do Array
            RemoveFromArray(id);

            //Insere novo User
            user.id = id;
            Listusers.Add(user);
            return Ok("Alteração com sucesso.");
        }

        /// <summary>
        /// Removendo usuario por ID
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            RemoveFromArray(id);
            return Ok("Usuario removido com sucesso.");
        }

        public async void RemoveFromArray(int id)
        {
            var idx = Listusers.Cast<UsersDTO>().SingleOrDefault(exp => exp.id == id);
            if (idx != null)
                Listusers.Remove(idx);
        }
    }
}
