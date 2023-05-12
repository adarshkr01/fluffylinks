using FluffyLinks.Models.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace FluffyLinks.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IMongoCollection<Note> _notesCollection;

        public NoteRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.Database);

            _notesCollection = mongoDatabase.GetCollection<Note>(mongoDbSettings.Value.NotesCollection);
        }

        public async Task<List<Note>> GetNotesByUserIdAsync(string userId)
        {
            return await _notesCollection.AsQueryable().Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task InsertNoteAsync(Note note)
        {
            await _notesCollection.InsertOneAsync(note);
        }

        public async Task<Note> GetNoteByIdAsync(string id)
        {
            return await _notesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteNoteByIdAsync(string id)
        {
            await _notesCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<Note>> GetNotesByUrlAsync(string url)
        {
            return await _notesCollection.AsQueryable().Where(x => x.Url == url).ToListAsync();
        }

        public async Task UpdateNoteAsync(string id, Note note)
        {
            await _notesCollection.ReplaceOneAsync(x => x.Id == id, note);
        }
    }
}
