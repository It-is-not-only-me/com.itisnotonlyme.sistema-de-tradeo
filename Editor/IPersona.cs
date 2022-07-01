using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.SistemaDeTradeo
{
    public interface IPersona
    {
        public bool SacarObjeto(IObjeto objeto);

        public void AgregarObjeto(IObjeto objeto);
    }

    public class Persona : IPersona
    {
        private List<IObjeto> _objetos;

        public Persona(List<IObjeto> objetos)
        {
            _objetos = (objetos == null) ? new List<IObjeto>() : objetos;
        }

        public void AgregarObjeto(IObjeto objeto)
        {
            _objetos.Add(objeto);
        }

        public bool SacarObjeto(IObjeto objeto)
        {
            return _objetos.Remove(objeto);
        }
    }

    public interface IMesa
    {
        public void Proponer(IPersona persona, IPromesa promesa);

        public void VerificarPropuestas(IPersona persona);
    }

    public class Mesa : IMesa
    {
        private List<IZona> _zonas;
        private ICrearZonas _crearZonas;

        public Mesa(ICrearZonas crearZonas)
        {
            _zonas = new List<IZona>();
            _crearZonas = crearZonas;
        }

        public void Proponer(IPersona persona, IPromesa promesa)
        {
            if (PersonaTieneZona(persona))
                AgregarZona(persona);

            IZona zona = ZonaDePersona(persona);
            zona.AgregarPromesa(promesa);
        }

        public void VerificarPropuestas(IPersona persona)
        {


            throw new System.NotImplementedException();
        }

        private IZona ZonaDePersona(IPersona persona)
        {
            IZona zonaDePersona = null;

            foreach (IZona zona in _zonas)
                if (zona.Pertenece(persona))
                    zonaDePersona = zona;

            return zonaDePersona;
        }

        private void AgregarZona(IPersona persona)
        {
            IZona zonaNueva = _crearZonas.NuevaZona(persona);
            _zonas.Add(zonaNueva);
        }

        private bool PersonaTieneZona(IPersona persona)
        {
            bool encontrado = false;
            foreach (IZona zona in _zonas)
                encontrado |= zona.Pertenece(persona);
            return encontrado;
        }
    }

    public interface ICrearZonas
    {
        public IZona NuevaZona(IPersona persona);
    }

    public interface IZona
    {
        public bool Pertenece(IPersona persona);

        public void AgregarPromesa(IPromesa promesa);

        public void VerificarPropuesta(IPersona persona);
    }

    public interface IPromesa
    {

    }

    public interface IObjeto
    {

    }

    public interface IValor
    {

    }
}
