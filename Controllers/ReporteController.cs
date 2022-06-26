using Microsoft.AspNetCore.Mvc;
using WebApiKevinPincay.Repositories;
using WebApiKevinPincay.Entities;
using WebApiKevinPincay.Dtos;

namespace WebApiKevinPincay.Controllers
{
  [ApiController]
  [Route("api/reportes")]
  public class ReporteController : ControllerBase
  {
    private readonly IReporteRepositorio repositorio;

    public ReporteController(IReporteRepositorio repositorio)
    {
      this.repositorio = repositorio;
    }

    [HttpGet("obtenerReporte")]
    public async Task<ActionResult<List<ReporteDto>>> obtenerReporte([FromQuery(Name = "idCliente")] int idCliente, [FromQuery(Name = "fechaDesde")] DateTime fechaDesde, [FromQuery(Name = "fechaHasta")] DateTime fechaHasta)
    {
      try
      {
        var respuesta = await this.repositorio.obtenerReporte(idCliente, fechaDesde, fechaHasta);
        if (respuesta is null)
        {
          return NotFound("No se encontraron datos.");
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