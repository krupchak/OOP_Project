using Zoo_EF.Models;

namespace Zoo_EF.Services
{
    public interface IZooService
    {
        Task<List<Animals>> GetAnimalsAsync(); // GET All Animals
        Task<Animals> GetAnimalsAsync(int id); // GET Single Animals
        Task<Animals> AddAnimalsAsync(Animals animals); // POST New Animals
        Task<Animals> UpdateAnimalsAsync(Animals animals); // PUT Animals
        Task<(bool, string)> DeleteAnimalsAsync(Animals animals); // DELETE Animals

        Task<List<Owners>> GetOwnersAsync(); // GET All Owners
        Task<Owners> GetOwnersAsync(int id); // Get Single Owners
        Task<Owners> AddOwnersAsync(Owners owners); // POST New Owners
        Task<Owners> UpdateOwnersAsync(Owners owners); // PUT Owners
        Task<(bool, string)> DeleteOwnersAsync(Owners owners); // DELETE Owners

        Task<List<AnimalTypes>> GetAnimalTypesAsync(); // GET All AnimalTypes
        Task<AnimalTypes> GetAnimalTypesAsync(int id); // Get Single AnimalTypes
        Task<AnimalTypes> AddAnimalTypesAsync(AnimalTypes owners); // POST New AnimalTypes
        Task<AnimalTypes> UpdateAnimalTypesAsync(AnimalTypes owners); // PUT AnimalTypes
        Task<(bool, string)> DeleteAnimalTypesAsync(AnimalTypes owners); // DELETE AnimalTypes
    }
}
