using FluffyLinks.Models.Database;

namespace FluffyLinks.Repository
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllNotesByUserIdAsync(string userId);

        Task InsertNotesAsync(Note note);
    }
}
