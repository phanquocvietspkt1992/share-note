
using ShareNote.Domain.Entities;

namespace ShareNote.Infrasstructure.Seeds
{
    public class NoteDataSeeder
    {
        readonly INoteRepository _noteRepository;
        public NoteDataSeeder(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public void Run()
        {
            // Generate some sample notes
            var notes = GenerateNotes(); // Assuming NoteGenerator.GenerateNotes() gives you a list of notes
            _noteRepository.InsertManyAsync(notes);

        }



        public static List<Note> GenerateNotes()
        {
            var websites = new List<(string Name, string Url, string Description)>
        {
            ("Google", "https://www.google.com", "The world's most popular search engine."),
        ("YouTube", "https://www.youtube.com", "A video sharing and streaming platform."),
        ("Facebook", "https://www.facebook.com", "A social media platform to connect with friends and family."),
        ("Amazon", "https://www.amazon.com", "An online marketplace for goods and services."),
        ("Wikipedia", "https://www.wikipedia.org", "A free online encyclopedia."),
        ("Twitter", "https://www.twitter.com", "A platform for microblogging and news sharing."),
        ("Instagram", "https://www.instagram.com", "A photo and video sharing social networking service."),
        ("LinkedIn", "https://www.linkedin.com", "A platform for professional networking and job searching."),
        ("Reddit", "https://www.reddit.com", "A network of communities for discussions and sharing content."),
        ("Netflix", "https://www.netflix.com", "A subscription-based video streaming service."),
        ("Bing", "https://www.bing.com", "A web search engine developed by Microsoft."),
        ("Yahoo", "https://www.yahoo.com", "A web portal providing news, email, and search services."),
        ("Pinterest", "https://www.pinterest.com", "A social media platform for sharing images and ideas."),
        ("Spotify", "https://www.spotify.com", "A music streaming service offering a wide selection of songs."),
        ("Tumblr", "https://www.tumblr.com", "A microblogging and social networking platform."),
        ("Quora", "https://www.quora.com", "A Q&A platform where people can ask questions and share knowledge."),
        ("Twitch", "https://www.twitch.tv", "A live streaming platform for gamers and content creators."),
        ("Snapchat", "https://www.snapchat.com", "A multimedia messaging app with temporary images and videos."),
        ("eBay", "https://www.ebay.com", "An online auction and shopping website."),
        ("WhatsApp", "https://www.whatsapp.com", "A messaging app for sending text, voice, and video messages."),
        ("TikTok", "https://www.tiktok.com", "A short-video sharing platform."),
        ("Vimeo", "https://www.vimeo.com", "A video hosting and sharing platform."),
        ("Slack", "https://www.slack.com", "A messaging app for teams and workplaces."),
        ("GitHub", "https://www.github.com", "A platform for version control and collaborative software development."),
        ("PayPal", "https://www.paypal.com", "An online payment system for transferring money and making payments."),
        ("Dropbox", "https://www.dropbox.com", "A cloud storage and file synchronization service."),
        ("Spotify", "https://www.spotify.com", "A music streaming service offering a wide selection of songs."),
        ("Alibaba", "https://www.alibaba.com", "A global online marketplace for wholesale trade."),
        ("Zoom", "https://www.zoom.us", "A video conferencing platform for meetings, webinars, and communication."),
        ("WordPress", "https://www.wordpress.com", "A content management system (CMS) for creating websites and blogs."),
        ("Airbnb", "https://www.airbnb.com", "A marketplace for lodging, primarily homestays for vacation rentals."),
        ("Uber", "https://www.uber.com", "A ride-sharing platform that connects passengers with drivers."),
        ("GitLab", "https://www.gitlab.com", "A web-based DevOps lifecycle tool and Git repository manager."),
        ("Medium", "https://www.medium.com", "An online publishing platform for articles and blogs."),
        ("Hulu", "https://www.hulu.com", "A streaming service for TV shows, movies, and original content."),
        ("Adobe", "https://www.adobe.com", "A software company known for products like Photoshop, Acrobat, and Illustrator."),
        ("Shopify", "https://www.shopify.com", "An e-commerce platform for creating online stores."),
        ("Spotify", "https://www.spotify.com", "A music streaming service offering a wide selection of songs."),
        ("Salesforce", "https://www.salesforce.com", "A cloud-based CRM (Customer Relationship Management) platform."),
        ("Walmart", "https://www.walmart.com", "A multinational retail corporation operating a chain of hypermarkets."),
        ("TikTok", "https://www.tiktok.com", "A short-video sharing platform."),
        ("Trello", "https://www.trello.com", "A collaboration tool for organizing tasks and projects using boards."),
        ("StackOverflow", "https://www.stackoverflow.com", "A Q&A site for programmers and software developers."),
        ("WordPress.org", "https://www.wordpress.org", "An open-source CMS for building websites."),
        ("Coursera", "https://www.coursera.org", "An online learning platform offering courses from universities and institutions."),
        ("Udemy", "https://www.udemy.com", "An online learning platform with courses on various subjects."),
        ("Baidu", "https://www.baidu.com", "A Chinese web services company providing a search engine and AI-powered solutions."),
        ("WeChat", "https://www.wechat.com", "A Chinese multi-purpose messaging, social media, and payment app."),
        ("Flickr", "https://www.flickr.com", "A photo-sharing platform."),
        ("Quora", "https://www.quora.com", "A Q&A platform where users ask questions and share knowledge."),
        ("ZoomInfo", "https://www.zoominfo.com", "A platform for B2B sales and marketing intelligence."),
        ("Khan Academy", "https://www.khanacademy.org", "A nonprofit educational website offering free lessons in various subjects."),
        ("Discord", "https://www.discord.com", "A communication platform for communities with voice, video, and text chat."),
        ("Yandex", "https://www.yandex.com", "A Russian multinational corporation specializing in Internet services and AI."),
        ("Spotify", "https://www.spotify.com", "A music streaming service offering a wide selection of songs."),
        ("Kroger", "https://www.kroger.com", "An American supermarket chain."),
        ("Best Buy", "https://www.bestbuy.com", "An American multinational retailer of consumer electronics and appliances."),
        ("Target", "https://www.target.com", "An American retail store selling a variety of goods."),
        ("Dropbox", "https://www.dropbox.com", "A cloud storage and file synchronization service."),
        ("Nordstrom", "https://www.nordstrom.com", "An American luxury department store chain."),
        ("Adobe", "https://www.adobe.com", "A software company known for products like Photoshop, Acrobat, and Illustrator."),
        ("American Express", "https://www.americanexpress.com", "A multinational financial services company."),
        ("CNN", "https://www.cnn.com", "A major news outlet offering breaking news and analysis."),
        ("BBC", "https://www.bbc.com", "A British public service broadcaster offering news, entertainment, and more."),
        ("Spotify", "https://www.spotify.com", "A music streaming service offering a wide selection of songs."),
        ("PayPal", "https://www.paypal.com", "An online payment system for transferring money and making payments."),
        ("Yahoo!", "https://www.yahoo.com", "A popular web portal providing news, email, and search services."),
        ("Vimeo", "https://www.vimeo.com", "A video hosting and sharing platform."),
        ("Etsy", "https://www.etsy.com", "An online marketplace for handmade, vintage, and craft items."),
        ("Asos", "https://www.asos.com", "An online fashion and cosmetic retailer."),
        ("BestBuy", "https://www.bestbuy.com", "An American multinational retailer of consumer electronics and appliances."),
        ("Zillow", "https://www.zillow.com", "A real estate and rental marketplace."),
        ("Adobe", "https://www.adobe.com", "A software company known for products like Photoshop, Acrobat, and Illustrator."),
        ("Expedia", "https://www.expedia.com", "An online travel agency for booking flights, hotels, and car rentals."),
        ("Instacart", "https://www.instacart.com", "An online grocery delivery and pickup service."),
        ("Wix", "https://www.wix.com", "A website building platform for creating web pages without coding."),
        ("Twitch", "https://www.twitch.tv", "A live streaming platform for gamers and content creators."),
        ("Yelp", "https://www.yelp.com", "A review platform for local businesses."),
        ("TripAdvisor", "https://www.tripadvisor.com", "A travel website with reviews of hotels, restaurants, and tourist attractions."),
        ("Shutterstock", "https://www.shutterstock.com", "A stock photography, footage, and music provider."),
        ("Grammarly", "https://www.grammarly.com", "An online grammar checking tool."),
        ("GitHub", "https://www.github.com", "A platform for version control and collaborative software development."),
        ("Hulu", "https://www.hulu.com", "A streaming service for TV shows, movies, and original content."),
        ("Canva", "https://www.canva.com", "A graphic design platform for creating visual content."),
        ("Mailchimp", "https://www.mailchimp.com", "A marketing automation platform and email marketing service."),
        ("Shopify", "https://www.shopify.com", "An e-commerce platform for creating online stores."),
        ("Lazada", "https://www.lazada.com", "A Southeast Asian e-commerce platform."),
        ("Ticketmaster", "https://www.ticketmaster.com", "A platform for purchasing tickets for concerts, sports events, and theater."),
        ("T-Mobile", "https://www.t-mobile.com", "An American wireless network provider."),
        ("Tesla", "https://www.tesla.com", "An electric vehicle and clean energy company."),
        ("Walmart", "https://www.walmart.com", "An American multinational retail corporation operating a chain of hypermarkets."),
        ("CocaCola", "https://www.coca-cola.com", "A multinational corporation producing soft drinks."),
        ("Spotify", "https://www.spotify.com", "A music streaming service offering a wide selection of songs."),
        ("H&M", "https://www.hm.com", "A Swedish multinational clothing retail company."),
        ("IKEA", "https://www.ikea.com", "A Swedish multinational company selling ready-to-assemble furniture and home goods."),
        ("Samsung", "https://www.samsung.com", "A multinational conglomerate producing electronics, home appliances, and more."),
        ("Nike", "https://www.nike.com", "A multinational corporation that designs and manufactures sportswear and equipment."),
        ("Target", "https://www.target.com", "An American retail store selling a variety of goods."),
        ("Sony", "https://www.sony.com", "A multinational conglomerate in the electronics, gaming, and entertainment industries."),
        ("Intel", "https://www.intel.com", "A multinational corporation that designs and manufactures semiconductor products."),
        ("HP", "https://www.hp.com", "A multinational information technology company providing computer hardware and software."),
        ("LG", "https://www.lg.com", "A multinational conglomerate in electronics, chemicals, and telecommunications."),
        ("Oracle", "https://www.oracle.com", "A multinational computer technology corporation providing database software and cloud services.")
            // Add more websites here up to 100...
        };

            var notes = new List<Note>();

            for (int i = 0; i < websites.Count; i++)
            {
                notes.Add(new Note
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Key = websites[i].Name,
                    Url = websites[i].Url,
                    Description = websites[i].Description
                });
            }

            return notes;
        }
    }

}


