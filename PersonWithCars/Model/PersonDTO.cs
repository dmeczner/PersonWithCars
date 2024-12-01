namespace PersonWithCars.Model
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime BirthDay { get; set; }

        public string PAddress { get; set; } = null!;
    }
}
