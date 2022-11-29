using Goalify.Models;
using Goalify.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goalify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalsRepository _goalsRepository;
        public GoalsController(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        // https://localhost:5001/api/goals/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_goalsRepository.GetAll());
        }

        // https://localhost:5001/api/beanvariety/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variety = _goalsRepository.Get(id);
            if (variety == null)
            {
                return NotFound();
            }
            return Ok(variety);
        }

        // https://localhost:5001/api/beanvariety/
        [HttpPost]
        public IActionResult Post(Goals goal)
        {
            _goalsRepository.Add(goal);
            return CreatedAtAction("Get", new { id = goal.Id }, goal);
        }

        // https://localhost:5001/api/beanvariety/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Goals goal)
        {
            if (id != goal.Id)
            {
                return BadRequest();
            }

            _goalsRepository.Update(goal);
            return NoContent();
        }

        // https://localhost:5001/api/beanvariety/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _goalsRepository.Delete(id);
            return NoContent();
        }
    }
}

