using GraphQL.DAO;
using GraphQL.Entity;
using HotChocolate.Subscriptions;

namespace GraphQL.Data
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor([Service] AuthorRepository authorRepository, [Service] ITopicEventSender eventSender,
            string firstName, string lastName, string email, string phone, int age, string? middleName = null)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Age = age,
                MiddleName = middleName
            };

            var createdAuthor = await authorRepository.CreateAuthor(author);
            await eventSender.SendAsync("AuthorCreated", createdAuthor);
            return createdAuthor;
        }

        public async Task<Article> CreateArticle([Service] ArticleRepository articleRepository,
            [Service] FeeRepository feeRepository, [Service] ITopicEventSender eventSender,
            string title, string content, DateTime publicationDate, int journalNumber,
            int authorId, int categoryId, int feeId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublicationDate = publicationDate,
                JournalNumber = journalNumber,
                AuthorId = authorId,
                CategoryId = categoryId,
                FeeId = feeId
            };

            var createdArticle = await articleRepository.CreateArticle(article);
            await eventSender.SendAsync("ArticleCreated", createdArticle);
            return createdArticle;
        }

        public async Task<Article> CreateArticleWithNewFee([Service] ArticleRepository articleRepository,
            [Service] FeeRepository feeRepository, [Service] ITopicEventSender eventSender,
            string title, string content, DateTime publicationDate, int journalNumber,
            int authorId, int categoryId, decimal feeAmount, DateTime paymentDate, string description)
        {
            var fee = new Fee
            {
                Amount = feeAmount,
                PaymentDate = paymentDate,
                Status = Fee.PaymentStatus.Pending,
                Description = description,
                AuthorId = authorId
            };

            var createdFee = await feeRepository.CreateFee(fee);

            var article = new Article
            {
                Title = title,
                Content = content,
                PublicationDate = publicationDate,
                JournalNumber = journalNumber,
                AuthorId = authorId,
                CategoryId = categoryId,
                FeeId = createdFee.FeeId
            };

            var createdArticle = await articleRepository.CreateArticle(article);
            await eventSender.SendAsync("ArticleWithFeeCreated", createdArticle);
            return createdArticle;
        }

        public async Task<Category> CreateCategory([Service] CategoryRepository categoryRepository,
            [Service] ITopicEventSender eventSender, string name, string description)
        {
            var category = new Category
            {
                Name = name,
                Description = description
            };

            var createdCategory = await categoryRepository.CreateCategory(category);
            await eventSender.SendAsync("CategoryCreated", createdCategory);
            return createdCategory;
        }

        public async Task<Fee> CreateFee([Service] FeeRepository feeRepository,
            [Service] ITopicEventSender eventSender, decimal amount, DateTime paymentDate,
            string status, string description, int authorId)
        {
            var fee = new Fee
            {
                Amount = amount,
                PaymentDate = paymentDate,
                Status = Enum.Parse<Fee.PaymentStatus>(status),
                Description = description,
                AuthorId = authorId
            };

            var createdFee = await feeRepository.CreateFee(fee);
            await eventSender.SendAsync("FeeCreated", createdFee);
            return createdFee;
        }

        public async Task<Author> UpdateAuthor([Service] AuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, int authorId, string firstName,
            string lastName, string email, string phone, int age, string? middleName = null)
        {
            var author = new Author
            {
                AuthorId = authorId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Age = age,
                MiddleName = middleName
            };

            var updatedAuthor = await authorRepository.UpdateAuthor(author);
            await eventSender.SendAsync("AuthorUpdated", updatedAuthor);
            return updatedAuthor;
        }

        public async Task<Article> UpdateArticle([Service] ArticleRepository articleRepository,
            [Service] ITopicEventSender eventSender, int articleId, string title,
            string content, DateTime publicationDate, int journalNumber,
            int authorId, int categoryId, int feeId)
        {
            var article = new Article
            {
                ArticleId = articleId,
                Title = title,
                Content = content,
                PublicationDate = publicationDate,
                JournalNumber = journalNumber,
                AuthorId = authorId,
                CategoryId = categoryId,
                FeeId = feeId
            };

            var updatedArticle = await articleRepository.UpdateArticle(article);
            await eventSender.SendAsync("ArticleUpdated", updatedArticle);
            return updatedArticle;
        }

        public async Task<bool> DeleteAuthor([Service] AuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, int authorId)
        {
            var result = await authorRepository.DeleteAuthor(authorId);
            await eventSender.SendAsync("AuthorDeleted", authorId);
            return result;
        }

        public async Task<bool> DeleteArticle([Service] ArticleRepository articleRepository,
            [Service] ITopicEventSender eventSender, int articleId)
        {
            var result = await articleRepository.DeleteArticle(articleId);
            await eventSender.SendAsync("ArticleDeleted", articleId);
            return result;
        }

        public async Task<Fee> UpdateFeeStatus([Service] FeeRepository feeRepository,
            [Service] ITopicEventSender eventSender, int feeId, string status)
        {
            var fee = await feeRepository.GetFeeById(feeId);
            if (fee == null) throw new Exception("Гонорар не найден");

            fee.Status = Enum.Parse<Fee.PaymentStatus>(status);
            var updatedFee = await feeRepository.UpdateFee(fee);
            await eventSender.SendAsync("FeeStatusUpdated", updatedFee);
            return updatedFee;
        }
    }
}