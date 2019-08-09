using System.ComponentModel.DataAnnotations;

namespace Integracao.Dto
{
    public class EmpresaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        [MaxLength(150, ErrorMessage = "Tamanho máximo de 150 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CNPJ é um campo obrigatório!")]
        [MaxLength(14, ErrorMessage = "Tamanho máximo de 14 caracteres!")]
        public string CNPJ { get; set; }
        
        public bool Inativo { get; set; }
    }
}
