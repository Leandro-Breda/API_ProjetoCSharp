namespace ProjetoAPI.Dominio.Exceptions
{
    public class ValorNegativoException : Exception
    {
        public ValorNegativoException(string message) : base(message)
        {
        }
    }
}
