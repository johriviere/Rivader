namespace Rivader.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int TranslationId { get; set; }
        public Translation Translation { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
    }
}
