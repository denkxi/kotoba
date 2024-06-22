
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Languages")]
    public class Language
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LangCode { get; set; } = string.Empty;

        public string NativeName { get; set; } = string.Empty;
        public bool IsCustom { get; set; } = true;

        public Guid CreatedBy { get; set; } = Guid.Empty;

        public List<Dictionary>? SourceDictionaries { get; set; }
        public List<Dictionary>? TargetDictionaries { get; set; } 
    }
}