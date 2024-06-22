using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllAsync(LanguageQueryObject query);
        Task<Language?> GetByIdAsync(Guid id);
        Task<Language> CreateAsync(Language languageModel);

    }
}