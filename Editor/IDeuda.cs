namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IDeuda
    {
        public bool EstaSaldada();

        public void Saldar(IObjeto objeto);
    }
}