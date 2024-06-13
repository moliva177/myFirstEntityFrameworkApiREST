using Microsoft.EntityFrameworkCore;
using PrimerApi.Data;
using PrimerApi.Interfaces;
using PrimerApi.Models;

namespace PrimerApi.Repos
{
    public class AvionRepository : IAvionRepository
    {
        private readonly ContextDb _contextDb;

        public AvionRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public async Task<List<Avion>> GetAll()
        {
            var aviones = await _contextDb.Aviones.Include(c=> c.MarcaAvion).ToListAsync();
            return aviones;
        }

        public Task<Avion> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
