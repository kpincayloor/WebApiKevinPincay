using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiKevinPincay.Entities
{
  public class TipoCuenta
  {
    [Key]
    public int tipoCuentaId { get; set; }
    [Required]
    [Display(Name = "Nombre Tipo Cuenta")]
    [StringLength(20)]
    public string nombre { get; set; }
    public bool estado { get; set; }
    // public ICollection<Cuenta> Cuenta { get; set; }
    // public ICollection<Movimiento> Movimmiento { get; set; }
  }
}