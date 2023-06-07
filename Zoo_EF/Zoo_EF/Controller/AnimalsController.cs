using Microsoft.AspNetCore.Mvc;
using Zoo_EF.Models;
using Zoo_EF.Services;

namespace Zoo_EF.Controllers
{
    [ApiController]
    [Route("api/Animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IZooService _zooService;

        public AnimalsController(IZooService zooService)
        {
            _zooService = zooService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            var animals = await _zooService.GetAnimalsAsync();

            if (animals == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No animals in database");
            }

            return StatusCode(StatusCodes.Status200OK, animals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimals(int id)
        {
            Animals animals = await _zooService.GetAnimalsAsync(id);

            if (animals == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Animal found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, animals);
        }

        [HttpPost]
        public async Task<ActionResult<Animals>> AddAnimals(Animals animals)
        {
            var dbAnimals = await _zooService.AddAnimalsAsync(animals);

            if (dbAnimals == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{animals.Name} could not be added.");
            }

            return CreatedAtAction("GetAnimals", new { id = animals.Id }, animals);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimals(int id, Animals animals)
        {
            if (id != animals.Id)
            {
                return BadRequest();
            }

            Animals dbAnimals = await _zooService.UpdateAnimalsAsync(animals);

            if (dbAnimals == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{animals.Name} could not be updated");
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimals(int id)
        {
            var animals = await _zooService.GetAnimalsAsync(id);
            (bool status, string message) = await _zooService.DeleteAnimalsAsync(animals);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, animals);
        }
    }
}