using Integracao.Models.VOs; 
using System.Collections.Generic;

namespace Integracao.Models.Entities
{
    public class Empresa : BaseEntity<Empresa>
    {
        public string Nome { get; private set; }
        public CNPJ Cnpj { get; private set; }
        public virtual ICollection<Funcionario> Funcionarios { get; private set; }

        protected Empresa() { }
        public Empresa(string nome, CNPJ cnpj)
        {
            Nome = nome;
            Cnpj = cnpj;
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            if (funcionario.Validar())
                Funcionarios.Add(funcionario);
        }

        public override bool Validar()
        {
            return Cnpj.Validar() && Nome.Length < 30 && Nome.Length > 0;
        }
    }
}
