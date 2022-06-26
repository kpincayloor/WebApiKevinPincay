using Microsoft.AspNetCore.Mvc;
using WebApiKevinPincay.Repositories;
using WebApiKevinPincay.Entities;
using WebApiKevinPincay.Dtos;

namespace WebApiKevinPincay.Controllers
{
  [ApiController]
  [Route("api/cuentas")]
  public class CuentaController : ControllerBase
  {
    private readonly ICuentaRepositorio repositorio;

    public CuentaController(ICuentaRepositorio repositorio)
    {
      this.repositorio = repositorio;
    }

    [HttpGet("obtenerCuentas")]
    public async Task<ActionResult<List<CuentaDto>>> obtenerCuentas()
    {
      try
      {
        var respuesta = await this.repositorio.obtenerCuentas();
        if (respuesta is null)
        {
          return NotFound("No se encontraron cuentas.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("obtenerCuenta/{id}")]
    public async Task<ActionResult<CuentaDto>> obtenerCuenta(int id)
    {
      try
      {
        var respuesta = await this.repositorio.obtenerCuenta(id);
        if (respuesta is null)
        {
          return NotFound("No se encontró la cuenta.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("agregarCuenta")]
    public async Task<ActionResult<CuentaDto>> agregarCuenta(Cuenta cuenta)
    {
      try
      {
        var respuesta = await this.repositorio.agregarCuenta(cuenta);
        if (respuesta is null)
        {
          return NotFound("Error al crear la cuenta.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("actualizarCuenta/{id}")]
    public async Task<ActionResult<CuentaDto>> actualizarCuenta(int id, [FromBody] Cuenta cuenta)
    {
      try
      {
        var respuesta = await this.repositorio.actualizarCuenta(id, cuenta);
        if (respuesta is null)
        {
          return NotFound("Error al actualizar la cuenta.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("eliminarCuenta/{id}")]
    public async Task<ActionResult<CuentaDto>> eliminarCuenta(int id)
    {
      try
      {
        var respuesta = await this.repositorio.eliminarCuenta(id);
        if (respuesta is null)
        {
          return NotFound("Error al eliminar la cuenta.");
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