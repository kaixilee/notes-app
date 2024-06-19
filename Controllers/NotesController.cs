// Controllers/NotesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DigitalDiary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<string> notes = new List<string>();

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(notes);
        }

        [HttpPost]
        public IActionResult AddNote([FromBody] Note note)
        {
            if (note == null || string.IsNullOrWhiteSpace(note.Content))
            {
                return BadRequest(new { message = "Note content cannot be empty" });
            }

            notes.Add(note.Content);
            return Ok(new { note = note.Content });
        }
    }

    public class Note
    {
        public string Content { get; set; }
    }
}
