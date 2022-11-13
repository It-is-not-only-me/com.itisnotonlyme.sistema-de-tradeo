namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IValor
    {
        public void Disminuir(IValor valor);

        public bool Positivo();
    }
}