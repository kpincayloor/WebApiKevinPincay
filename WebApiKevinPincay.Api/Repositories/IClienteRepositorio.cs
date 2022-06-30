using WebApiKevinPincay.Api.Dtos;
using WebApiKevinPincay.Api.Entities;

namespace WebApiKevinPincay.Api.Repositories
{
  public interface IClienteRepositorio
  {
    Task<List<ClienteDto>> obtenerClientes();
    Task<Cliente> obtenerCliente(int id);
    Task<ClienteDto> agregarCliente(Cliente cliente);
    Task<ClienteDto> actualizarCliente(int id, Cliente cliente);
    Task<ClienteDto> eliminarCliente(int id);
  }
}