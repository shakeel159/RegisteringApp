using System.ComponentModel.DataAnnotations.Schema;

namespace RegisteringApp.Models
{
    public class ID
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;

        public int? ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client? client { get; set; }

    }
}