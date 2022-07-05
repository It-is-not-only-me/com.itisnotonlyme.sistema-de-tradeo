using System.Collections.Generic;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public class Mesa : IMesa
    {
        private List<IZona> _zonas;

        public Mesa()
        {
            _zonas = new List<IZona>();
        }

        public void AgregarZona(IZona zona)
        {
            _zonas.Add(zona);
        }

        public bool PermiteEjecutarIntercambio()
        {
            if (_zonas.Count == 0)
                return false;
            return _zonas.TrueForAll(zona => zona.CriterioEvaluacion());   
        }
    }
}
