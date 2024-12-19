using FoodDevliveryServices.Models;

namespace FoodDevliveryServices.Services
{
    public interface IDeliveryNoteService
    {
        Task AddDeliveryNote(DeliveryNote deliveryNote);
        Task<List<DeliveryNote>> GetDeliveryNotes();
        Task<DeliveryNote> GetDeliveryNoteById(int Id);
        Task<DeliveryNote>UpdateDeliveryNote(DeliveryNote deliveryNote,int id);
        Task DeleteDeliveryNote(int id);    
    }
}
