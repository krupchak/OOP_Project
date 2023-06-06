using Dapper;
using DapperASPNetCore.Context;
using DapperASPNetCore.Contracts;
using DapperASPNetCore.Dto;
using DapperASPNetCore.Entities;
using System.Data;

namespace DapperASPNetCore.Repository
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly ZooContext _context;
        public VolunteersRepository(ZooContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Volunteers>> GetVolunteers()
        {
            var query = "SELECT * FROM Volunteers";

            using (var connection = _context.CreateConnection())
            {
                var compnies = await connection.QueryAsync<Volunteers>(query);
                return compnies.ToList();
            }
        }

        public async Task<Volunteers> GetVolunteers(int id)
        {
            var query = "SELECT * FROM Volunteers WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var volunteers = await connection.QuerySingleOrDefaultAsync<Volunteers>(query, new { id });
                return volunteers;
            }
        }

        public async Task<Volunteers> CreateVolunteer(VolunteersForCreationDto volunteers)
        {
            var query = "INSERT INTO Volunteers ( Name, PhoneNumber, Address, AnimalId, DepartmentId) VALUES (@Name, @PhoneNumber, @Address, @AnimalId, @DepartmentId)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", volunteers.Name, DbType.String);
            parameters.Add("PhoneNumber", volunteers.PhoneNumber, DbType.String);
            parameters.Add("Address", volunteers.Address, DbType.String);
            parameters.Add("AnimalId", volunteers.AnimalId, DbType.Int32);
            parameters.Add("DepartmentId", volunteers.DepartmentId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdVolunteer = new Volunteers
                {
                    Id = id,
                    Name = volunteers.Name,
                    PhoneNumber = volunteers.PhoneNumber,
                    Address = volunteers.Address,
                    AnimalId = volunteers.AnimalId,
                    DepartmentId = volunteers.DepartmentId
                };

                return createdVolunteer;
            }
        }

        public async Task UpdateVolunteers(int id, VolunteersForUpdateDto volunteers)
        {
            var query = "UPDATE Volunteers SET Name = @Name, PhoneNumber = @PhoneNumber, Address = @Address, AnimalId = @AnimalId, DepartmentId = DepartmentId WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", volunteers.Name, DbType.String);
            parameters.Add("PhoneNumber", volunteers.PhoneNumber, DbType.String);
            parameters.Add("Address", volunteers.Address, DbType.String);
            parameters.Add("AnimalId", volunteers.AnimalId, DbType.Int32);
            parameters.Add("DepartmentId", volunteers.DepartmentId, DbType.Int32);

            using (var connetion = _context.CreateConnection())
            {
                await connetion.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteVolunteers(int id)
        {
            var query = "DELETE FROM Volunteers WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Volunteers> GetVolunteersByDepartmentId(int id)
        {
            var procedureName = "ShowVolunteersByVolunteersDepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
            {
                var volunteers = await connection.QueryFirstOrDefaultAsync<Volunteers>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);

                return volunteers;
            }
        }
    }
}
