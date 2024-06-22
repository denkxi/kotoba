using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IDictionaryRepository
    {
        Task<List<Dictionary>> GetAllAsync(DictionaryQueryObject query);
        Task<Dictionary?> GetByIdAsync(Guid id);
        Task<Dictionary> CreateAsync(Dictionary dictionaryModel);
    }
}