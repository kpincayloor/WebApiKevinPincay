using AutoMapper;
using WebApiKevinPincay.Api.Dtos;
using WebApiKevinPincay.Api.Data;
using WebApiKevinPincay.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiKevinPincay.Api.Repositories
{
  public class ReporteRepositorio : IReporteRepositorio
  {
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public ReporteRepositorio(ApplicationDbContext db, IMapper mapper)
    {
      _db = db;
      _mapper = mapper;
    }

    public async Task<List<ReporteDto>> obtenerReporte(int idCliente, DateTime fechaDesde, DateTime fechaHasta)
    {
      try
      {
        var reporte = await _db.Movimientos.Where(w => w.clienteId == idCliente && w.fecha.Date >= fechaDesde.Date && w.fecha.Date <= fechaHasta)
                                           .Include(i => i.Cliente).Include(x => x.Cuenta)
                                           .OrderBy(o => o.movimientoId)
                                           .Select(s => new ReporteDto {
                                              fecha = s.fecha,
                                              cliente = s.Cliente.nombre,
                                              numeroCuenta = s.Cuenta.numeroCuenta,
                                              tipo = s.Cuenta.TipoCuenta.nombre,
                                              saldoInicial = s.saldo,
                                              estado = s.Cuenta.estado,
                                              movimiento = s.valor,
                                              saldoDisponible = s.valor < 0 ? (s.saldo - -s.valor) : (s.saldo + s.valor)
                                           }).ToListAsync();  
        if (reporte is null)
        {
          return null;
        }

        //var valorConsultado = _mapper.Map<List<Cliente>, List<ClienteDto>>(clientes);

        return reporte;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}