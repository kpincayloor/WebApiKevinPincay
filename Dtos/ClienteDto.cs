using WebApiKevinPincay.Entities;

namespace WebApiKevinPincay.Dtos
{
  public class ClienteDto : PersonaDto
  {
    public int clienteId { get; set; }
    public string contrasena { get; set; }
    public bool estado { get; set; }
  }
}