using AutoMapper;
using WebApiKevinPincay.Api.Dtos;
using WebApiKevinPincay.Api.Data;
using WebApiKevinPincay.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiKevinPincay.Api.Repositories
{
  public class CuentaRepositorio : ICuentaRepositorio
  {
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public CuentaRepositorio(ApplicationDbContext db, IMapper mapper)
    {
      _db = db;
      _mapper = mapper;
    }

    public async Task<List<CuentaDto>> obtenerCuentas()
    {
      try
      {
        var cuentas = await _db.Cuentas.Where(w => w.estado == true).Include(i => i.Cliente).Include(c => c.TipoCuenta).ToListAsync();
        if (cuentas is null)
        {
          return null;
        }

        var valorConsultado = _mapper.Map<List<Cuenta>, List<CuentaDto>>(cuentas);

        return valorConsultado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<CuentaDto> obtenerCuenta(int id)
    {
      try
      {
        var cuenta = await _db.Cuentas.Include(i => i.Cliente).Include(c => c.TipoCuenta).FirstOrDefaultAsync(x => x.cuentaId.Equals(id));
        if (cuenta is null)
        {
          return null;
        }
        var valorConsultado = _mapper.Map<Cuenta, CuentaDto>(cuenta);

        return valorConsultado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<CuentaDto> agregarCuenta(Cuenta cuenta)
    {
      try
      {
        await _db.Cuentas.AddAsync(cuenta);
        await _db.SaveChangesAsync();

        Movimiento movimiento = new Movimiento();
        movimiento.fecha = DateTime.Now;
        movimiento.valor = 0;
        movimiento.saldo = cuenta.saldoInicial;
        movimiento.clienteId = cuenta.clienteId;
        movimiento.cuentaId = cuenta.cuentaId;
        await _db.Movimientos.AddAsync(movimiento);
        await _db.SaveChangesAsync();

        var valorIngresado = _mapper.Map<Cuenta, CuentaDto>(cuenta);

        return valorIngresado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<CuentaDto> actualizarCuenta(int id, Cuenta cuenta)
    {
      try
      {
        var cuentaModificar = _db.Cuentas.Where(s => s.cuentaId == id).Include(i => i.Cliente).Include(c => c.TipoCuenta).FirstOrDefault<Cuenta>();
        if (cuentaModificar != null)
        {
          cuentaModificar.numeroCuenta = cuenta.numeroCuenta;
          cuentaModificar.tipoCuentaId = cuenta.tipoCuentaId;
          cuentaModificar.saldoInicial = cuenta.saldoInicial;
          cuentaModificar.estado = cuenta.estado;
          cuentaModificar.clienteId = cuenta.clienteId;          

          _db.Update(cuentaModificar);
          _db.SaveChanges();
        } else {
          return null;
        }

        var valorActualizado = _mapper.Map<Cuenta, CuentaDto>(cuenta);

        return valorActualizado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<CuentaDto> eliminarCuenta(int id)
    {
      try
      {
         var cuentaEliminar = _db.Cuentas.Where(s => s.cuentaId == id).Include(i => i.Cliente).Include(c => c.TipoCuenta).FirstOrDefault<Cuenta>();
        if (cuentaEliminar != null) 
        {
            cuentaEliminar.estado = false;

            _db.Update(cuentaEliminar);
            _db.SaveChanges();

        } else {
          return null;
        }

        var valorEliminado = _mapper.Map<Cuenta, CuentaDto>(cuentaEliminar);

        return valorEliminado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}