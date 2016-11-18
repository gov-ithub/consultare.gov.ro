using System;
namespace Ng2Net.Infrastructure.Services
{
    public static class ServiceFactory
    {
        public static TService Create<TService, TRepository>()
            where TRepository : class, new()
        {
            return (TService)Activator.CreateInstance(typeof(TService), new TRepository());
        }

        public static TService Create<TService, TRepository, TRepository1>()
            where TRepository : class, new()
            where TRepository1 : class, new()
        {
            return (TService)Activator.CreateInstance(typeof(TService), new TRepository(), new TRepository1());
        }

        public static TService Create<TService, TRepository, TRepository1, TRepository2>()
            where TRepository : class, new()
            where TRepository1 : class, new()
            where TRepository2 : class, new()
        {
            return (TService)Activator.CreateInstance(typeof(TService), new TRepository(), new TRepository1(), new TRepository2());
        }

        public static TService Create<TService, TRepository, TRepository1, TRepository2, TRepository3>()
            where TRepository : class, new()
            where TRepository1 : class, new()
            where TRepository2 : class, new()
            where TRepository3 : class, new()
        {
            return (TService)Activator.CreateInstance(typeof(TService), new TRepository(), new TRepository1(), new TRepository2(), new TRepository3());
        }

    }
}