using GraphQL.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQL.Data
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Author>("AuthorCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorUpdated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Author>("AuthorUpdated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<int>> OnAuthorDeleted([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<int>("AuthorDeleted", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Author>> OnAuthorInfoReturned([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Author>("ReturnedAuthorInfo", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Article>> OnArticleCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Article>("ArticleCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Article>> OnArticleWithFeeCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Article>("ArticleWithFeeCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Article>> OnArticleUpdated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Article>("ArticleUpdated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<int>> OnArticleDeleted([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<int>("ArticleDeleted", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Category>> OnCategoryCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Category>("CategoryCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Fee>> OnFeeCreated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Fee>("FeeCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Fee>> OnFeeStatusUpdated([Service] ITopicEventReceiver eventReceiver, CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Fee>("FeeStatusUpdated", cancellationToken);
        }
    }
}