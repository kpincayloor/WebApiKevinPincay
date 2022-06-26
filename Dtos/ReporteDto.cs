using WebApiKevinPincay.Entities;

namespace WebApiKevinPincay.Dtos
{
  public class ReporteDto
  {
    public DateTime fecha { get; set; }
    public string cliente { get; set; }
    public int numeroCuenta { get; set; }
    public string tipo { get; set; }
    public decimal? saldoInicial { get; set; }
    public bool estado { get; set; }
    public decimal movimiento { get; set; }
    public decimal? saldoDisponible { get; set; }
  }
}