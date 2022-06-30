using System.ComponentModel.DataAnnotations;

namespace WebApiKevinPincay.Api.Entities
{
  public abstract class Persona
  {
    [Required]
    [StringLength(50, ErrorMessage = "El nombre debe contener hasta 50 caracteres.")]
    [Display(Name = "Nombre")]
    public string nombre { get; set; }
    [Required]
    [Display(Name = "Genero")]
    [StringLength(20)]
    public string genero { get; set; }
    [Required]
    [Display(Name = "Edad")]
    public int edad { get; set; }
    [Required]
    [Display(Name = "Identificación")]
    [StringLength(20)]
    public string identificacion { get; set; }
    [Required]
    [Display(Name = "Dirección")]
    [StringLength(100)]
    public string direccion { get; set; }
    [Required]
    [Display(Name = "Teléfono")]
    [StringLength(20)]
    public string telefono { get; set; }
  }
}