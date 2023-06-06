using DapperASPNetCore.Contracts;
using DapperASPNetCore.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperASPNetCore.Controllers
{
    [Route("api/volunteers")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        private readonly IVolunteersRepository _volunteersRepo;

        public VolunteersController(IVolunteersRepository volunteersRepo)
        {
            _volunteersRepo = volunteersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetVolunteers()
        {
            try
            {
                var volonteers = await _volunteersRepo.GetVolunteers();
                return Ok(volonteers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "VolunteersById")]
        public async Task<IActionResult> GetVolunteers(int id)
        {
            try
            {
                var volunteers = await _volunteersRepo.GetVolunteers(id);
                if (volunteers == null)
                    return NotFound();

                return Ok(volunteers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateVolunteer(VolunteersForCreationDto volunteers)
        {
            try
            {
                var createdVolunteer = await _volunteersRepo.CreateVolunteer(volunteers);
                return CreatedAtRoute("VolunteersById", new { id = createdVolunteer.Id }, createdVolunteer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVolunteers(int id, VolunteersForUpdateDto volunteers)
        {
            try
            {
                var dbVolunteers = await _volunteersRepo.GetVolunteers(id);
                if (dbVolunteers == null)
                    return NotFound();

                await _volunteersRepo.UpdateVolunteers(id, volunteers);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVolunteers(int id)
        {
            try
            {
                var dbVolunteers = await _volunteersRepo.GetVolunteers(id);
                if (dbVolunteers == null)
                    return NotFound();

                await _volunteersRepo.DeleteVolunteers(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ByVolunteersDepartmentId/{id}")]
        public async Task<IActionResult> GetVolunteersForDepartment(int id)
        {
            try
            {
                var volunteers = await _volunteersRepo.GetVolunteersByDepartmentId(id);
                if (volunteers == null)
                    return NotFound();

                return Ok(volunteers);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
