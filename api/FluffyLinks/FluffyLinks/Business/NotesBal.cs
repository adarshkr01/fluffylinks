using System.Web;
using AutoMapper;
using FluffyLinks.Exceptions;
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

            note.Url = HttpUtility.UrlDecode(note.Url).ToLower();
            note.CreatedAt = DateTimeOffset.Now;
            
            await _noteRepository.InsertNoteAsync(note);
        }

        public async Task<Note> GetNoteByIdAsync(string id)
        {
            var note = await _noteRepository.GetNoteByIdAsync(id);

            if (note == null)
            {
                throw new NotFoundException("");
            }

            return note;
        }

        public async Task<List<Note>> GetNotesByUserIdAsync(string userId)
        {
            return await _noteRepository.GetNotesByUserIdAsync(userId);
        }

        public async Task DeleteNoteByIdAsync(string id)
        {
            await GetNoteByIdAsync(id);

            await _noteRepository.DeleteNoteByIdAsync(id);
        }

        public async Task<List<Note>> GetNotesByUrlAsync(string url)
        {
            return await _noteRepository.GetNotesByUrlAsync(HttpUtility.UrlDecode(url).ToLower());
        }
    }
}
