using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DatabaseInitializer
    {

        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            try
            {
                context.Database.EnsureCreated();
                await SeedLanguagesAsync(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<DatabaseInitializer>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        public static async Task SeedLanguagesAsync(ApplicationDbContext context)
        {
            var filePath = "Data\\languages.txt";
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    var language = new Language
                    {
                        Id = Guid.NewGuid(),
                        Name = parts[0],
                        LangCode = parts[1],
                        NativeName = parts[2],
                        IsCustom = false
                    };

                    if (!context.Languages.Any(l => l.Name == language.Name))
                    {
                        await context.Languages.AddAsync(language);
                    }
                }
                await context.SaveChangesAsync();
            }
            else
            {
                throw new FileNotFoundException($"The file at {filePath} was not found.");
            }
        }
    }
}