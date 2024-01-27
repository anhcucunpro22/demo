using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TH.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        public string? FullName { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string CodeUser { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public int? OrganizationID { get; set; }

        public bool Isactive { get; set; }

        public ICollection<Debt> Debts { get; set; } = new List<Debt>();


    }
}
