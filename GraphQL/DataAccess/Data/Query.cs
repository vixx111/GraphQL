using GraphQL.DAO;
using GraphQL.Entity;
using HotChocolate.Subscriptions;

namespace GraphQL.Data
{
    public class Query
    {
        public List<Author> GetAllAuthors([Service] AuthorRepository authorRepository) =>
            authorRepository.GetAllAuthors();

        public List<Article> GetArticlesByJournalNumber([Service] ArticleRepository articleRepository, int journalNumber) =>
            articleRepository.GetArticlesByJournalNumber(journalNumber);

        public decimal CalculateHonorariumForJournal([Service] FeeRepository feeRepository, int journalNumber) =>
            feeRepository.CalculateHonorariumForJournal(journalNumber);

        public async Task<Author> GetAuthorInfo([Service] AuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, int authorId)
        {
            var author = authorRepository.GetAuthorById(authorId);
            await eventSender.SendAsync("ReturnedAuthorInfo", author);
            return author;
        }

        public List<Article> GetAuthorArticles([Service] ArticleRepository articleRepository, int authorId) =>
            articleRepository.GetArticlesByAuthor(authorId);

        public List<decimal> GetAuthorFeesPerArticle([Service] FeeRepository feeRepository, int authorId) =>
            feeRepository.GetAuthorFeesPerArticle(authorId);

        public List<Article> GetArticlesByCategory([Service] ArticleRepository articleRepository, int categoryId) =>
            articleRepository.GetArticlesByCategory(categoryId);

        public List<Category> GetAllCategories([Service] CategoryRepository categoryRepository) =>
            categoryRepository.GetAllCategories();

        public decimal CalculateHonorariumForCategory([Service] FeeRepository feeRepository,
            int categoryId, DateTime startDate, DateTime endDate) =>
            feeRepository.CalculateHonorariumForCategory(categoryId, startDate, endDate);

        public decimal CalculateAuthorTotalHonorarium([Service] FeeRepository feeRepository, int authorId) =>
            feeRepository.CalculateAuthorTotalHonorarium(authorId);

        public List<int> GetAllJournalNumbers([Service] ArticleRepository articleRepository)
        {
            return articleRepository.GetAllArticles()
                .Select(a => a.JournalNumber)
                .Distinct()
                .OrderBy(n => n)
                .ToList();
        }


        public List<Article> GetAllArticles([Service] ArticleRepository articleRepository) =>
            articleRepository.GetAllArticles();

        public List<Fee> GetAllFees([Service] FeeRepository feeRepository) =>
            feeRepository.GetAllFees();
    }
}