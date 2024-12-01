namespace PersonWithCars.DBHandling;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDay { get; set; }

    public string PAddress { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
