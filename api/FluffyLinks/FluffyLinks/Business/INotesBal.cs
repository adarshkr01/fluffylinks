using FluffyLinks.Models.Database;
using FluffyLinks.Models.Request;

namespace FluffyLinks.Business
{
    public interface INotesBal
    {
        Task InsertNoteAsync(CreateNoteRequest request);

        Task<Note> GetNoteByIdAsync(string id);
    }
}
