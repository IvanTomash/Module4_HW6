using Homework_4_6.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Repositories;

internal class BreedRepository
{
    public ApplicationDbContext _dbContext;

    public BreedRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(string name, int categoryId)
    {
        var breed = new Breed()
        {
            BreedName = name,
            CategoryId = categoryId
        };

        _dbContext.Breeds.Add(breed);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Breed> Get(int id)
    {
        var result = await _dbContext.Breeds.FindAsync(id);

        return result!;
    }

    public async Task<int?> Update(int id, string name, int categoryId)
    {
        var breed = await _dbContext.Breeds.FindAsync(id);
        if (breed != null)
        {
            breed.BreedName = name;
            breed.CategoryId = categoryId;
            await _dbContext.SaveChangesAsync();
            return breed.Id;
        }

        return null;
    }

    public async Task<int?> Delete(int id)
    {
        var breed = await _dbContext.Breeds.FindAsync(id);

        if (breed != null)
        {
            var removingItem = _dbContext.Breeds.Remove(breed);

            await _dbContext.SaveChangesAsync();
            return removingItem.Entity.Id;
        }

        return null;
    }
}
