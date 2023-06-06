using DapperASPNetCore.Entities;
using DapperASPNetCore.Dto;

namespace DapperASPNetCore.Contracts
{
    public interface IVolunteersRepository
    {
        public Task<IEnumerable<Volunteers>> GetVolunteers();
        public Task<Volunteers> GetVolunteers(int id);
        public Task<Volunteers> CreateVolunteer(VolunteersForCreationDto volunteers);
        public Task UpdateVolunteers(int id, VolunteersForUpdateDto volunteers);
        public Task DeleteVolunteers( int id );
        public Task<Volunteers> GetVolunteersByDepartmentId( int id );
    }
}
