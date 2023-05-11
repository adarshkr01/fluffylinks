using FluffyLinks.Business;
using FluffyLinks.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace FluffyLinks.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesBal notesBal;

        public NotesController(INotesBal notesBal)
        {
            this.notesBal = notesBal;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateNote(CreateNoteRequest request)
        {
            try
            {
                await notesBal.InsertNoteAsync(request);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
