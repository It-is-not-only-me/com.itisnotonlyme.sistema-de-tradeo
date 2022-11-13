using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using ItIsNotOnlyMe.SistemaDeTradeo;

public class TradeoTest
{
    [Test]
    public void Test01PersonaSinObjetosNoPuedeSaldarDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IPersona persona = new PersonaQueIntentaPagarPrueba();

        persona.SaldarDeuda(deuda);

        Assert.IsFalse(deuda.EstaSaldada());
    }

    [Test]
    public void Test02PersonaConValorEquivalenteSaldaLaDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IObjeto monedas = new MonedaPrueba(valor);
        IPersona persona = new PersonaQueIntentaPagarPrueba(monedas);

        persona.SaldarDeuda(deuda);

        Assert.IsTrue(deuda.EstaSaldada());
    }

    [Test]
    public void Test03PersonaConMenosQueLaDeudaNoPuedeSaldarDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IObjeto monedas = new MonedaPrueba(new ValorPrueba(10));
        IPersona persona = new PersonaQueIntentaPagarPrueba(monedas);

        persona.SaldarDeuda(deuda);

        Assert.IsFalse(deuda.EstaSaldada());
    }

    [Test]
    public void Test04SePuedeUsarLaPromesaDeUnObjetoParaSaldarUnaDeuda()
    {
        IValor valor = new ValorPrueba(25);
        IDeuda deuda = new DeudaPrueba(valor);

        IObjeto monedas = new MonedaPrueba(valor);
        IPersona deudor = new PersonaQueIntentaPagarPrueba(monedas);
        IPromesa promesa = new PromesaPrueba(monedas, deudor);

        IPersona persona = new PersonaQueIntentaPagarPrueba(promesa);

        persona.SaldarDeuda(deuda);

        Assert.IsTrue(deuda.EstaSaldada());
    }

    [Test]
    public void Test05AUnaPersonaSeLeExigeLoPrometido()
    {
        IValor valor = new ValorPrueba(25);
        IObjeto monedas = new MonedaPrueba(valor);
        IPersona deudor = new PersonaQueIntentaPagarPrueba(monedas);

        IPromesa promesa = new PromesaPrueba(monedas, deudor);

        Assert.AreEqual(monedas, promesa.Exigir());
    }
}
