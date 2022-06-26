using WebApiKevinPincay.Dtos;
using WebApiKevinPincay.Entities;

namespace WebApiKevinPincay.Repositories
{
  public interface IClienteRepositorio
  {
    Task<List<ClienteDto>> obtenerClientes();
    Task<ClienteDto> obtenerCliente(int id);
    Task<ClienteDto> agregarCliente(Cliente cliente);
    Task<ClienteDto> actualizarCliente(int id, Cliente cliente);
    Task<ClienteDto> eliminarCliente(int id);
  }
}