using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shiiiit.Models;
using shiiiit.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/Users")]
    [ApiController]
    //api/Users или api/Users/1
    public class UsersController 
    {

        private readonly IRepository _repo;

        public UsersController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            return await _repo.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetUser(Guid id)
        {
            return await _repo.GetUser(id);
        }

        [HttpPut("{id}")]
        public async Task PutUser(User user, Guid id)
        { 
            await _repo.UpdateUser(id, user);
            return;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _repo.CreateUser(user);
            return user;
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(Guid id)
        {
            await _repo.DeleteUser(id);
            return;
        }
    }
}
