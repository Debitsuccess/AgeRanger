namespace AgeRanger.DTO
{
    public class PersonViewModel
    {
        public int Id { get; set; } //Primary key

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string AgeGroup { get; set; }
    }
}
