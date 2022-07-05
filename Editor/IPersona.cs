using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IPersona
    {
        public bool CriterioEvaluacion(List<IPromesa> promesas);
    }
}
