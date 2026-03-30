using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Client.DataAccess.Model
{
    public class AuthorReturnModel
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
        public virtual ICollection<Fee> Fees { get; set; } = new List<Fee>();
    }
}
