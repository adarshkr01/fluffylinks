using FluffyLinks.Models.Database;
using FluffyLinks.Repository;

namespace FluffyLinks.Business
{
    public class NotesBal : INotesBal
    {
        private readonly INoteRepository noteRepository;

        public NotesBal(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task InsertNoteAsync(Note note)
        {
            await this.noteRepository.InsertNotesAsync(note);
        }
    }
}
