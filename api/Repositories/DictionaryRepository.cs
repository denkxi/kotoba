using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private readonly ApplicationDbContext _context;

        public DictionaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Dictionary> CreateAsync(Dictionary dictionaryModel)
        {
            await _context.Dictionaries.AddAsync(dictionaryModel);
            await _context.SaveChangesAsync();

            
            return await _context.Dictionaries
                .Include(d => d.SourceLanguage)
                .Include(d => d.TargetLanguage)
                .SingleAsync(d => d.Id == dictionaryModel.Id);
        }

        public async Task<List<Dictionary>> GetAllAsync(DictionaryQueryObject query)
        {
            var dictionaries = _context.Dictionaries
            .Include(d => d.SourceLanguage)
            .Include(d => d.TargetLanguage)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                dictionaries = dictionaries.Where(l => l.Name.Contains(query.Name));
            }

            return await dictionaries.ToListAsync();
        }

        public async Task<Dictionary?> GetByIdAsync(Guid id)
        {
            return await _context.Dictionaries
            .Include(d => d.SourceLanguage)
            .Include(d => d.TargetLanguage)
            .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}