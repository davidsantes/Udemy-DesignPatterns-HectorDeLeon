using System;
using System.IO;

namespace DesignPatternsInAsp.Tools
{
    /// <summary>
    /// Clase: Log que aplica el patrón Singleton y que escribe en un fichero de texto.
    /// Objetivo: Este patrón de diseño restringe la creación de instancias de una clase a un único objeto.
    /// Otros: al ser sealed, no se va a poder heredar, de esta manera evitamos malos usos.
    /// </summary>
    public sealed class Log
    {
        private static Log _instance = null;
        private readonly string _path;
        /// <summary>
        /// Para proteger a la clase de que se genere la primera vez dos veces porque se lancen dos hilos
        /// independientes
        /// </summary>
        private static object _protectLog = new object();

        public static Log GetInstance(string path)
        {
            //Sólo un hilo a la vez, otros estarían en espera
            lock(_protectLog)
            {
                if (_instance == null)
                {
                    _instance = new Log(path);
                }
            }

            return _instance;
        }

        private Log(string path) 
        {
            _path = path;
        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
