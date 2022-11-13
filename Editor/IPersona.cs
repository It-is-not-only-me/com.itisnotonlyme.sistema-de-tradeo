namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IPersona
    {
        public void SaldarDeuda(IDeuda deuda);

        public void AgregarObjetos(IObjeto objeto);

        public IObjeto Exigir(IObjeto objeto);
    }
}