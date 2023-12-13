using Homework_4_6.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Repositories;

internal class PetRepository
{
    public ApplicationDbContext _dbContext;

    public PetRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(string name, int categoryId, int breedId, float age, int locationId, string imageUrl, string description)
    {
        var pet = new Pet()
        {
            Name = name,
            CategoryId = categoryId,
            BreedId = breedId,
            Age = age,
            LocationId = locationId,
            ImageUrl = imageUrl,
            Description = description
        };

        _dbContext.Pets.Add(pet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Pet> Get(int id)
    {
        var result = await _dbContext.Pets.FindAsync(id);

        return result!;
    }

    public async Task<int?> Update(int id, string name, int categoryId, int breedId, float age, int locationId, string imageUrl, string description)
    {
        var pet = await _dbContext.Pets.FindAsync(id);
        if (pet != null)
        {
            pet.Name = name;
            pet.CategoryId = categoryId;
            pet.BreedId = breedId;
            pet.Age = age;
            pet.LocationId = locationId;
            pet.ImageUrl = imageUrl;
            pet.Description = description;
            await _dbContext.SaveChangesAsync();
            return pet.Id;
        }

        return null;
    }

    public async Task<int?> Delete(int id)
    {
        var pet = await _dbContext.Pets.FindAsync(id);

        if (pet != null)
        {
            var removingItem = _dbContext.Pets.Remove(pet);

            await _dbContext.SaveChangesAsync();
            return removingItem.Entity.Id;
        }

        return null;
    }
}
