using System.ComponentModel.DataAnnotations;

namespace Integracao.Dto
{
    public class FuncionarioViewDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public bool EhHomeOffice { get; set; }
        public string Cpf { get; set; }
        public CargoDto Cargo { get; set; }
        public EmpresaDto Empresa { get; set; }
        public bool Inativo { get; set; }
    }
}
