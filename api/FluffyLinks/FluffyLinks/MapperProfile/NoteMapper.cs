using AutoMapper;
using FluffyLinks.Models.Database;
using FluffyLinks.Models.Request;

namespace FluffyLinks.MapperProfile
{
    public class NoteMapper : Profile
    {
        public NoteMapper()
        {
            CreateMap<CreateNoteRequest, Note>();
        }
    }
}
