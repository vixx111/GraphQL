using GraphQL.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Entity
{
    public class Fee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeeId { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
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