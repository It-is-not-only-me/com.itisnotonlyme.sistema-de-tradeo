namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IPersona
    {
        public void Recibir(IObjeto objeto);

        public void Recibir(IPromesa promesa);

        public IObjeto Exigir(IPromesa promesa);
    }
}