


using Newtonsoft.Json;
using ShareNote.Domain.Entities;

namespace ShareNote.Application.Services.Elasticsearchs
{
    public class ElasticsearchDataSeeder
    {

        private readonly ElasticsearchService _elasticsearchService;
        public ElasticsearchDataSeeder(ElasticsearchService elasticsearchService)
        {

            _elasticsearchService = elasticsearchService;
        }
        public void AddMostPopularWebsites()
        {
            List<WebPage> webPages = GetMostPopularWebsites(); ;
            _elasticsearchService.BulkIndexDocuments(webPages.Distinct());

        }


        public static List<WebPage> GetMostPopularWebsites()
        {
            return new List<WebPage>
            {
                new WebPage
            {
                Url = "https://www.google.com",
                Title = "Google - The Search Engine",
                Content = "Google is the world's leading search engine, helping billions of users find information online.",
                Tags = new List<string> { "search", "engine", "queries", "internet" },
                UpdatedAt = DateTime.Today.AddDays(-10),
                Popularity = 98.5f
            },
            new WebPage
            {
                Url = "https://www.youtube.com",
                Title = "YouTube - Video Sharing Platform",
                Content = "YouTube is a video-sharing platform where users can upload, view, and share videos on a variety of topics.",
                Tags = new List<string> { "videos", "streaming", "entertainment", "clips" },
                UpdatedAt = DateTime.Today.AddDays(-20),
                Popularity = 96.2f
            },
            new WebPage
            {
                Url = "https://www.facebook.com",
                Title = "Facebook - Connect with Friends",
                Content = "Facebook is a social media platform that helps users connect with friends, share posts, and join communities.",
                Tags = new List<string> { "social", "friends", "posts", "sharing" },
                UpdatedAt = DateTime.Today.AddDays(-15),
                Popularity = 94.8f
            },
            new WebPage
            {
                Url = "https://www.amazon.com",
                Title = "Amazon - Online Shopping Hub",
                Content = "Amazon is a global ecommerce platform offering a wide range of products from electronics to groceries.",
                Tags = new List<string> { "shopping", "ecommerce", "products", "sales" },
                UpdatedAt = DateTime.Today.AddDays(-12),
                Popularity = 92.3f
            },
            new WebPage
            {
                Url = "https://www.netflix.com",
                Title = "Netflix - Movies and TV Shows Streaming",
                Content = "Netflix is a subscription-based streaming service offering movies, TV shows, and original content.",
                Tags = new List<string> { "entertainment", "streaming", "movies", "shows" },
                UpdatedAt = DateTime.Today.AddDays(-8),
                Popularity = 90.7f
            },
            new WebPage
            {
                Url = "https://www.wikipedia.org",
                Title = "Wikipedia - Free Online Encyclopedia",
                Content = "Wikipedia is a free online encyclopedia, created and edited by volunteers around the world.",
                Tags = new List<string> { "education", "information", "encyclopedia", "knowledge" },
                UpdatedAt = DateTime.Today.AddDays(-5),
                Popularity = 88.9f
            },
            new WebPage
            {
                Url = "https://www.github.com",
                Title = "GitHub - Code Hosting Platform",
                Content = "GitHub is a web-based platform for version control and collaboration, widely used by developers.",
                Tags = new List<string> { "development", "code", "git", "repositories" },
                UpdatedAt = DateTime.Today.AddDays(-18),
                Popularity = 87.4f
            },
            new WebPage
            {
                Url = "https://www.instagram.com",
                Title = "Instagram - Photo and Video Sharing",
                Content = "Instagram is a social media platform for sharing photos, videos, and stories with friends and followers.",
                Tags = new List<string> { "photos", "videos", "social", "sharing" },
                UpdatedAt = DateTime.Today.AddDays(-7),
                Popularity = 86.7f
            },
            new WebPage
            {
                Url = "https://www.linkedin.com",
                Title = "LinkedIn - Professional Networking",
                Content = "LinkedIn is the leading professional networking platform, connecting people to opportunities worldwide.",
                Tags = new List<string> { "professional", "networking", "jobs", "career" },
                UpdatedAt = DateTime.Today.AddDays(-10),
                Popularity = 85.2f
            },
            new WebPage
            {
                Url = "https://www.twitter.com",
                Title = "Twitter - What's Happening Now",
                Content = "Twitter is a platform where users can share short messages, follow trending topics, and engage in discussions.",
                Tags = new List<string> { "social", "news", "trends", "tweets" },
                UpdatedAt = DateTime.Today.AddDays(-12),
                Popularity = 84.5f
            },
            new WebPage
            {
                Url = "https://www.twitch.tv",
                Title = "Twitch - Live Game Streaming",
                Content = "Twitch is a platform for live streaming games, events, and entertainment, popular among gamers worldwide.",
                Tags = new List<string> { "streaming", "gaming", "live", "eSports" },
                UpdatedAt = DateTime.Today.AddDays(-9),
                Popularity = 83.8f
            },
            new WebPage
            {
                Url = "https://www.pinterest.com",
                Title = "Pinterest - Ideas and Inspiration",
                Content = "Pinterest is a platform to discover and save creative ideas for cooking, fashion, home, and more.",
                Tags = new List<string> { "inspiration", "ideas", "creativity", "design" },
                UpdatedAt = DateTime.Today.AddDays(-3),
                Popularity = 83.1f
            },
            new WebPage
            {
                Url = "https://www.apple.com",
                Title = "Apple - Leading Technology Products",
                Content = "Apple designs and sells innovative technology products including iPhones, iPads, Macs, and more.",
                Tags = new List<string> { "technology", "gadgets", "innovation", "apple" },
                UpdatedAt = DateTime.Today.AddDays(-14),
                Popularity = 82.5f
            },
            new WebPage
            {
                Url = "https://www.bbc.com",
                Title = "BBC - Global News and Stories",
                Content = "BBC delivers world-class news, documentaries, and stories to a global audience.",
                Tags = new List<string> { "news", "world", "media", "stories" },
                UpdatedAt = DateTime.Today.AddDays(-4),
                Popularity = 81.8f
            },
            new WebPage
            {
                Url = "https://www.cnn.com",
                Title = "CNN - Breaking News",
                Content = "CNN provides breaking news coverage, in-depth analysis, and global events.",
                Tags = new List<string> { "news", "breaking", "global", "analysis" },
                UpdatedAt = DateTime.Today.AddDays(-20),
                Popularity = 81.1f
            },
            new WebPage
            {
                Url = "https://www.google.com",
                Title = "Google - The Search Engine",
                Content = "Google is the world's leading search engine, helping billions of users find information online.",
                Tags = new List<string> { "search", "engine", "queries", "internet" },
                UpdatedAt = DateTime.Today.AddDays(-10),
                Popularity = 98.5f
            },
           
         // detailed entries here as in the initial response)

            // Remaining 50 entries
            new WebPage
            {
                Url = "https://www.stackoverflow.com",
                Title = "Stack Overflow - Programming Q&A",
                Content = "Stack Overflow is the largest online community for programmers to learn, share knowledge, and advance their careers.",
                Tags = new List<string> { "programming", "developers", "Q&A", "technology" },
                UpdatedAt = DateTime.Today.AddDays(-2),
                Popularity = 89.0f
            },
            new WebPage
            {
                Url = "https://www.imdb.com",
                Title = "IMDb - Movie Database",
                Content = "IMDb is the world's most popular and authoritative source for movie, TV, and celebrity content.",
                Tags = new List<string> { "movies", "TV shows", "reviews", "actors" },
                UpdatedAt = DateTime.Today.AddDays(-5),
                Popularity = 87.4f
            },
            new WebPage
            {
                Url = "https://www.quora.com",
                Title = "Quora - Question and Answer Platform",
                Content = "Quora is a place to gain and share knowledge, where users ask questions and get answers from the community.",
                Tags = new List<string> { "questions", "answers", "community", "knowledge" },
                UpdatedAt = DateTime.Today.AddDays(-8),
                Popularity = 85.7f
            },
            new WebPage
            {
                Url = "https://www.medium.com",
                Title = "Medium - Writing and Blogging Platform",
                Content = "Medium is an open platform where readers and writers share ideas, stories, and perspectives.",
                Tags = new List<string> { "writing", "blogging", "stories", "articles" },
                UpdatedAt = DateTime.Today.AddDays(-3),
                Popularity = 84.2f
            },
            new WebPage
            {
                Url = "https://www.reddit.com",
                Title = "Reddit - The Front Page of the Internet",
                Content = "Reddit is a network of communities where people can dive into their interests, hobbies, and passions.",
                Tags = new List<string> { "forums", "community", "news", "discussions" },
                UpdatedAt = DateTime.Today.AddDays(-7),
                Popularity = 83.5f
            },
            new WebPage
            {
                Url = "https://www.paypal.com",
                Title = "PayPal - Online Payment Solution",
                Content = "PayPal is a secure online payment system used by millions for shopping, transfers, and receiving payments.",
                Tags = new List<string> { "payments", "online", "secure", "transactions" },
                UpdatedAt = DateTime.Today.AddDays(-14),
                Popularity = 82.9f
            },
            new WebPage
            {
                Url = "https://www.airbnb.com",
                Title = "Airbnb - Vacation Rentals and Experiences",
                Content = "Airbnb connects travelers with unique homes and experiences in destinations around the world.",
                Tags = new List<string> { "travel", "rentals", "experiences", "vacations" },
                UpdatedAt = DateTime.Today.AddDays(-12),
                Popularity = 81.7f
            },
            new WebPage
            {
                Url = "https://www.shopify.com",
                Title = "Shopify - Ecommerce Solutions",
                Content = "Shopify is an ecommerce platform that allows businesses to create and manage online stores.",
                Tags = new List<string> { "ecommerce", "online", "stores", "sales" },
                UpdatedAt = DateTime.Today.AddDays(-18),
                Popularity = 80.3f
            },
            new WebPage
            {
                Url = "https://www.microsoft.com",
                Title = "Microsoft - Leading Software and Technology",
                Content = "Microsoft is a global technology company offering Windows, Office, Azure, and innovative products.",
                Tags = new List<string> { "software", "technology", "innovation", "products" },
                UpdatedAt = DateTime.Today.AddDays(-22),
                Popularity = 79.8f
            },
            new WebPage
            {
                Url = "https://www.ebay.com",
                Title = "eBay - Online Auctions and Shopping",
                Content = "eBay is an online marketplace for buying and selling new and used items across various categories.",
                Tags = new List<string> { "shopping", "auctions", "marketplace", "sales" },
                UpdatedAt = DateTime.Today.AddDays(-16),
                Popularity = 78.5f
            },
            // Continue with similar detailed entries...

            new WebPage
            {
                Url = "https://www.bing.com",
                Title = "Bing - Microsoft's Search Engine",
                Content = "Bing is a search engine by Microsoft that helps users find information, images, and videos online.",
                Tags = new List<string> { "search", "engine", "images", "videos" },
                UpdatedAt = DateTime.Today.AddDays(-30),
                Popularity = 75.6f
            }

                // ... Add more manually curated entries like these, ensuring variety and relevance.

                // Once you have 50 detailed entries, you can generate the remaining 50 using variations of the above.
            };

        }
    }

}


