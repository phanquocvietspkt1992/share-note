
using ShareNote.Domain.Entities;

namespace ShareNote.Infrasstructure
{
    public interface INoteRepository
    {
        Task<Note> InsertOneAsync(Note myNote);
        Task<IEnumerable<Note>> GetAllDataAsync();
        Task<IEnumerable<Note>> SearchAsync(string key);

        Task InsertManyAsync(List<Note> notes);
        void CreateTextIndex();
        Task ClearAllDataAsync();
    }

}
