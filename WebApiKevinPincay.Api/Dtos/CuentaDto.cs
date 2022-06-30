using WebApiKevinPincay.Api.Entities;

namespace WebApiKevinPincay.Api.Dtos
{
  public class CuentaDto
  {
    public int cuentaId { get; set; }
    public int numeroCuenta { get; set; }
    public int tipoCuentaId { get; set; }
    public TipoCuenta? TipoCuenta { get; set; } 
    public decimal saldoInicial { get; set; }
    public bool estado { get; set; }
    public int clienteId { get; set; }
    public Cliente? Cliente { get; set; }
  }
}