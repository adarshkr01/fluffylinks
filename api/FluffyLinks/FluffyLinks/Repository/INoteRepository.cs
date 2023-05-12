using FluffyLinks.Models.Database;

namespace FluffyLinks.Repository
{
    public interface INoteRepository
    {
        Task<List<Note>> GetNotesByUserIdAsync(string userId);

        Task InsertNoteAsync(Note note);

        Task<Note> GetNoteByIdAsync(string id);

        Task DeleteNoteByIdAsync(string id);

        Task<List<Note>> GetNotesByUrlAsync(string url);
    }
}
