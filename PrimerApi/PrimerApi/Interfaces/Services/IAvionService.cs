using PrimerApi.Dto;
using PrimerApi.Response;

namespace PrimerApi.Interfaces.Services
{
    public interface IAvionService
    {
        Task<ApiResponse<List<AvionDto>>> GetAll();
        Task<ApiResponse<AvionDto>> GetById(int id);
    }
}
