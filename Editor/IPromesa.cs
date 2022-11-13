namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IPromesa : IObjeto
    {
        public IPersona Deudor();

        public IObjeto Exigir();
    }
}