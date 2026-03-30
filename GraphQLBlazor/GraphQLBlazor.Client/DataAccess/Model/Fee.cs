namespace GraphQL.Client.DataAccess.Model
{
    public class Fee
    {
        public int FeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public virtual ICollection<Article>? Articles { get; set; } = new List<Article>();

        public enum PaymentStatus
        {
            Pending,
            Paid,
            Cancelled
        }
        public override string ToString()
        {
            return $"FeeId: {FeeId},\n" +
                   $"Amount: {Amount},\n" +
                   $"PaymentDate: {PaymentDate},\n" +
                   $"Status: {Status},\n" +
                   $"Description: {Description ?? "null"},\n" +
                   $"AuthorId: {AuthorId},\n" +
                   $"Author: {Author?.ToString() ?? "null"},\n" +
                   $"Articles Count: {Articles?.Count ?? 0}";
        }
    }
}
