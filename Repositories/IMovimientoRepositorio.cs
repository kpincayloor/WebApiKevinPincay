using WebApiKevinPincay.Dtos;
using WebApiKevinPincay.Entities;

namespace WebApiKevinPincay.Repositories
{
  public interface IMovimientoRepositorio
  {
    Task<List<MovimientoDto>> obtenerMovimientos();
    Task<MovimientoDto> obtenerMovimiento(int id);
    Task<string> agregarMovimiento(Movimiento movimiento);
    Task<MovimientoDto> actualizarMovimiento(int id, Movimiento movimiento);
    Task<MovimientoDto> eliminarMovimiento(int id);
  }
}