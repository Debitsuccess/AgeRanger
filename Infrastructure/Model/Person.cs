using Infrastructure.ModelConfiguration;

namespace Infrastructure.Model
{
    /// <seealso cref="PersonConfiguration" />
    public class Person
    {
        public int Id { get; set; } //Primary key

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int AgeGroupId { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }
    }
}
