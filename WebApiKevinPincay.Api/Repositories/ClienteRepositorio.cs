using AutoMapper;
using System.Threading.Tasks;
using WebApiKevinPincay.Api.Dtos;
using WebApiKevinPincay.Api.Data;
using WebApiKevinPincay.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiKevinPincay.Api.Repositories
{
  public class ClienteRepositorio : IClienteRepositorio
  {
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public ClienteRepositorio(ApplicationDbContext db, IMapper mapper)
    {
      _db = db;
      _mapper = mapper;
    }

    public async Task<List<ClienteDto>> obtenerClientes()
    {
      try
      {
        var clientes = await _db.Clientes.Where(w => w.estado == true).ToListAsync();
        if (clientes is null)
        {
          return null;
        }

        var valorConsultado = _mapper.Map<List<Cliente>, List<ClienteDto>>(clientes);

        return valorConsultado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<Cliente> obtenerCliente(int id)
    {
      try
      {
        //var cliente = await _db.Clientes.FirstOrDefaultAsync(x => x.clienteId.Equals(id));
        var cliente = _db.Clientes.Where(item => item.clienteId == id).SingleOrDefault();
        // if (cliente is null)
        // {
        //   return null;
        // }
        //ClienteDto clienteDto = new ClienteDto();
        //clienteDto = _mapper.Map<Cliente, ClienteDto>(cliente);

        return await Task.FromResult(cliente);
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<ClienteDto> agregarCliente(Cliente cliente)
    {
      try
      {
        await _db.Clientes.AddAsync(cliente);
        await _db.SaveChangesAsync();

        var valorIngresado = _mapper.Map<Cliente, ClienteDto>(cliente);

        return valorIngresado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<ClienteDto> actualizarCliente(int id, Cliente cliente)
    {
      try
      {
        var clienteModificar = _db.Clientes.Where(s => s.clienteId == id).FirstOrDefault<Cliente>();
        if (clienteModificar != null)
        {
          clienteModificar.nombre = cliente.nombre;
          clienteModificar.identificacion = cliente.identificacion;
          clienteModificar.contrasena = cliente.contrasena;
          clienteModificar.direccion = cliente.direccion;
          clienteModificar.edad = cliente.edad;
          clienteModificar.estado = cliente.estado;
          clienteModificar.genero = cliente.genero;
          clienteModificar.telefono = cliente.telefono;

          _db.Update(clienteModificar);
          _db.SaveChanges();
        } else {
          return null;
        }

        var valorActualizado = _mapper.Map<Cliente, ClienteDto>(cliente);

        return valorActualizado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    public async Task<ClienteDto> eliminarCliente(int id)
    {
      try
      {
         var clienteEliminar = _db.Clientes.Where(s => s.clienteId == id).FirstOrDefault<Cliente>();
        if (clienteEliminar != null) 
        {
            clienteEliminar.estado = false;

            _db.Update(clienteEliminar);
            _db.SaveChanges();
            
        } else {
          return null;
        }

        var valorEliminado = _mapper.Map<Cliente, ClienteDto>(clienteEliminar);

        return valorEliminado;
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}