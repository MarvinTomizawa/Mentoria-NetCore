using System.ComponentModel.DataAnnotations;

namespace Integracao.Dto
{
    public class CargoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres!")]
        public string Descricao { get; set; }

        public bool Inativo { get; set; }
    }
}
