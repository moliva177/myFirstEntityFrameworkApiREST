using PrimerApi.Models;

namespace PrimerApi.Interfaces
{
    public interface IAvionRepository
    {
        Task<List<Avion>> GetAll();
        Task<Avion> GetById(int id);
    }
}
