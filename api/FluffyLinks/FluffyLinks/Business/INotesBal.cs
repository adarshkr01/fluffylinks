using FluffyLinks.Models.Database;

namespace FluffyLinks.Business
{
    public interface INotesBal
    {
        Task InsertNoteAsync(Note note);
    }
}
