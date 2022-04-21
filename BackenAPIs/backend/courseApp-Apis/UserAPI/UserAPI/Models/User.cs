using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserAPI.Models
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
