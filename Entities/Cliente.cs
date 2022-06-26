using System.ComponentModel.DataAnnotations;

namespace WebApiKevinPincay.Entities
{
  public class Cliente : Persona
  {
    [Key]
    public int clienteId { get; set; }
    [Required]
    [Display(Name = "Contraseña")]
    [StringLength(50)]
    public string contrasena { get; set; }
    public bool estado { get; set; }
  }
}