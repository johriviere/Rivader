namespace Rivader.Domain.Models
{
    public class CulturedLabel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Lcid { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
    }
}
