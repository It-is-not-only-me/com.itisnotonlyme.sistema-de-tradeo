using System.Collections.Generic;
using ItIsNotOnlyMe.SistemaDeTradeo;
using UnityEngine;

public class PersonaBehaviour : MonoBehaviour, IPersona
{
    [SerializeField] private List<IObjeto> _objetos = new List<IObjeto>();

    private Persona _persona;

    private void Awake()
    {
        _persona = new Persona(_objetos);
    }

    public IObjeto Exigir(IPromesa promesa) => _persona.Exigir(promesa);

    public void Recibir(IObjeto objeto) => _persona.Recibir(objeto);

    public void Recibir(IPromesa promesa) => _persona.Recibir(promesa);
}