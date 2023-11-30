using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private INoteService _noteService;
        private readonly ILogger<NoteController> _logger;

        public NoteController(INoteService noteService, ILogger<NoteController> logger)
        {
            _noteService = noteService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = await _noteService.GetAllNotes();
            if (notes == null) { return NotFound(); }

            return Ok(notes);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNote(int id)
        {
            await _noteService.DeleteNote(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutNote(int id, string newNote)
        {
            var updatedNote = await _noteService.PutNote(id, newNote);
            if (updatedNote == null) { return NotFound(); }

            return Ok(updatedNote);
        }

        [HttpPost]
        public async Task<IActionResult> PostNote([FromBody] string note)
        {
            var notes = await _noteService.PostNote(note);
            if (notes == null) { return NotFound(); }

            return Ok(notes);
        }
    }
}
