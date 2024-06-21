using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ApplicationDbContext _context;

        public LanguageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Language> CreateAsync(Language languageModel)
        {
            await _context.Languages.AddAsync(languageModel);
            await _context.SaveChangesAsync();
            return languageModel;
        }

        public async Task<List<Language>> GetAllAsync(LanguageQueryObject query)
        {
            var languages = _context.Languages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name)) {
                languages = languages.Where(l => l.Name.Contains(query.Name));
            }

            return await languages.ToListAsync();
        }
    }
}