using Faker;
using GraphQL.Entity;
using GraphQL.DAO;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data
{
    public static class DataSeeder
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Authors.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var author = new Author
                    {
                        FirstName = Name.First(),
                        LastName = Name.Last(),
                        MiddleName = Name.Prefix(),
                        Email = Internet.Email(),
                        Phone = Phone.Number(),
                        Age = new Random().Next(25, 65)
                    };
                    context.Authors.Add(author);
                }
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categoryNames = new[]
                {
                    "Наука", "Технологии", "Культура", "Политика",
                    "Экономика", "Спорт", "Здоровье", "Образование"
                };

                foreach (var categoryName in categoryNames)
                {
                    var category = new Category
                    {
                        Name = categoryName,
                        Description = Lorem.Sentence()
                    };
                    context.Categories.Add(category);
                }
                context.SaveChanges();
            }

            var authors = context.Authors.ToList();
            var categories = context.Categories.ToList();
            var journalNumbers = new[] { 1, 2, 3, 4, 5, 6 };

            if (!context.Fees.Any())
            {
                foreach (var author in authors)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var fee = new Fee
                        {
                            Amount = new Random().Next(5000, 30000),
                            PaymentDate = DateTime.Now.AddDays(-new Random().Next(1, 365)),
                            Status = Fee.PaymentStatus.Paid,
                            Description = Lorem.Sentence(),
                            AuthorId = author.AuthorId
                        };
                        context.Fees.Add(fee);
                    }
                }
                context.SaveChanges();
            }

            var fees = context.Fees.ToList();
            int feeIndex = 0;

            if (!context.Articles.Any())
            {
                foreach (var journalNumber in journalNumbers)
                {
                    foreach (var author in authors)
                    {
                        var article = new Article
                        {
                            Title = Lorem.Sentence(),
                            Content = Lorem.Paragraph(),
                            PublicationDate = DateTime.Now.AddDays(-new Random().Next(1, 365)),
                            JournalNumber = journalNumber,
                            AuthorId = author.AuthorId,
                            CategoryId = categories[new Random().Next(categories.Count)].CategoryId,
                            FeeId = fees[feeIndex % fees.Count].FeeId
                        };
                        context.Articles.Add(article);
                        feeIndex++;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}