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

        public async Task<List<Note>> GetAllNotesByUserIdAsync(string userId)
        {
            return await _notesCollection.AsQueryable().Where(x => x.UserId.Equals(userId, StringComparison.InvariantCultureIgnoreCase)).ToListAsync();
        }

        public async Task InsertNotesAsync(Note note)
        {
            await _notesCollection.InsertOneAsync(note);
        }
    }
}
