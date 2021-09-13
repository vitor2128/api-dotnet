using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "O login não pode estar vazio")]
    public string Login { get; set; }

    [Required(ErrorMessage = "A senha não pode estar vazia")]
    public string Password { get; set; }
  }
}