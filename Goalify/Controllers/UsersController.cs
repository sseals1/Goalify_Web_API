using Goalify.Models;
using Goalify.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goalify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository UsersRepository)
        {
            _usersRepository = UsersRepository;
        }

        // https://localhost:5001/api/users/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usersRepository.GetAll());
        }

        // https://localhost:5001/api/user/
        [HttpGet("{email}")]
        public IActionResult Get(Users email)
        {
            var user = _usersRepository.Get(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // https://localhost:5001/api/user/
        [HttpPost]
        public IActionResult Post(Users goal)
        {
            _usersRepository.Add(goal);
            return CreatedAtAction("Get", new { id = goal.Id }, goal);
        }

        // https://localhost:5001/api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Users goal)
        {
            if (id != goal.Id)
            {
                return BadRequest();
            }

            _usersRepository.Update(goal);
            return NoContent();
        }

        // https://localhost:5001/api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usersRepository.Delete(id);
            return NoContent();
        }
    }
}


