namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IZona
    {
        public void AgregarPromesa(IPromesa promesa);

        public void ZonaPropuesta(IZona zona);

        public bool CriterioEvaluacion();

        public bool CriterioEvaluacion(IPersona evaluador);
    }
}
