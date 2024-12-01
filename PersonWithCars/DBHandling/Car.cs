namespace PersonWithCars.DBHandling;

public partial class Car
{
    public int Id { get; set; }

    public string CardBrand { get; set; } = null!;

    public string LicensePlate { get; set; } = null!;

    public int? PersonId { get; set; }

    public virtual Person? Person { get; set; }
}
