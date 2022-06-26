using AutoMapper;
using WebApiKevinPincay.Dtos;
using WebApiKevinPincay.Data;
using WebApiKevinPincay.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace WebApiKevinPincay.Repositories
{
  public class MovimientoRepositorio : IMovimientoRepositorio
  {
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;
    private IMapper _mapper;

    public MovimientoRepositorio(ApplicationDbContext db, IMapper mapper, IConfiguration configuration)
    {
      _db = db;
      _mapper = mapper;
      _configuration = configuration;
    }

    public async Task<List<MovimientoDto>> obtenerMovimientos()
    {
      try
      {
        var movimientos = await _db.Movimientos.Include(i => i.Cliente).Include(c => c.Cuenta).ToListAsync();
        if (movimientos is null)
        {
          return null;
        }

        var valorConsultado = _mapper.Map<List<Movimiento>, List<MovimientoDto>>(movimientos);

        return valorConsultado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<MovimientoDto> obtenerMovimiento(int id)
    {
      try
      {
        var movimiento = await _db.Movimientos.Include(i => i.Cliente).Include(c => c.Cuenta).FirstOrDefaultAsync(x => x.movimientoId.Equals(id));
        if (movimiento is null)
        {
          return null;
        }
        var valorConsultado = _mapper.Map<Movimiento, MovimientoDto>(movimiento);

        return valorConsultado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<string> agregarMovimiento(Movimiento movimiento)
    {
      try
      {

        if (await validaCuenta(movimiento.cuentaId, movimiento.clienteId) == false)
        {
          return "La cuenta no existe.";
        }

        var saldo = consultaSaldoInicial(movimiento.cuentaId, movimiento.clienteId);
        var valorPositivo = movimiento.valor < 0 ? -movimiento.valor : movimiento.valor;
        if (movimiento.valor < 0)
        {
          if (movimiento.valor > saldo)
          {
            return "Saldo no disponible.";
          }
          var totalDiario = consultaLimiteDiario(movimiento.cuentaId, movimiento.clienteId);
          if (totalDiario)
          {
            return "Cupo diario excedido.";
          }
        }

        decimal valorActualizado = 0;
        if (movimiento.valor < 0)
        {
          valorActualizado = (saldo - valorPositivo);
        }
        else
        {
          valorActualizado = (saldo + valorPositivo);
        }

        var cuentaActualizar = _db.Cuentas.Where(s => s.cuentaId == movimiento.cuentaId && s.clienteId == movimiento.clienteId).Include(i => i.Cliente).Include(c => c.TipoCuenta).FirstOrDefault<Cuenta>();
        if (cuentaActualizar is null)
        {
          return "No se actualizó el valor de la cuenta.";
        }
        else
        {
          cuentaActualizar.saldoInicial = valorActualizado;

          _db.Update(cuentaActualizar);
          _db.SaveChanges();
        }

        movimiento.saldo = valorActualizado;
        await _db.Movimientos.AddAsync(movimiento);
        await _db.SaveChangesAsync();

        return "Movimiento creado exitosamente.";
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public async Task<MovimientoDto> actualizarMovimiento(int id, Movimiento movimiento)
    {
      try
      {
        var movimientoModificar = _db.Movimientos.Where(s => s.movimientoId == id).Include(i => i.Cliente).Include(c => c.Cuenta).FirstOrDefault<Movimiento>();
        if (movimientoModificar != null)
        {
          movimientoModificar.fecha = movimiento.fecha;
          movimientoModificar.valor = movimiento.valor;
          movimientoModificar.saldo = movimiento.saldo;
          movimientoModificar.clienteId = movimiento.clienteId;
          movimientoModificar.cuentaId = movimiento.cuentaId;

          _db.Update(movimientoModificar);
          _db.SaveChanges();
        }
        else
        {
          return null;
        }

        var valorActualizado = _mapper.Map<Movimiento, MovimientoDto>(movimiento);

        return valorActualizado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<MovimientoDto> eliminarMovimiento(int id)
    {
      try
      {
        var movimientoEliminar = _db.Movimientos.Where(s => s.movimientoId == id).Include(i => i.Cliente).Include(c => c.Cuenta).FirstOrDefault<Movimiento>();
        if (movimientoEliminar != null)
        {
            movimientoEliminar.estado = false;

            _db.Update(movimientoEliminar);
            _db.SaveChanges();
        }
        else
        {
          return null;
        }

        var valorEliminado = _mapper.Map<Movimiento, MovimientoDto>(movimientoEliminar);

        return valorEliminado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    private decimal consultaSaldoInicial(int idCuenta, int idCliente)
    {
      var saldoInicial = _db.Cuentas.Where(w => w.cuentaId == idCuenta && w.clienteId == idCliente).Select(s => s.saldoInicial).FirstOrDefault();
      return saldoInicial;
    }

    private bool consultaLimiteDiario(int idCuenta, int idCliente)
    {
      var valorLimiteDiario = Convert.ToDecimal(_configuration.GetSection("AppSettings:montoLimiteDiario").Value);
      var total = _db.Movimientos.Where(w => w.valor < 0 && w.fecha.Date.Equals(DateTime.Now.Date) && w.cuentaId == idCuenta && w.clienteId == idCliente).Sum(i => i.valor);
      var valorPositivo = total < 0 ? -total : total;
      if (valorPositivo >= valorLimiteDiario)
      {
        return true;
      }
      return false;
    }

    public async Task<bool> validaCuenta(int idCuenta, int idCliente)
    {
      var existe = await _db.Cuentas.Where(x => x.cuentaId.Equals(idCuenta) && x.clienteId == idCliente).FirstOrDefaultAsync();
      if (existe is null)
      {
        return false;
      }
      return true;
    }
  }
}