namespace GraphQL.Client.DataAccess.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Article>? Articles { get; set; } = new List<Article>();
        public override string ToString()
        {
            return $"CategoryId: {CategoryId},\n" +
                   $"Name: {Name},\n" +
                   $"Description: {Description},\n" +
                   $"Articles Count: {Articles?.Count ?? 0}";
        }
    }
}
