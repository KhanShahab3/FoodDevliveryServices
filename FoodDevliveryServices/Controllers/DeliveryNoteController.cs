using FoodDevliveryServices.Models;
using FoodDevliveryServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDevliveryServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryNoteController : ControllerBase
    {
        private readonly IDeliveryNoteService _deliveryNote;
        public DeliveryNoteController(IDeliveryNoteService deliveryNote)
        {
            _deliveryNote = deliveryNote;
        }
        [HttpGet]
        public async Task<ActionResult<List<DeliveryNote>>> GetAllNotes()
        {
            var notes = await _deliveryNote.GetDeliveryNotes();
            if (notes.Count == 0)
                return new List<DeliveryNote>();
            return Ok(notes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryNote>> GetNoteById(int id)
        {
            var note = await _deliveryNote.GetDeliveryNoteById(id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }
        [HttpPost]
        public async Task<ActionResult> AddInventory(DeliveryNote deliveryNote)
        {
            await _deliveryNote.AddDeliveryNote(deliveryNote);
            return Ok("Inventory Created....!");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliveryNote>> UpdateNote(DeliveryNote deliveryNote, int id)
        {
            var existingNote = await _deliveryNote.UpdateDeliveryNote(deliveryNote, id);
            if (existingNote == null)
                return BadRequest();
            return Ok("Inventory Updated......!");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            await _deliveryNote.DeleteDeliveryNote(id);
            return Ok("Inventory Deleted.....!");
        }
    }
}
