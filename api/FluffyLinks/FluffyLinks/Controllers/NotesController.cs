using FluffyLinks.Business;
using FluffyLinks.Exceptions;
using FluffyLinks.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FluffyLinks.Models.Database;

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
            catch (Exception)
            {
                return Problem(
                    "Error occurred while processing your request.",
                    statusCode: (int?) HttpStatusCode.InternalServerError,
                    title: "Create Note Exception",
                    type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    instance: HttpContext.Request.Path);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Note), 200)]
        public async Task<IActionResult> GetNoteById(string id)
        {
            try
            {
                var response = await notesBal.GetNoteByIdAsync(id);
                return Ok(response);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (FormatException ex)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return Problem(
                    "Error occurred while processing your request.",
                    statusCode: (int?) HttpStatusCode.InternalServerError,
                    title: "Get Note By Id Exception",
                    type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    instance: HttpContext.Request.Path);
            }
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<Note>), 200)]
        public async Task<IActionResult> GetNotesByUserId(string userId)
        {
            try
            {
                var response = await notesBal.GetNotesByUserIdAsync(userId);
                return Ok(response);
            }
            catch (Exception)
            {
                return Problem(
                    "Error occurred while processing your request.",
                    statusCode: (int?) HttpStatusCode.InternalServerError,
                    title: "Get Note By Id Exception",
                    type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    instance: HttpContext.Request.Path);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteById(string id)
        {
            try
            {
                await notesBal.DeleteNoteByIdAsync(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Problem(
                    "Error occurred while processing your request.",
                    statusCode: (int?)HttpStatusCode.InternalServerError,
                    title: "Get Note By Id Exception",
                    type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    instance: HttpContext.Request.Path);
            }
        }

        [HttpGet("url/{url}")]
        [ProducesResponseType(typeof(List<Note>), 200)]
        public async Task<IActionResult> GetNotesByUrlAsync(string url)
        {
            try
            {
                var response = await notesBal.GetNotesByUrlAsync(url);
                return Ok(response);
            }
            catch (Exception)
            {
                return Problem(
                    "Error occurred while processing your request.",
                    statusCode: (int?)HttpStatusCode.InternalServerError,
                    title: "Get Note By Id Exception",
                    type: "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                    instance: HttpContext.Request.Path);
            }
        }
    }
}
