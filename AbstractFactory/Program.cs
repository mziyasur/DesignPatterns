﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager=new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();

        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }

    public class NLogger:Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);

    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }

    public abstract class CrossCuttingConcernsFactorty
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactorty
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
            
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactorty
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();

        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class ProductManager
    {
        private CrossCuttingConcernsFactorty _crossCuttingConcernsFactorty;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactorty crossCuttingConcernsFactorty)
        {
            _crossCuttingConcernsFactorty = crossCuttingConcernsFactorty;
            _logging = _crossCuttingConcernsFactorty.CreateLogger();
            _caching = _crossCuttingConcernsFactorty.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products Listed!");
        }

    }
}
