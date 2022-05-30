using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetNotes.Book;
using NetNotes.Repositories;

namespace NetNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NotesRepository _notesRepository;

        public NotesController(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }
        [HttpGet]
        public List<Note> GetNotes()
        {
            return _notesRepository.GetNotes();
        }
        [HttpGet("id")]
        public Note GetNote(int id)
        {
            return _notesRepository.GetNote(id);
        }
        [HttpPost]
        public ActionResult CreateNote([FromBody] Note note)
        {
            _notesRepository.CreateNote(note);
            return CreatedAtAction(nameof(note), note);
        }
        [HttpDelete]
        public ActionResult DeleteNote([FromQuery] int id)
        {
            _notesRepository.DeleteNote(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateNote([FromBody] Note note)
        {
            _notesRepository.UpdateNote(note);
            return Ok();
        }
    }
}
