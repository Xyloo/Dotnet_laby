using System.Runtime.CompilerServices;
using Lab8.Data;
using Lab8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    [Route("api/fox")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private readonly IFoxesRepository _foxesRepository;

        public FoxController(IFoxesRepository foxesRepository)
        {
            _foxesRepository = foxesRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_foxesRepository.GetAll().OrderByDescending(f => f.Loves).ThenBy(f => f.Hates));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fox = _foxesRepository.Get(id);
            return fox == null ? NotFound() : Ok(fox);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] Fox f)
        {
            _foxesRepository.Add(f);
            return CreatedAtAction(nameof(Get), new { id = f.Id }, f);
        }

        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            var fox = _foxesRepository.IncrementLoves(id);
            return fox is null ? NotFound() : Ok(fox);
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            var fox = _foxesRepository.IncrementHates(id);
            
            return fox is null ? NotFound() : Ok(fox);
        }
    }
}
