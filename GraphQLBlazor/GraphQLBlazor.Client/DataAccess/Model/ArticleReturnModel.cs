namespace GraphQL.Client.DataAccess.Model
{
    public class ArticleReturnModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public int JournalNumber { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int FeeId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Fee Fee { get; set; }
    }
}
