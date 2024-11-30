using Microsoft.AspNetCore.Mvc;
using ShareNote.Application.Services.Elasticsearchs;
using ShareNote.Domain.Entities;
using ShareNote.Infrasstructure;
using ShareNote.Infrasstructure.Seeds;

namespace ShareNote.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {

        private readonly INoteRepository _repository;
        readonly NoteDataSeeder _noteDataSeeder;

        public NoteController(INoteRepository repository, NoteDataSeeder noteDataSeeder)
        {
            _repository = repository;
            _noteDataSeeder = noteDataSeeder;
        }


        [HttpPost]
        public async Task<ActionResult<Note>> Create(Note note)
        {
            try
            {
                note.Uuid = Guid.NewGuid().ToString();
                var createdObject = await _repository.InsertOneAsync(note);
                return Ok(createdObject);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }
        // GET api/notes
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllNotes()
        {
            try
            {
                // Call the service to get all data
                var allNotes = await _repository.GetAllDataAsync();

                // Return the data as a JSON response
                return Ok(allNotes);
            }
            catch (Exception ex)
            {
                // Handle any errors and return a server error response
                return StatusCode(500, $"Error fetching data: {ex.Message}");
            }
        }
        // GET api/notes/search?key=you
        [HttpGet("search")]
        public async Task<IActionResult> SearchNotes([FromQuery] string key)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(key))
                {
                    return BadRequest("Search key cannot be empty.");
                }

                // Call the service to search notes based on the 'key'
                var notes = await _repository.SearchAsync(key);

                if (notes == null || !notes.Any())
                {
                    return NotFound("No notes found matching the search criteria.");
                }

                // Return the matching notes as a JSON response
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error occurred: {ex.Message}");
            }
        }
        [HttpPost("add-most-popular-websites")]
        public async Task<ActionResult<Note>> AddMostPopularWebsites()
        {
            _noteDataSeeder.Run();
            return Ok("added most popular websites successfully.");
        }
        [HttpPost("create-text-index")]
        public async Task<ActionResult<Note>> CreateTextIndex()
        {
            _repository.CreateTextIndex();
            return Ok("Created Text Index successfully.");
        }

        // DELETE api/notes/clear
        [HttpDelete("clear-notes")]
        public async Task<IActionResult> ClearAllNotes()
        {
            try
            {
                // Call the service to clear all data
                await _repository.ClearAllDataAsync();

                // Return a success response
                return Ok("All notes cleared successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                return StatusCode(500, $"Error clearing notes: {ex.Message}");
            }
        }
        [HttpDelete("clear-collections")]
        public async Task<IActionResult> ClearCollections()
        {
            try
            {
                // Call the service to clear all data
                _repository.ClearCollections("ApiDatabase");

                // Return a success response
                return Ok("All notes cleared successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                return StatusCode(500, $"Error clearing notes: {ex.Message}");
            }
        }
        [HttpDelete("drop-index")]
        public async Task<IActionResult> DropExistingIndex(string indexName)
        {
            try
            {
                // Call the service to clear all data
                _repository.DropExistingIndex(indexName);

                // Return a success response
                return Ok("All notes cleared successfully.");
            }
            catch (Exception ex)
            {
                // Handle any errors that may have occurred
                return StatusCode(500, $"Error clearing notes: {ex.Message}");
            }
        }



    }
}
