using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Language;
using api.Models;

namespace api.Mappers
{
    public static class LanguageMappers
    {
        public static LanguageDto ToLanguageDto(this Language languageModel)
        {
            return new LanguageDto
            {
                Id = languageModel.Id,
                Name = languageModel.Name,
                LangCode = languageModel.LangCode,
                NativeName = languageModel.NativeName
            };
        }
    }
}