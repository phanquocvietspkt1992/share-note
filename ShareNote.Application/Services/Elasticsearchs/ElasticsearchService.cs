using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareNote.Domain.Entities;
using ShareNote.Infrasstructure;
using Nest;

namespace ShareNote.Application.Services.Elasticsearchs
{
    public class ElasticsearchService
    {
        private readonly ElasticClient _client;

        public ElasticsearchService(ElasticClientProvider clientProvider)
        {
            _client = clientProvider.GetClient();
        }
        public IEnumerable<WebPage> SearchInMultipleFields(string query)
        {
            var response = _client.Search<WebPage>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(
                            sh => sh
                                .Match(m => m
                                    .Field(f => f.Title)
                                    .Query(query) // Search for the query in the Title
                                ),
                            sh => sh
                                .Match(m => m
                                    .Field(f => f.Content)
                                    .Query(query) // Search for the query in the Content
                                ),
                            sh => sh
                                .Match(m => m
                                    .Field(f => f.Tags)
                                    .Query(query) // Search for the query in the Tags
                                ),
                            sh => sh
                               .Wildcard(w => w
                                    .Field(f => f.Url)
                                    .Value($"*{query}*") // Use Wildcard for Url to match substrings like ".com"
                                )
                        )
                    )
                )
            );

            if (!response.IsValid)
            {
                throw new Exception($"Search failed: {response.ServerError}");
            }

            // Group by the Url field and take only the first item from each group (based on Url)
            return response.Documents
                .GroupBy(page => page.Url) // Ensure unique Urls
                .Select(group => group.First()) // Return only the first document for each Url
                .ToList(); // Convert to list for immediate execution
        }

        public IEnumerable<WebPage> SearchInMultipleFieldsFuzziness(string query)
        {
            var response = _client.Search<WebPage>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Should(
                            // Fuzzy matching for Title, Content, and Tags (allows small spelling variations)
                            sh => sh
                                .Fuzzy(f => f
                                    .Field(f => f.Title)
                                    .Value(query) // Fuzzy search for the query in Title
                                    .Fuzziness(Fuzziness.Auto) // Allow fuzzy matching
                                ),
                            sh => sh
                                .Fuzzy(f => f
                                    .Field(f => f.Content)
                                    .Value(query) // Fuzzy search for the query in Content
                                    .Fuzziness(Fuzziness.Auto) // Allow fuzzy matching
                                ),
                            sh => sh
                                .Fuzzy(f => f
                                    .Field(f => f.Tags)
                                    .Value(query) // Fuzzy search for the query in Tags
                                    .Fuzziness(Fuzziness.Auto) // Allow fuzzy matching
                                ),
                            // Wildcard query for Title, Content, Tags, and URL to allow substring matching
                            sh => sh
                                .Wildcard(w => w
                                    .Field(f => f.Content)
                                    .Value($"*{query}*") // Substring match in Content field
                                ),
                            sh => sh
                                .Wildcard(w => w
                                    .Field(f => f.Title)
                                    .Value($"*{query}*") // Substring match in Title field
                                ),
                            sh => sh
                                .Wildcard(w => w
                                    .Field(f => f.Tags)
                                    .Value($"*{query}*") // Substring match in Tags field
                                ),
                            sh => sh
                                .Wildcard(w => w
                                    .Field(f => f.Url)
                                    .Value($"*{query}*") // Substring match in URL field
                                ),
                            sh => sh
                            .MatchPhrase(mp => mp
                                .Field(f => f.Content)
                                .Query(query) // Match phrase in Content field
                            )
                        )
                    )
                )
            );

            if (!response.IsValid)
            {
                throw new Exception($"Search failed: {response.ServerError}");
            }

            // Group by the Url field and take only the first item from each group (based on Url)
            return response.Documents
                .GroupBy(page => page.Url) // Ensure unique Urls
                .Select(group => group.First()) // Return only the first document for each Url
                .ToList(); // Convert to list for immediate execution
        }

        public void CreateIndex()
        {
            var createIndexResponse = _client.Indices.Create("webpages", c => c
                .Map<WebPage>(m => m
                    .AutoMap()
                    .Properties(props => props
                        .Text(t => t.Name(n => n.Title).Analyzer("standard"))
                        .Text(t => t.Name(n => n.Content).Analyzer("english"))
                        .Keyword(k => k.Name(n => n.Url))
                        .Date(d => d.Name(n => n.UpdatedAt))
                        .Number(n => n.Name(n => n.Popularity).Type(NumberType.Float))
                        .Keyword(k => k.Name(n => n.Tags))
                    )
                )
            );

            if (!createIndexResponse.IsValid)
            {
                throw new Exception($"Failed to create index: {createIndexResponse.ServerError}");
            }
        }
        public void IndexDocument(WebPage page)
        {
            var response = _client.IndexDocument(page);

            if (!response.IsValid)
            {
                throw new Exception($"Failed to index document: {response.ServerError}");
            }
        }
        public void BulkIndexDocuments(IEnumerable<WebPage> pages)
        {
            var response = _client.Bulk(b => b
                .IndexMany(pages)
            );

            if (!response.IsValid)
            {
                throw new Exception($"Bulk indexing failed: {response.ServerError}");
            }
        }
        public IEnumerable<WebPage> Search(string query)
        {
            var response = _client.Search<WebPage>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Content)
                        .Query(query)
                    )
                )
            );

            if (!response.IsValid)
            {
                throw new Exception($"Search failed: {response.ServerError}");
            }

            return response.Documents;
        }
        public IEnumerable<WebPage> FilteredSearch(string query, DateTime updatedAfter)
        {
            var response = _client.Search<WebPage>(s => s
                .Query(q => q
                    .Bool(b => b
                        .Must(m => m
                            .Match(mt => mt
                                .Field(f => f.Content)
                                .Query(query)
                            )
                        )
                        .Filter(f => f
                            .DateRange(dr => dr
                                .Field(f => f.UpdatedAt)
                                .GreaterThanOrEquals(updatedAfter)
                            )
                        )
                    )
                )
            );

            if (!response.IsValid)
            {
                throw new Exception($"Filtered search failed: {response.ServerError}");
            }

            return response.Documents;
        }
        public IEnumerable<WebPage> SortedSearch(string query)
        {
            var response = _client.Search<WebPage>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Content)
                        .Query(query)
                    )
                )
                .Sort(so => so
                    .Descending(d => d.Popularity)
                )
            );

            if (!response.IsValid)
            {
                throw new Exception($"Sorted search failed: {response.ServerError}");
            }

            return response.Documents;
        }
        public IEnumerable<dynamic> HighlightSearch(string query)
        {
            var response = _client.Search<WebPage>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Content)
                        .Query(query)
                    )
                )
                .Highlight(h => h
                    .Fields(f => f
                        .Field(fl => fl.Content)
                    )
                )
            );

            if (!response.IsValid)
            {
                throw new Exception($"Highlight search failed: {response.ServerError}");
            }

            return response.Hits.Select(hit => new
            {
                hit.Source,
                Highlight = hit.Highlight["content"]
            });
        }

    }
}
