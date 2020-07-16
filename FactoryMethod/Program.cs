using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }
    }

    public interface ILoggerFactory
    {
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
           Console.WriteLine("Logged With EdLogger");
        }
    }

    public class CustomerManager
    {
        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
        }
    }
}
