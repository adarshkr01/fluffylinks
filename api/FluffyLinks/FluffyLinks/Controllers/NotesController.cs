using FluffyLinks.Business;
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

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            await notesBal.InsertNoteAsync(new Models.Database.Note
            {
                Title = "Test Title",
                Url = "https://google.com",
                Description = "Test Description"
            });

            return Ok();
        }
    }
}
