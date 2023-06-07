using Microsoft.AspNetCore.Mvc;
using Zoo_EF.Models;
using Zoo_EF.Services;

namespace Zoo_EF.Controllers
{
    [ApiController]
    [Route("api/AnimalTypes")]
    public class AnimalTypesController : ControllerBase
    {
        private readonly IZooService _zooService;

        public AnimalTypesController(IZooService zooService)
        {
            _zooService = zooService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimalTypes()
        {
            var animalTypes = await _zooService.GetAnimalTypesAsync();
            if (animalTypes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No AnimalTypes in database.");
            }

            return StatusCode(StatusCodes.Status200OK, animalTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalTypes(int id)
        {
            AnimalTypes animalTypes = await _zooService.GetAnimalTypesAsync(id);

            if (animalTypes == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No AnimalTypes found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, animalTypes);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalTypes>> AddAnimalTypes(AnimalTypes animalTypes)
        {
            var dbAnimalTypes = await _zooService.AddAnimalTypesAsync(animalTypes);

            if (dbAnimalTypes == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{animalTypes.AnimalType} could not be added.");
            }

            return CreatedAtAction("GetAnimalTypes", new { id = animalTypes.Id }, animalTypes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimalTypes(int id, AnimalTypes animalTypes)
        {
            if (id != animalTypes.Id)
            {
                return BadRequest();
            }

            AnimalTypes dbAnimalTypes = await _zooService.UpdateAnimalTypesAsync(animalTypes);

            if (dbAnimalTypes == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{animalTypes.AnimalType} could not be updated");
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalTypes(int id)
        {
            var animalTypes = await _zooService.GetAnimalTypesAsync(id);
            (bool status, string message) = await _zooService.DeleteAnimalTypesAsync(animalTypes);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, animalTypes);
        }
    }
}