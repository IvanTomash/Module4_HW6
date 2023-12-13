using Homework_4_6.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Repositories;

internal class LocationRepository
{
    public ApplicationDbContext _dbContext;

    public LocationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(string name)
    {
        var location = new Location()
        {
            LocationName = name
        };

        _dbContext.Locations.Add(location);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Location> Get(int id)
    {
        var result = await _dbContext.Locations.FindAsync(id);

        return result!;
    }

    public async Task<int?> Update(int id, string name)
    {
        var location = await _dbContext.Locations.FindAsync(id);
        if (location != null)
        {
            location.LocationName = name;
            await _dbContext.SaveChangesAsync();
            return location.Id;
        }

        return null;
    }

    public async Task<int?> Delete(int id)
    {
        var location = await _dbContext.Locations.FindAsync(id);

        if (location != null)
        {
            var removingItem = _dbContext.Locations.Remove(location);

            await _dbContext.SaveChangesAsync();
            return removingItem.Entity.Id;
        }

        return null;
    }
}
