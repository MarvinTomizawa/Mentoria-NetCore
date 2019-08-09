
namespace Integracao.Models.Entities
{
    public abstract class BaseEntity<T>
    {
        public int Id { get; set; }
        public bool Inativo { get; protected set; }
        public void Inativar()
        {
            Inativo = true;
        }
        public void Ativar()
        {
            Inativo = false;
        }
        public abstract bool Validar();
    }
}
