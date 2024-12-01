namespace PersonWithCars.Model
{
    public class CarDTO
    {
        public int Id { get; set; }

        public string CarBrand { get; set; } = null!;

        public string LicensePlate { get; set; } = null!;

        public int? PersonId { get; set; }
    }
}
