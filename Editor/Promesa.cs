using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public class Promesa : IPromesa
    {
        private IPersona _deudor;
        private IObjeto _objetoPrometido;

        public Promesa(IObjeto objetoPrometido, IPersona deudor)
        {
            _deudor = deudor;
            _objetoPrometido = objetoPrometido;
        }

        public IObjeto Exigir() => _deudor.Exigir(_objetoPrometido);

        public IValor Valor() => _objetoPrometido.Valor();
    }
}