using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class TradeoTest
{
    private IPersona _personaBasica = new PersonaPrueba(1);

    private IPromesa _promesaSimple = new PromesaSumaPrueba(2);

    [Test]
    public void Test01NoSePuedeEjecutarIntercambioSiNoHayPersonasParaIntercambiar()
    {
        IMesa mesa = new Mesa();

        Assert.IsFalse(mesa.PermiteEjecutarIntercambio());
    }

    [Test]
    public void Test02MesaConUnaZonaNoPermiteEjecutarIntercambio()
    {
        IMesa mesa = new Mesa();
        IZona zona = new Zona(_personaBasica);

        mesa.AgregarZona(zona);

        Assert.IsFalse(mesa.PermiteEjecutarIntercambio());
    }

    [Test]
    public void Test03MesaConDosZonasVinculadasPeroNingunoAceptaNoPermiteEjecutrarIntercambio()
    {
        IMesa mesa = new Mesa();
        IZona zona1 = new Zona(_personaBasica);
        IZona zona2 = new Zona(_personaBasica);

        zona2.ZonaPropuesta(zona1);
        zona1.ZonaPropuesta(zona2);

        mesa.AgregarZona(zona1);
        mesa.AgregarZona(zona2);

        Assert.IsFalse(mesa.PermiteEjecutarIntercambio());
    }

    [Test]
    public void Test04MesaConDosZonasVinculadasSoloUnaAceptaNoPermiteEjecutrarIntercambio()
    {
        IMesa mesa = new Mesa();
        IZona zona1 = new Zona(_personaBasica);
        IZona zona2 = new Zona(_personaBasica);

        zona2.AgregarPromesa(_promesaSimple);

        zona2.ZonaPropuesta(zona1);
        zona1.ZonaPropuesta(zona2);

        mesa.AgregarZona(zona1);
        mesa.AgregarZona(zona2);

        Assert.IsTrue(zona1.CriterioEvaluacion());
        Assert.IsFalse(mesa.PermiteEjecutarIntercambio());
    }

    [Test]
    public void Test05MesaConDosZonasVinculadasLasDosAceptaPermiteEjecutrarIntercambio()
    {
        IMesa mesa = new Mesa();
        IZona zona1 = new Zona(_personaBasica);
        IZona zona2 = new Zona(_personaBasica);

        zona1.AgregarPromesa(_promesaSimple);
        zona2.AgregarPromesa(_promesaSimple);

        zona2.ZonaPropuesta(zona1);
        zona1.ZonaPropuesta(zona2);

        mesa.AgregarZona(zona1);
        mesa.AgregarZona(zona2);

        Assert.IsTrue(mesa.PermiteEjecutarIntercambio());
    }

    [Test]
    public void Test06MesaAlEjecutarElIntercambioLasPersonasTienenLoPrometido()
    {
        IMesa mesa = new Mesa();

        PersonaPrueba personaBasica1 = new PersonaPrueba(1);
        PersonaPrueba personaBasica2 = new PersonaPrueba(1);

        IZona zona1 = new Zona(personaBasica1);
        IZona zona2 = new Zona(personaBasica2);

        int prometidoAPersona1 = 2, prometidoAPersona2 = 4;

        zona1.AgregarPromesa(_promesaSimple);
        zona1.AgregarPromesa(_promesaSimple);
        zona2.AgregarPromesa(_promesaSimple);

        zona2.ZonaPropuesta(zona1);
        zona1.ZonaPropuesta(zona2);

        mesa.AgregarZona(zona1);
        mesa.AgregarZona(zona2);

        mesa.Intercambiar();

        Assert.AreEqual(prometidoAPersona1, personaBasica1.InteresAcumulado());
        Assert.AreEqual(prometidoAPersona2, personaBasica2.InteresAcumulado());
    }
}
