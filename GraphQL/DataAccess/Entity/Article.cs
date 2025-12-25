using GraphQL.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Entity
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        [Range(1, 1000)]
        public int JournalNumber { get; set; }

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int FeeId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("FeeId")]
        public virtual Fee Fee { get; set; }
    }
}