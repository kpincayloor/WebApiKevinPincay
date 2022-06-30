using WebApiKevinPincay.Api.Entities;

namespace WebApiKevinPincay.Api.Dtos
{
  public class MovimientoDto
  {
    public int movimientoId { get; set; }
    public DateTime fecha { get; set; }
    public decimal valor { get; set; }
    public decimal saldo { get; set; }
    public int clienteId { get; set; }
    public Cliente? Cliente { get; set; } 
    public int cuentaId { get; set; }
    public Cuenta? Cuenta { get; set; } 
    public bool estado { get; set; }
  }
}