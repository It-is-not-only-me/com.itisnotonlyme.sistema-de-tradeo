# Documentacion
---

La estructura del sistema esta en cuatro interfaces:
 * IMesa
 * IZona
 * IPersona
 * IPromesa

Las ultimas dos no tienen implementación concreta ya que es lo que va a variar completamente en el contexto que se implemente.

### IMesa
---
Es la clase que se encarga de administrar la organizacion de los intercambios. Tiene la idea de zonas, que veremos a continuación, pero que le permite interpretar de quien es cada promesa y con quien se esta intercambiando.

### IZona
---
Es la estructura que se encarga de saber quien promete que, y a quien se lo esta prometiendo. 

### IPersona
---
Tiene la responsabilidad de evaluar si las promesas que propone la otra persona son suficientes para hacer el intercambio. Tambien tiene la responsabilidad de aceptar todos las promesas que la otra persona prometio, cuando se ejecuta el intercambio.

### IPromesa
---
Inicialmente tenia pensado que IPromesa tenga un objeto y un precio, pero eso lo limitaba en sus aplicaciones, por lo que no tiene implementacion (aparte de la implementación para las pruebas). 
Esta interfaz esta complemtamente vacia para que se pueda hacer lo que se quiera con esta, se puede pensar como yo anteriormente mencione pero no se esta limitado a esta.