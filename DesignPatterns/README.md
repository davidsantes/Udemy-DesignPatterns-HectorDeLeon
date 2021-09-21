# ?Qu¨¦ son los patrones de diseno?

Los patrones de diseno o design patterns, son una solucion general, reutilizable y aplicable a diferentes problemas de diseno de software. Se trata de plantillas que identifican problemas en el sistema y proporcionan soluciones apropiadas a problemas generales a los que se han enfrentado los desarrolladores durante un largo periodo de tiempo, a traves de prueba y error.

## Tipos de patrones de diseno de sotware
Los patrones de diseno mas utilizados se clasifican en tres categorias principales, cada patron de diseno individual conforma un total de 23 patrones de diseno. Las tres categorias principales son:
* Patrones creacionales
* Patrones estructurales
* Patrones de comportamiento

## Patrones creacionales

Los patrones de creacion proporcionan diversos mecanismos de creacion de objetos, que aumentan la flexibilidad y la reutilizacion del codigo existente de una manera adecuada a la situacion. Esto le da al programa mas flexibilidad para decidir que objetos deben crearse para un caso de uso dado.

Estos son los patrones creacionales:
* Abstract Factory: en este patron, una interfaz crea conjuntos o familias de objetos relacionados sin especificar el nombre de la clase.
* Builder Patterns: permite producir diferentes tipos y representaciones de un objeto utilizando el mismo codigo de construccion. Se utiliza para la creacion etapa por etapa de un objeto complejo combinando objetos simples. La creacion final de objetos depende de las etapas del proceso creativo, pero es independiente de otros objetos.
* Factory Method: proporciona una interfaz para crear objetos en una superclase, pero permite que las subclases alteren el tipo de objetos que se crearon. Proporciona instanciacion de objetos implicita a traves de interfaces comunes
* Prototype: permite copiar objetos existentes sin hacer que su codigo dependa de sus clases. Se utiliza para restringir las operaciones de memoria / base de datos manteniendo la modificacion al minimo utilizando copias de objetos.
* Singleton: este patron de diseno restringe la creacion de instancias de una clase a un unico objeto. 

## Patrones estructurales

Facilitan soluciones y est¨¢ndares eficientes con respecto a las composiciones de clase y las estructuras de objetos. El concepto de herencia se utiliza para componer interfaces y definir formas de componer objetos para obtener nuevas funcionalidades.

Estos son los patrones estructurales:
* Adapter: se utiliza para vincular dos interfaces que no son compatibles y utilizan sus funcionalidades. El adaptador permite que las clases trabajen juntas de otra manera que no podrian al ser interfaces incompatibles.
* Bridge: en este patron hay una alteracion estructural en las clases principales y de implementador de interfaz sin tener ningun efecto entre ellas. Estas dos clases pueden desarrollarse de manera independiente y solo se conectan utilizando una interfaz como puente.
* Composite: se usa para agrupar objetos como un solo objeto. Permite componer objetos en estructuras de arbol y luego trabajar con estas estructuras como si fueran objetos individuales.
* Decorator: restringe la alteracion de la estructura del objeto mientras se le agrega una nueva funcionalidad. La clase inicial permanece inalterada mientras que una clase decorator proporciona capacidades adicionales.
* Facade: proporciona una interfaz simplificada para una biblioteca, un marco o cualquier otro conjunto complejo de clases.
* Flyweight: se usa para reducir el uso de memoria y mejorar el rendimiento al reducir la creacion de objetos. El patron busca objetos similares que ya existen para reutilizarlo en lugar de crear otros nuevos que sean similares.
* Proxy: se utiliza para crear objetos que pueden representar funciones de otras clases u objetos y la interfaz se utiliza para acceder a estas funcionalidades

## Patrones de comportamiento

El patron de comportamiento se ocupa de la comunicacion entre objetos de clase. Se utilizan para detectar la presencia de patrones de comunicacion ya presentes y pueden manipular estos patrones.

Estos patrones de diseno estan especificamente relacionados con la comunicacion entre objetos.
* Chain of responsibility: el patron de diseno Chain of Responsibility es un patron de comportamiento que evita acoplar el emisor de una peticion a su receptor dando a mas de un objeto la posibilidad de responder a una peticion.
* Command: convierte una solicitud en un objeto independiente que contiene toda la informacion sobre la solicitud. Esta transformacion permite parametrizar metodos con diferentes solicitudes, retrasar o poner en cola la ejecucion de una solicitud y respaldar operaciones que no se pueden deshacer.
* Interpreter: se utiliza para evaluar el lenguaje o la expresion al crear una interfaz que indique el contexto para la interpretacion.
* Iterator: su utilidad es proporcionar acceso secuencial a un numero de elementos presentes dentro de un objeto de coleccion sin realizar ningun intercambio de informacion relevante.
* Mediator: este patron proporciona una comunicacion facil a traves de su clase que permite la comunicacion para varias clases.
* Memento: el patron Memento permite recorrer elementos de una coleccion sin exponer su representacion subyacente.
* Observer: permite definir un mecanismo de suscripcion para notificar a varios objetos sobre cualquier evento que le suceda al objeto que esta siendo observado.
* State: en el patron state, el comportamiento de una clase varia con su estado y, por lo tanto, esta representado por el objeto de contexto.
* Strategy: permite definir una familia de algoritmos, poner cada uno de ellos en una clase separada y hacer que sus objetos sean intercambiables.
* Template method: se usa con componentes que tienen similitud donde se puede implementar una plantilla del codigo para probar ambos componentes. El codigo se puede cambiar con peque?as modificaciones.
* Visitor: el proposito de un patron Visitor es definir una nueva operacion sin introducir las modificaciones a una estructura de objeto existente.

## Wiki ??

* [profile.es](https://profile.es/blog/patrones-de-diseno-de-software/)
* [refactoring.guru](https://refactoring.guru/es/design-patterns/classification)