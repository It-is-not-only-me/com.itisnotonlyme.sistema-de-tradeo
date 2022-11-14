# Documentacion
---

La estructura del sistema esta en 5 interfaces:
 * IPersona
 * IValor
 * IObjeto
 * IPromesa
 * IDeuda

### IPersona
---
Es la representacion de los participantes del intercambio, con la intencion de que haya mas de un tipo de persona involucrada en dicho intercambio.

Los metodos que tiene que implementar son
 * public void SaldarDeuda(IDeuda deuda)
 * public void AgregarObjetos(IObjeto objeto)
 * public IObjeto Exigir(IObjeto objeto)

##### SaldarDeuda
---
En esta funcion no necesariamente se tiene que saldar la deuda en cuestion, solo que es la situacion en donde la persona puede elegir saldarla.

##### AgregarObjetos
---
La persona tendra un inventario de objetos, por lo que se agregaran esos objetos por medio de este metodo.

##### Exigir
---
Al igual que SaldarDeuda no necesarimente se tiene que devolver un valor objeto, sino que es la posibilidad de devolver.

### IValor
---
Es la representacion de la cuantificacion del valor de los objetos, que puede ser un simple int como alguna expresion mucho mas compleja, por lo que lo unico que se exige los dos metodos de comparacion para valorar un objeto sobre otros.

### IObjeto
---
La idea de un objeto es simplemente es un elemento con un valor.

### IPromesa
---
La idea de promesa es que el personaje puede hacer una promesa de dar un objeto, esta promesa equivale a un objeto, y por lo tanto se puede tratar como tal. Lo que lo diferencia a un objeto es que se puede exigir el objeto prometido.

Esta interfaz tiene una implementacion ya hecha, por lo que se recomienda usar ese objeto.

### Deuda
---
La idea de deuda es similar a una promesa pero en vez de prometer un objeto, se estaria prometiendo cierta cantidad de valor, por lo que un conjunto de objetos puede saldar la deuda.

Esta interfaz tiene una implementacion ya hecha, por lo que se recomienda usar ese objeto.