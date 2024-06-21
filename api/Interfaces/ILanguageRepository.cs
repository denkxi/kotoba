using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetAllAsync(LanguageQueryObject query);
        Task<Language> CreateAsync(Language languageModel);

    }
}