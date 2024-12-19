using FoodDevliveryServices.DataBaseContext;
using FoodDevliveryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.Services
{
    public class DeliveryNoteService:IDeliveryNoteService
    {
        private readonly AppDbContext _appDbContext;
        public DeliveryNoteService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddDeliveryNote(DeliveryNote deliveryNote)
        {
            _appDbContext.DeliveryNotes.Add(deliveryNote);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task<List<DeliveryNote>> GetDeliveryNotes()
        {
            var notes = await _appDbContext.DeliveryNotes.ToListAsync();
            return notes;   
                
                
                }
        public async Task<DeliveryNote> GetDeliveryNoteById(int Id)
        {
            var note = await _appDbContext.DeliveryNotes.FindAsync(Id);
            return note;
        }
        public async Task<DeliveryNote> UpdateDeliveryNote(DeliveryNote deliveryNote, int id)
        {
            var existingNote = await _appDbContext.DeliveryNotes.FindAsync(id);
            if(existingNote != null)
            {
                existingNote.DeliveryId = deliveryNote.DeliveryId;
                existingNote.Delivery = deliveryNote.Delivery;
                existingNote.UpdatedAt= DateTime.Now;
                _appDbContext.DeliveryNotes.Update(existingNote);
             await _appDbContext.SaveChangesAsync();

            }
            return existingNote;
            
        }
        public async Task DeleteDeliveryNote(int id)
        {
            var note = _appDbContext.DeliveryNotes.Find(id);
            if(note != null)
            {
                _appDbContext.DeliveryNotes.Remove(note);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
