using WebApiKevinPincay.Api.Dtos;
using WebApiKevinPincay.Api.Entities;

namespace WebApiKevinPincay.Api.Repositories
{
  public interface ICuentaRepositorio
  {
    Task<List<CuentaDto>> obtenerCuentas();
    Task<CuentaDto> obtenerCuenta(int id);
    Task<CuentaDto> agregarCuenta(Cuenta cuenta);
    Task<CuentaDto> actualizarCuenta(int id, Cuenta cuenta);
    Task<CuentaDto> eliminarCuenta(int id);
  }
}