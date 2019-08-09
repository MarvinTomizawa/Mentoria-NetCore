using System.ComponentModel.DataAnnotations;

namespace Integracao.Dto
{
    public class FuncionarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório!")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo de 150 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo EhHomeOffice é obrigatório!")]
        public bool EhHomeOffice { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório!")]
        [MaxLength(11, ErrorMessage = "Campo CPF com tamanho máximo de 11 caracteres!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Cargo é obrigatório!")]
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Campo Empresa é obrigatório!")]
        public int EmpresaId { get; set; }

        public bool Inativo { get; set; }
    }
}
