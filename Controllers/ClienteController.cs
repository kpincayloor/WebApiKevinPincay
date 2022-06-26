using Microsoft.AspNetCore.Mvc;
using WebApiKevinPincay.Repositories;
using WebApiKevinPincay.Entities;
using WebApiKevinPincay.Dtos;

namespace WebApiKevinPincay.Controllers
{
  [ApiController]
  [Route("api/clientes")]
  public class ClienteController : ControllerBase
  {
    private readonly IClienteRepositorio repositorio;

    public ClienteController(IClienteRepositorio repositorio)
    {
      this.repositorio = repositorio;
    }

    [HttpGet("obtenerClientes")]
    public async Task<ActionResult<List<ClienteDto>>> obtenerClientes()
    {
      try
      {
        var respuesta = await this.repositorio.obtenerClientes();
        if (respuesta is null)
        {
          return NotFound("No se encontraron clientes.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("obtenerCliente/{id}")]
    public async Task<ActionResult<ClienteDto>> obtenerCliente(int id)
    {
      try
      {
        var respuesta = await this.repositorio.obtenerCliente(id);
        if (respuesta is null)
        {
          return NotFound("No se encontró el cliente.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("agregarCliente")]
    public async Task<ActionResult<ClienteDto>> agregarCliente(Cliente cliente)
    {
      try
      {
        var respuesta = await this.repositorio.agregarCliente(cliente);
        if (respuesta is null)
        {
          return NotFound("Error al crear el cliente.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("actualizarCliente/{id}")]
    public async Task<ActionResult<ClienteDto>> actualizarCliente(int id, [FromBody] Cliente cliente)
    {
      try
      {
        var respuesta = await this.repositorio.actualizarCliente(id, cliente);
        if (respuesta is null)
        {
          return NotFound("Error al actualizar el cliente.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("eliminarCliente/{id}")]
    public async Task<ActionResult<ClienteDto>> eliminarCliente(int id)
    {
      try
      {
        var respuesta = await this.repositorio.eliminarCliente(id);
        if (respuesta is null)
        {
          return NotFound("Error al eliminar el cliente.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}