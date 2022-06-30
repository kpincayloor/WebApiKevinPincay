using WebApiKevinPincay.Api.Dtos;

namespace WebApiKevinPincay.Api.Repositories
{
  public interface IReporteRepositorio
  {
    Task<List<ReporteDto>> obtenerReporte(int idCliente, DateTime fechaDesde, DateTime fechaHasta);
  }
}