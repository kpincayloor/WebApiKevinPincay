using AutoMapper;
using WebApiKevinPincay.Api.Entities;
using WebApiKevinPincay.Api.Dtos;

namespace WebApiKevinPincay.Api
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
              config.CreateMap<ClienteDto, Cliente>();
              config.CreateMap<Cliente, ClienteDto>();

              config.CreateMap<CuentaDto, Cuenta>();
              config.CreateMap<Cuenta, CuentaDto>();

              config.CreateMap<MovimientoDto, Movimiento>();
              config.CreateMap<Movimiento, MovimientoDto>();
            });
            return mappingConfig;
        }
    }
}