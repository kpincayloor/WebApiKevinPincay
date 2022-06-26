using WebApiKevinPincay.Dtos;

namespace WebApiKevinPincay.Repositories
{
  public interface IReporteRepositorio
  {
    Task<List<ReporteDto>> obtenerReporte(int idCliente, DateTime fechaDesde, DateTime fechaHasta);
  }
}