namespace Integracao.Models.VOs
{
    public class CPF
    {
        public string Numero { get; private set; }

        public CPF(string numero)
        {
            this.Numero = numero;
        }

        public bool Validar()
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string TempCPF;

            string Digito;

            int soma;

            int resto;
            
            if (Numero.Length != 11)
                return false;

            TempCPF = Numero.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();

            TempCPF = TempCPF + Digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return Numero.EndsWith(Digito);
        }

        public override string ToString()
        {
            return this.Numero;
        }
    }
}
