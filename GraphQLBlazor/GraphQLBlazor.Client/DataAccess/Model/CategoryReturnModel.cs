using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Client.DataAccess.Model
{
    public class CategoryReturnModel
    {
            public int CategoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
        }
    }
