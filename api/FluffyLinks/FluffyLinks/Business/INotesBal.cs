using FluffyLinks.Models.Database;
using FluffyLinks.Models.Request;

namespace FluffyLinks.Business
{
    public interface INotesBal
    {
        Task InsertNoteAsync(CreateNoteRequest request);

        Task<Note> GetNoteByIdAsync(string id);

        Task<List<Note>> GetNotesByUserIdAsync(string userId);

        Task DeleteNoteByIdAsync(string id);

        Task<List<Note>> GetNotesByUrlAsync(string url);

        Task UpdateNoteAsync(string id, UpdateNoteRequest note);
    }
}
