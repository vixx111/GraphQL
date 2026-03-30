using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Client.DataAccess.Model
{
    public class FeeReturnModel
    {
        public int FeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
        public enum PaymentStatus
        {
            Pending,
            Paid,
            Cancelled
        }
    }
}

