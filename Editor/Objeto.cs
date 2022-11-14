using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public class Objeto : IObjeto
    {
        protected IValor _valor;

        public Objeto(IValor valor)
        {
            _valor = valor;
        }

        public IValor Valor() => _valor;
    }
}