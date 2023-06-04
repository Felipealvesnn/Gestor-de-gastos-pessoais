using System.ComponentModel.DataAnnotations;

namespace Gestor_de_gastos_pessoais.VieswsModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
