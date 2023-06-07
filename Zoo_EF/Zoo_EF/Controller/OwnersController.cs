using Microsoft.AspNetCore.Mvc;
using Zoo_EF.Models;
using Zoo_EF.Services;

namespace Zoo_EF.Controllers
{
    [ApiController]
    [Route("api/Owners")]
    public class OwnersController : ControllerBase
    {
        private readonly IZooService _zooService;

        public OwnersController(IZooService zooService)
        {
            _zooService = zooService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _zooService.GetOwnersAsync();
            if (owners == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No Owners in database.");
            }

            return StatusCode(StatusCodes.Status200OK, owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwners(int id)
        {
            Owners owners = await _zooService.GetOwnersAsync(id);

            if (owners == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Owners found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, owners);
        }

        [HttpPost]
        public async Task<ActionResult<Owners>> AddOwners(Owners owners)
        {
            var dbOwners = await _zooService.AddOwnersAsync(owners);

            if (dbOwners == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{owners.Name} could not be added.");
            }

            return CreatedAtAction("GetOwners", new { id = owners.Id }, owners);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwners(int id, Owners owners)
        {
            if (id != owners.Id)
            {
                return BadRequest();
            }

            Owners dbOwners = await _zooService.UpdateOwnersAsync(owners);

            if (dbOwners == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{owners.Name} could not be updated");
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwners(int id)
        {
            var owners = await _zooService.GetOwnersAsync(id);
            (bool status, string message) = await _zooService.DeleteOwnersAsync(owners);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, owners);
        }
    }
}