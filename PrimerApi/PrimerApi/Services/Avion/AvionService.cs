using AutoMapper;
using PrimerApi.Dto;
using PrimerApi.Interfaces;
using PrimerApi.Interfaces.Services;
using PrimerApi.Response;

namespace PrimerApi.Services.Avion
{
    public class AvionService : IAvionService
    {
        private readonly IAvionRepository _avroionRepository;
        private readonly IMapper _mapper;

        public AvionService(IAvionRepository avionRepository, IMapper mapper)
        {
            _avroionRepository = avionRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<AvionDto>>> GetAll()
        {
            var response = new ApiResponse<List<AvionDto>>();
            response.Data = new List<AvionDto>();
            var aviones = await _avroionRepository.GetAll();
            if (aviones != null)
            {
                //response.Data = _mapper.Map<List<AvionDto>>(aviones);
                foreach (var avion in aviones)
                {
                    AvionDto avionDto = new AvionDto();
                    avionDto.Matricula = avion.Matricula;
                    avionDto.CantidadPasajesros = avion.CantidadPasajesros;
                    avionDto.Marca = avion.MarcaAvion.Marca;
                    response.Data.Add(avionDto);
                }
            }
            return response;
        }

        public Task<ApiResponse<AvionDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
