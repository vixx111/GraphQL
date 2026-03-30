using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Client.DataAccess.Model
{
        public class Article
        {
            public int ArticleId { get; set; }
            public string? Title { get; set; }
            public string? Content { get; set; }
            public DateTime PublicationDate { get; set; }
            public int JournalNumber { get; set; }
            public int AuthorId { get; set; }
            public int CategoryId { get; set; }
            public int FeeId { get; set; }
            public virtual Author? Author { get; set; }
            public virtual Category? Category { get; set; }
            public virtual Fee? Fee { get; set; }

            public override string ToString()
            {
                return $"ArticleId: {ArticleId},\n" +
                       $"Title: {Title},\n" +
                       $"Content: {Content},\n" +
                       $"PublicationDate: {PublicationDate},\n" +
                       $"JournalNumber: {JournalNumber},\n" +
                       $"AuthorId: {AuthorId},\n" +
                       $"CategoryId: {CategoryId},\n" +
                       $"FeeId: {FeeId},\n" +
                       $"Author: {Author?.ToString() ?? "null"},\n" +
                       $"Category: {Category?.ToString() ?? "null"},\n" +
                       $"Fee: {Fee?.ToString() ?? "null"}";
            }
        }
    }
