using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class ZonaTest
{
    private IPersona _personaBasica = new PersonaPrueba(1);

    private IPromesa _promesaSimple = new PromesaSumaPrueba(1);

    [Test]
    public void Test01ZonaSinVinculoAOtraZonaNoAcepta()
    {
        IZona zona = new Zona(_personaBasica);

        Assert.IsFalse(zona.CriterioEvaluacion());
    }

    [Test]
    public void Test02ZonaConVinculoLaPersonaNoAceptaPorLoQueLaZonaNoAcepta()
    {
        IZona zonaEvaluada = new Zona(_personaBasica);
        IZona zonaObjetivo = new Zona(_personaBasica);

        zonaEvaluada.ZonaPropuesta(zonaObjetivo);

        Assert.IsFalse(zonaEvaluada.CriterioEvaluacion());
    }

    [Test]
    public void Test03ZonaConVinculoLaPersonaAceptaPorLoQueLaZonaAcepta()
    {
        IZona zonaEvaluada = new Zona(_personaBasica);
        IZona zonaObjetivo = new Zona(_personaBasica);

        zonaObjetivo.AgregarPromesa(_promesaSimple);
        zonaObjetivo.AgregarPromesa(_promesaSimple);
        zonaEvaluada.ZonaPropuesta(zonaObjetivo);

        Assert.IsTrue(zonaEvaluada.CriterioEvaluacion());
    }
}
