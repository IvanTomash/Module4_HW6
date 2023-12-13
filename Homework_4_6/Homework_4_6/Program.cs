using Homework_4_6.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json;

namespace Homework_4_6;

internal class Program
{
    public static void Main(string[] args)
    {
        var dbContext = new ApplicationDbContext();
        var petRepository = new PetRepository(dbContext);
        petRepository.Add("twelve", 1, 1, 10, 3, "image12", "description12").Wait();
        petRepository.Update(12, "twenty", 2, 4, 1, 2, "im", "desc").Wait();
        Console.WriteLine(JsonSerializer.Serialize(petRepository.Get(12).Result));
        petRepository.Delete(12).Wait();
        var result = dbContext.Pets
            .Include(s => s.Category)
            .Include(s => s.Breed)
            .Include(s => s.Location)
            .Where(s => s.Age >= 3 && s.Location.LocationName == "Ukraine")
            .GroupBy(s => s.Category.CategoryName)
            .Select(s => new
            {
                CategoryName = s.Key,
                UniqueBreedCount = s.Select(p => p.Breed.BreedName).Distinct().Count()
            }).ToList();
        Console.WriteLine(JsonSerializer.Serialize(result));
    }

    public static async Task InitializeDb()
    {
        var dbContext = new ApplicationDbContext();
        var locationRepository = new LocationRepository(dbContext);
        var categoryRepository = new CategoryRepository(dbContext);
        var breedRepository = new BreedRepository(dbContext);
        var petRepository = new PetRepository(dbContext);
        await locationRepository.Add("Ukraine");
        await locationRepository.Add("USA");
        await locationRepository.Add("France");

        await categoryRepository.Add("Terrier");
        await categoryRepository.Add("Working");
        await categoryRepository.Add("Sporting");

        await breedRepository.Add("Australian Terrier", 1);
        await breedRepository.Add("Border Terrier", 1);
        await breedRepository.Add("Cane Corso", 2);
        await breedRepository.Add("Alaskan Malamute", 2);
        await breedRepository.Add("American Water Spaniel", 3);
        await breedRepository.Add("Barbet", 3);

        await petRepository.Add("One", 1, 2, 3, 1, "iamge1", "description1");
        await petRepository.Add("Two", 1, 1, 1, 2, "iamge2", "description2");
        await petRepository.Add("Three", 2, 3, 3, 3, "iamge3", "description3");
        await petRepository.Add("Four", 2, 4, 1, 1, "iamge4", "description4");
        await petRepository.Add("Five", 3, 5, 3, 1, "iamge5", "description5");
        await petRepository.Add("Six", 3, 6, 9, 3, "iamge6", "description6");
        await petRepository.Add("Seven", 1, 1, 5, 3, "iamge7", "description7");
        await petRepository.Add("Eight", 1, 2, 3, 2, "iamge8", "description8");
        await petRepository.Add("Nine", 3, 5, 3, 1, "iamge9", "description9");
        await petRepository.Add("Ten", 2, 4, 3, 2, "iamge10", "description10");
        await petRepository.Add("Eleven", 2, 3, 3, 2, "iamge11", "description11");
    }
}