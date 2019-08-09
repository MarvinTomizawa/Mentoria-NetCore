using System.Collections.Generic;

namespace Integracao.Models.Entities
{
    public class Cargo : BaseEntity<Cargo>
    {
        public string Descricao { get; private set; }
        public virtual List<Funcionario> Funcionarios { get; private set; }

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }

        public override bool Validar()
        {
            return Descricao.Length < 20 && Descricao.Length > 0;
        }
    }
}
