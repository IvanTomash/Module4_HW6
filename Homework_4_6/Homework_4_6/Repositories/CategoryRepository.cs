using Homework_4_6.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Repositories;

internal class CategoryRepository
{
    public ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(string name)
    {
        var category = new Category()
        {
            CategoryName = name
        };

        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Category> Get(int id)
    {
        var result = await _dbContext.Categories.FindAsync(id);

        return result!;
    }

    public async Task<int?> Update(int id, string name)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        if (category != null)
        {
            category.CategoryName = name;
            await _dbContext.SaveChangesAsync();
            return category.Id;
        }

        return null;
    }

    public async Task<int?> Delete(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);

        if (category != null)
        {
            var removingItem = _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
            return removingItem.Entity.Id;
        }

        return null;
    }
}
