using System.Collections.Generic;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public class Zona : IZona
    {
        private List<IPromesa> _promesas;
        private IPersona _persona;
        private IZona _zona;

        public Zona(IPersona persona)
        {
            _persona = persona;
            _promesas = new List<IPromesa>();
        }

        public void AgregarPromesa(IPromesa promesa)
        {
            _promesas.Add(promesa);
        }

        public bool CriterioEvaluacion()
        {
            if (_zona == null)
                return false;
            return _zona.CriterioEvaluacion(_persona);
        }

        public bool CriterioEvaluacion(IPersona evaluador)
        {
            return evaluador.CriterioEvaluacion(_promesas);
        }

        public void Intercambiar()
        {
            _zona.Intercambiar(_persona);
        }

        public void Intercambiar(IPersona persona)
        {
            persona.Recibir(_promesas);
        }

        public void ZonaPropuesta(IZona zona)
        {
            _zona = zona;
        }
    }
}
