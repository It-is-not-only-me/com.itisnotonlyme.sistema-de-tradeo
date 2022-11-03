using System.Collections;
using UnityEngine;
using ItIsNotOnlyMe.SistemaDeTradeo;

[CreateAssetMenu(fileName = "Objeto", menuName = "Demo/Objeto")]
public class ObjetoSO : ScriptableObject, IObjeto
{
    [SerializeField] private string _nombre;

    [SerializeField] private float _valor;

    public string Nombre { get { return _nombre; } } 

    public IPromesa CrearPromesa()
    {
        return new Promesa(this);
    }
}
