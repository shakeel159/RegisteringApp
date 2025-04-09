using System.ComponentModel.DataAnnotations;

namespace RegisteringApp.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int? PublicID { get; set; }

        public ID? _ID { get; set; }
    }

}
