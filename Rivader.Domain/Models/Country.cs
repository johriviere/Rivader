namespace Rivader.Domain.Models
{
    public class Country
    {
        public string Code { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
    }
}
