using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKevinPincay.Entities
{
  public class Cuenta
  {
    [Key]
    public int cuentaId { get; set; }
    public int numeroCuenta { get; set; }
    public int tipoCuentaId { get; set; }
    [ForeignKey("tipoCuentaId")]
    public TipoCuenta? TipoCuenta { get; set; } 
    public decimal saldoInicial { get; set; }
    public bool estado { get; set; }
    public int clienteId { get; set; }
    [ForeignKey("clienteId")]
    public Cliente? Cliente { get; set; } 

  }
}