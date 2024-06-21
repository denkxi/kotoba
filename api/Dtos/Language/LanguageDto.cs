using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Language
{
    public class LanguageDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LangCode { get; set; } = string.Empty;

        public string NativeName { get; set; } = string.Empty;
        public bool IsCustom { get; set; }

        // public List<Dictionary>? Dictionaries { get; set; }
    }
}