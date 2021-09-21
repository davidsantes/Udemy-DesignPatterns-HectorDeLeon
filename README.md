# ¿Qué son los patrones de diseño?

Los patrones de diseño o design patterns, son una solucion general, reutilizable y aplicable a diferentes problemas de diseño de software. Se trata de plantillas que identifican problemas en el sistema y proporcionan soluciones apropiadas a problemas generales a los que se han enfrentado los desarrolladores durante un largo periodo de tiempo, a través de prueba y error.

## Tipos de patrones de diseño de software
Los patrones de diseño más utilizados se clasifican en tres categorías principales, cada patrón de diseño individual conforma un total de 23 patrones de diseño. Las tres categorías principales son:
* Patrones creacionales
* Patrones estructurales
* Patrones de comportamiento

## Patrones creacionales

Los patrones de creación proporcionan diversos mecanismos de creación de objetos, que aumentan la flexibilidad y la reutilización del código existente de una manera adecuada a la situación. Esto le da al programa más flexibilidad para decidir que objetos deben crearse para un caso de uso dado.

Estos son los patrones creacionales:
* Abstract Factory: en este patrón, una interfaz crea conjuntos o familias de objetos relacionados sin especificar el nombre de la clase.
* Builder Patterns: permite producir diferentes tipos y representaciones de un objeto utilizando el mismo código de construcción. Se utiliza para la creación etapa por etapa de un objeto complejo combinando objetos simples. La creación final de objetos depende de las etapas del proceso creativo, pero es independiente de otros objetos.
* Factory Method: proporciona una interfaz para crear objetos en una superclase, pero permite que las subclases alteren el tipo de objetos que se crearon. Proporciona instanciación de objetos implícita a través de interfaces comunes
* Prototype: permite copiar objetos existentes sin hacer que su código dependa de sus clases. Se utiliza para restringir las operaciones de memoria / base de datos manteniendo la modificación al mínimo utilizando copias de objetos.
* Singleton: este patrón de diseño restringe la creación de instancias de una clase a un único objeto. 

## Patrones estructurales

Facilitan soluciones y estándares eficientes con respecto a las composiciones de clase y las estructuras de objetos. El concepto de herencia se utiliza para componer interfaces y definir formas de componer objetos para obtener nuevas funcionalidades.

Estos son los patrones estructurales:
* Adapter: se utiliza para vincular dos interfaces que no son compatibles y utilizan sus funcionalidades. El adaptador permite que las clases trabajen juntas de otra manera que no podrían al ser interfaces incompatibles.
* Bridge: en este patrón hay una alteración estructural en las clases principales y de implementador de interfaz sin tener ningún efecto entre ellas. Estas dos clases pueden desarrollarse de manera independiente y solo se conectan utilizando una interfaz como puente.
* Composite: se usa para agrupar objetos como un solo objeto. Permite componer objetos en estructuras de árbol y luego trabajar con estas estructuras como si fueran objetos individuales.
* Decorator: restringe la alteración de la estructura del objeto mientras se le agrega una nueva funcionalidad. La clase inicial permanece inalterada mientras que una clase decorator proporciona capacidades adicionales.
* Facade: proporciona una interfaz simplificada para una biblioteca, un marco o cualquier otro conjunto complejo de clases.
* Flyweight: se usa para reducir el uso de memoria y mejorar el rendimiento al reducir la creación de objetos. El patrón busca objetos similares que ya existen para reutilizarlo en lugar de crear otros nuevos que sean similares.
* Proxy: se utiliza para crear objetos que pueden representar funciones de otras clases u objetos y la interfaz se utiliza para acceder a estas funcionalidades

## Patrones de comportamiento

El patrón de comportamiento se ocupa de la comunicación entre objetos de clase. Se utilizan para detectar la presencia de patrones de comunicación ya presentes y pueden manipular estos patrones.

Estos patrones de diseño están específicamente relacionados con la comunicación entre objetos.
* Chain of responsibility: el patrón de diseño Chain of Responsibility es un patrón de comportamiento que evita acoplar el emisor de una petición a su receptor dando a más de un objeto la posibilidad de responder a una petición.
* Command: convierte una solicitud en un objeto independiente que contiene toda la información sobre la solicitud. Esta transformación permite parametrizar métodos con diferentes solicitudes, retrasar o poner en cola la ejecución de una solicitud y respaldar operaciones que no se pueden deshacer.
* Interpreter: se utiliza para evaluar el lenguaje o la expresión al crear una interfaz que indique el contexto para la interpretación.
* Iterator: su utilidad es proporcionar acceso secuencial a un número de elementos presentes dentro de un objeto de colección sin realizar ningún intercambio de información relevante.
* Mediator: este patrón proporciona una comunicación fácil a través de su clase que permite la comunicación para varias clases.
* Memento: el patrón Memento permite recorrer elementos de una colección sin exponer su representación subyacente.
* Observer: permite definir un mecanismo de suscripción para notificar a varios objetos sobre cualquier evento que le suceda al objeto que está siendo observado.
* State: en el patrón state, el comportamiento de una clase varia con su estado y, por lo tanto, esta representado por el objeto de contexto.
* Strategy: permite definir una familia de algoritmos, poner cada uno de ellos en una clase separada y hacer que sus objetos sean intercambiables.
* Témplate método: se usa con componentes que tienen similitud donde se puede implementar una plantilla del código para probar ambos componentes. El código se puede cambiar con pequeñas modificaciones.
* Visitor: el propósito de un patrón Visitor es definir una nueva operación sin introducir las modificaciones a una estructura de objeto existente.

## Wiki

* [profile.es](https://profile.es/blog/patrones-de-diseño-de-software/)
* [refactoring.guru](https://refactoring.guru/es/design-patterns/classification)