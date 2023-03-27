using System;
using System.Collections.Generic;

namespace AOPFramework.RealProxy.CustomerServiceRepoPattern
{
    internal class LoggerDecorator<T> : IRepository<T>
    {
        private readonly IRepository<T> _decorated;
        public LoggerDecorator(IRepository<T> decorated)
        {
            _decorated = decorated;
        }

        public void Add(T entity)
        {
            Log("Before Adding");
            _decorated.Add(entity);
            Log("End Adding");
        }

        public void Delete(T entity)
        {
            Log("Before Deleting");
            _decorated.Delete(entity);
            Log("End Deleting");
        }

        public IEnumerable<T> GetAll()
        {
            Log("Before Get ALL");
            var result = _decorated.GetAll();
            Log("End Get ALL");
            return result;
        }

        public T GetById(int id)
        {
            Log("Before Fetch");
            var result = _decorated.GetById(id);
            Log("End Fetch");
            return result;
        }

        public void Update(T entity)
        {
            Log("Before updating");
            _decorated.Update(entity);
            Log("End updating");
        }

        public void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }
    }
}
