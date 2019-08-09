using Integracao.Models.VOs;

namespace Integracao.Models.Entities
{
    public class Funcionario : BaseEntity<Funcionario>
    {
        public string Nome { get; private set; }
        public bool ÉHomeOffice { get; private set; }
        public CPF Cpf { get; private set; }
        public int CargoId { get; private set; }
        public int EmpresaId { get; private set; }
        public virtual Cargo Cargo { get; private set; }
        public virtual Empresa Empresa { get; private set; }
        
        protected Funcionario() { }

        public Funcionario(string nome, bool éHomeOffice, CPF cpf, Cargo cargo, Empresa empresa)
        {
            Nome = nome;
            ÉHomeOffice = éHomeOffice;
            Cpf = cpf;
            Cargo = cargo;
            Empresa = empresa;
        }

        public override bool Validar()
        {
            return
                Nome.Length > 0 && Nome.Length < 50 &&
                Cpf.Validar() &&
                Cargo != null &&
                Empresa != null &&
                Cargo.Validar() &&
                Empresa.Validar();
                
        }
    }
}
