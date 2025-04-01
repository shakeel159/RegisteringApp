namespace RegisteringApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int? PublicID { get; set; }

        public ID? _ID { get; set; }
    }
}
