using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Nest;
using ShareNote.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ShareNote.Infrasstructure
{
    public class MongoNoteRepository : INoteRepository
    {
        private readonly IMongoCollection<Note> _noteCollection;
        IConfiguration _configuration;

        public MongoNoteRepository(IMongoDatabase database, IConfiguration configuration)
        {

            _noteCollection = database.GetCollection<Note>("note-collection");
            _configuration = configuration;
        }

        public async Task<Note> InsertOneAsync(Note note)
        {
            await _noteCollection.InsertOneAsync(note);
            return note;
        }
        public async Task InsertManyAsync(List<Note> notes)
        {
            try
            {
                // Insert the list of notes into the collection
                await _noteCollection.InsertManyAsync(notes);
                Console.WriteLine($"{notes.Count} notes added to MongoDB successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting notes: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Note>> SearchAsync(string key)
        {
            // Create a regex filter for case-insensitive matching in the fields Key, Url, and Description
            var filter = Builders<Note>.Filter.Or(
                Builders<Note>.Filter.Regex(note => note.Key, new BsonRegularExpression(key, "i")),
                Builders<Note>.Filter.Regex(note => note.Url, new BsonRegularExpression(key, "i")),
                Builders<Note>.Filter.Regex(note => note.Description, new BsonRegularExpression(key, "i"))
            );

            // Fetch all matching documents from the collection
            var result = await _noteCollection.Find(filter).ToListAsync();

            return result;
        }
        public async Task<IEnumerable<Note>> GetAllDataAsync()
        {
            var allNotes = await _noteCollection.Find(Builders<Note>.Filter.Empty).ToListAsync();

            // Return the result
            return allNotes;
        }

        public async Task ClearAllDataAsync()
        {
            try
            {
                // Delete all documents in the collection
                var result = await _noteCollection.DeleteManyAsync(FilterDefinition<Note>.Empty);

                // Log how many documents were deleted
                Console.WriteLine($"Successfully deleted {result.DeletedCount} documents.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing collection: {ex.Message}");
            }
        }

        public void ClearCollections(string databaseName)
        {
            var client = new MongoClient(_configuration.GetConnectionString("MongoConnection"));
            var database = client.GetDatabase(databaseName);
            var collections = database.ListCollectionNames().ToList();

            foreach (var collectionName in collections)
            {
                database.DropCollection(collectionName);
                Console.WriteLine($"Dropped collection: {collectionName}");
            }
        }

        public void CreateTextIndex()
        {
            // Define the text index on the Key, Url, and Description fields
            var indexKeys = Builders<Note>.IndexKeys
                .Text(note => note.Key)
                .Text(note => note.Url)
                .Text(note => note.Description)
                .Text(note => note.Uuid);

            var indexOptions = new CreateIndexOptions { DefaultLanguage = "english" };

            // Create the index on the Notes collection
            var indexModel = new CreateIndexModel<Note>(indexKeys, indexOptions);
            _noteCollection.Indexes.CreateOne(indexModel);
        }

        public void DropExistingIndex(string indexName)
        {
            // Drop the existing index if needed
            try
            {
                _noteCollection.Indexes.DropOne(indexName);
                Console.WriteLine($"Index '{indexName}' dropped successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error dropping index: {ex.Message}");
            }
        }






    }

}
