using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }
    class CustomerManager
    {
        private CrossCuttingConcersFacade _concers;
        public CustomerManager()
        {
            _concers = new CrossCuttingConcersFacade();
        }

        public void Save()
        {
            _concers.Caching.Cache();
            _concers.Authorize.CheckUser();
            _concers.Logging.Log();
            _concers.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcersFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;

        public CrossCuttingConcersFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation=new Validation();

        }
    }
}
