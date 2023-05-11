using AutoMapper;
using FluffyLinks.Models.Database;
using FluffyLinks.Models.Request;
using FluffyLinks.Repository;

namespace FluffyLinks.Business
{
    public class NotesBal : INotesBal
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public NotesBal(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task InsertNoteAsync(CreateNoteRequest request)
        {
            var note = _mapper.Map<Note>(request);
            await _noteRepository.InsertNotesAsync(note);
        }
    }
}
