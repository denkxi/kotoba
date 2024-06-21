
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Dictionaries")]
    public class Dictionary
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid TargetLanguageId { get; set; }
        public Language? TargetLanguage { get; set; }

        public Guid SourceLanguageId { get; set; }
        public Language? SourceLanguage { get; set; }
    }
}