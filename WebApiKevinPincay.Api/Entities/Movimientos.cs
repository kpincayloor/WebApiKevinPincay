using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKevinPincay.Api.Entities
{
  public class Movimiento
  {
    [Key]
    public int movimientoId { get; set; }
    public DateTime fecha { get; set; }
    public decimal valor { get; set; }
    public decimal? saldo { get; set; }
    public int clienteId { get; set; }
    [ForeignKey("clienteId")]
    public Cliente? Cliente { get; set; } 
    public int cuentaId { get; set; }
    [ForeignKey("cuentaId")]
    public Cuenta? Cuenta { get; set; } 
    public bool estado { get; set; }
  }
}