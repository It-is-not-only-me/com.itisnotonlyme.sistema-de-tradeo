using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public class Deuda : IDeuda
    {
        protected IValor _valorASaldar;
        private Action<IObjeto> _agregaObjeto;
        private List<IValor> _valorAgregado;

        public Deuda(IValor valorASaldar, Action<IObjeto> agregaObjeto = null)
        {
            _valorASaldar = valorASaldar;
            _valorAgregado = new List<IValor>();
            _agregaObjeto = agregaObjeto;
        }

        public bool EstaSaldada() => !_valorASaldar.ValorMayor(_valorAgregado);

        public void Saldar(IObjeto objeto)
        {
            if (objeto == null)
                return;

            _valorAgregado.Add(objeto.Valor());
            _agregaObjeto?.Invoke(objeto);
        }
    }
}
