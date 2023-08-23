using H3_AppProgammering_1___Gallery.DataHandlers;
using H3_AppProgammering_1___Gallery.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using NuGet.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H3_AppProgammering_1___Gallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryEntryController : ControllerBase
    {
        private GalleryEntryDataHandler _handler;
        public GalleryEntryController()
        {
            _handler = new GalleryEntryDataHandler();
        }

        // GET: api/<GalleryEntryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<GalleryEntry> entries = await _handler.GetAll();
            return Ok(entries);
        }

        // GET api/<GalleryEntryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            GalleryEntry entry = await _handler.GetById(id);
            return Ok(entry);
        }

        // POST api/<GalleryEntryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GalleryEntry entry)
        {
            entry = await _handler.Create(entry);
            return Created($"/GalleryEntry/{entry.ID}", entry);
        }

        // PUT api/<GalleryEntryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GalleryEntry entry)
        {
            await _handler.Update(entry);
            return NoContent();
        }

        // DELETE api/<GalleryEntryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _handler.Delete(id);
            return NoContent();
        }
    }
}
