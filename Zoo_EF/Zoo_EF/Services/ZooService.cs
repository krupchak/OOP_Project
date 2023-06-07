using Microsoft.EntityFrameworkCore;
using Zoo_EF.Data;
using Zoo_EF.Models;

namespace Zoo_EF.Services
{
    public class ZooService : IZooService
    {
        private readonly ZooContext _db;

        public ZooService(ZooContext db)
        {
            _db = db;
        }

        #region Animals

        public async Task<List<Animals>> GetAnimalsAsync()
        {
            try
            {
                return await _db.Animals.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Animals> GetAnimalsAsync(int id)
        {
            try
            {
                return await _db.Animals.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Animals> AddAnimalsAsync(Animals animals)
        {
            try
            {
                await _db.Animals.AddAsync(animals);
                await _db.SaveChangesAsync();
                return await _db.Animals.FindAsync(animals.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Animals> UpdateAnimalsAsync(Animals animals)
        {
            try
            {
                _db.Entry(animals).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return animals;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteAnimalsAsync(Animals animals)
        {
            try
            {
                var dbAnimals = await _db.Animals.FindAsync(animals.Id);

                if (dbAnimals == null)
                {
                    return (false, "Animals could not be found");
                }

                _db.Animals.Remove(animals);
                await _db.SaveChangesAsync();

                return (true, "Animals got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Animals

        #region Owners

        public async Task<List<Owners>> GetOwnersAsync()
        {
            try
            {
                return await _db.Owners.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Owners> GetOwnersAsync(int id)
        {
            try
            {
                return await _db.Owners.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Owners> AddOwnersAsync(Owners owners)
        {
            try
            {
                await _db.Owners.AddAsync(owners);
                await _db.SaveChangesAsync();
                return await _db.Owners.FindAsync(owners.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Owners> UpdateOwnersAsync(Owners owners)
        {
            try
            {
                _db.Entry(owners).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return owners;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteOwnersAsync(Owners owners)
        {
            try
            {
                var dbOwners = await _db.Owners.FindAsync(owners.Id);

                if (dbOwners == null)
                {
                    return (false, "Owners could not be found.");
                }

                _db.Owners.Remove(owners);
                await _db.SaveChangesAsync();

                return (true, "Owners got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Owners

        #region AnimalTypes

        public async Task<List<AnimalTypes>> GetAnimalTypesAsync()
        {
            try
            {
                return await _db.AnimalTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AnimalTypes> GetAnimalTypesAsync(int id)
        {
            try
            {
                return await _db.AnimalTypes.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AnimalTypes> AddAnimalTypesAsync(AnimalTypes animalTypes)
        {
            try
            {
                await _db.AnimalTypes.AddAsync(animalTypes);
                await _db.SaveChangesAsync();
                return await _db.AnimalTypes.FindAsync(animalTypes.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<AnimalTypes> UpdateAnimalTypesAsync(AnimalTypes animalTypes)
        {
            try
            {
                _db.Entry(animalTypes).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return animalTypes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteAnimalTypesAsync(AnimalTypes animalTypes)
        {
            try
            {
                var dbAnimalTypes = await _db.AnimalTypes.FindAsync(animalTypes.Id);

                if (dbAnimalTypes == null)
                {
                    return (false, "AnimalTypes could not be found.");
                }

                _db.AnimalTypes.Remove(animalTypes);
                await _db.SaveChangesAsync();

                return (true, "AnimalTypes got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion AnimalTypes
    }
}