namespace DesignPatterns._1._0._Creacionales.Singleton
{
    /// <summary>
    /// Clase: Definición teórica del objeto.
    /// Objetivo: Este patrón de diseño restringe la creación de instancias de una clase a un único objeto.
    /// </summary>
    public class SingletonDefinition
    {
        private readonly static SingletonDefinition _instance = new SingletonDefinition();

        public static SingletonDefinition Instance {
            get
            {
                return _instance;
            }
        }

        private SingletonDefinition() { }
    }
}
