using Microsoft.AspNetCore.Mvc;
using DotnetNotesApi.Models;

namespace DotnetNotesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private static List<Note> notes = new();

    [HttpGet]
    public IActionResult GetNotes()
    {
        return Ok(notes);
    }

    [HttpPost]
    public IActionResult AddNote(Note note)
    {
        note.Id = notes.Count + 1;
        notes.Add(note);
        return Ok(note);
    }
}
