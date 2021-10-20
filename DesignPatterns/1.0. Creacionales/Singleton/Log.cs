using System;
using System.IO;

namespace DesignPatterns._1._0._Creacionales.Singleton
{
    public class Log
    {
        private readonly static Log _instance = new Log();
        private readonly string _path = "log.txt";

        public static Log Instance
        {
            get
            {
                return _instance;
            }
        }

        private Log() { }

        public void Save(string message)
        {
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
