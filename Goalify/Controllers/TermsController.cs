using Goalify.Models;
using Goalify.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goalify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsController : ControllerBase
    {
        private readonly ITermsRepository _termsRepository;
        public TermsController(ITermsRepository TermsRepository)
        {
            _termsRepository = TermsRepository;
        }

        // https://localhost:5001/api/terms/
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_termsRepository.GetAll());
        }
    }
}
