using WebApiKevinPincay.Api.Entities;

namespace WebApiKevinPincay.Api.Dtos
{
  public abstract class PersonaDto
  {
    public string nombre { get; set; }
    public string genero { get; set; }
    public int edad { get; set; }
    public string identificacion { get; set; }
    public string direccion { get; set; }
    public string telefono { get; set; }
  }
}