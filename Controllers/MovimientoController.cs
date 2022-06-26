using Microsoft.AspNetCore.Mvc;
using WebApiKevinPincay.Repositories;
using WebApiKevinPincay.Entities;
using WebApiKevinPincay.Dtos;

namespace WebApiKevinPincay.Controllers
{
  [ApiController]
  [Route("api/movimientos")]
  public class MovimientoController : ControllerBase
  {
    private readonly IMovimientoRepositorio repositorio;

    public MovimientoController(IMovimientoRepositorio repositorio)
    {
      this.repositorio = repositorio;
    }

    [HttpGet("obtenerMovimientos")]
    public async Task<ActionResult<List<MovimientoDto>>> obtenerMovimientos()
    {
      try
      {
        var respuesta = await this.repositorio.obtenerMovimientos();
        if (respuesta is null)
        {
          return NotFound("No se encontraron movimientos.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("obtenerMovimiento/{id}")]
    public async Task<ActionResult<MovimientoDto>> obtenerMovimiento(int id)
    {
      try
      {
        var respuesta = await this.repositorio.obtenerMovimiento(id);
        if (respuesta is null)
        {
          return NotFound("No se encontró el movimiento.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost("agregarMovimiento")]
    public async Task<ActionResult<MovimientoDto>> agregarMovimiento(Movimiento movimiento)
    {
      try
      {
        var respuesta = await this.repositorio.agregarMovimiento(movimiento);
        if (respuesta is null)
        {
          return NotFound("Error al crear el movimiento.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut("actualizarMovimiento/{id}")]
    public async Task<ActionResult<MovimientoDto>> actualizarMovimiento(int id, [FromBody] Movimiento movimiento)
    {
      try
      {
        var respuesta = await this.repositorio.actualizarMovimiento(id, movimiento);
        if (respuesta is null)
        {
          return NotFound("Error al actualizar el movimiento.");
        }
        return Ok(respuesta);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("eliminarMovimiento/{id}")]
    public async Task<ActionResult<MovimientoDto>> eliminarMovimiento(int id)
    {
      try
      {
        var respuesta = await this.repositorio.eliminarMovimiento(id);
        if (respuesta is null)
        {
          return NotFound("Error al eliminar el movimiento.");
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