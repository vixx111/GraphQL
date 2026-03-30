namespace GraphQL.Client.DataAccess.Model
{
        public class Author
        {
            public int AuthorId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? MiddleName { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public int Age { get; set; }
            public virtual ICollection<Article>? Articles { get; set; } = new List<Article>();
            public virtual ICollection<Fee>? Fees { get; set; } = new List<Fee>();

            public override string ToString()
            {
                return $"AuthorId: {AuthorId},\n" +
                       $"FirstName: {FirstName},\n" +
                       $"LastName: {LastName},\n" +
                       $"MiddleName: {MiddleName ?? "null"},\n" +
                       $"Email: {Email},\n" +
                       $"Phone: {Phone},\n" +
                       $"Age: {Age},\n" +
                       $"Articles Count: {Articles?.Count ?? 0},\n" +
                       $"Fees Count: {Fees?.Count ?? 0}";
            }
        }
    }
