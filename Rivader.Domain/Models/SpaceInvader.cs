namespace Rivader.Domain.Models
{
    public class SpaceInvader
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        //public int? CityId { get; set; }
        //public City City { get; set; }
    }
}
