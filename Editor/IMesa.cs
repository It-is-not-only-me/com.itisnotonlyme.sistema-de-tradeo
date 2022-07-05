namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IMesa
    {
        public bool PermiteEjecutarIntercambio();

        public void AgregarZona(IZona zona);

        public void Intercambiar();
    }
}
