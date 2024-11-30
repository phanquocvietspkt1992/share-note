using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ShareNote.Domain.Entities
{
    public class Note
    {
        [BsonId] // Marks this property as the ID field
        [BsonRepresentation(BsonType.ObjectId)] // Allows it to be stored as an ObjectId in MongoDB
        public string Id { get; set; }

        public string Uuid { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }

}
