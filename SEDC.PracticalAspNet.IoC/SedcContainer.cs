using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PracticalAspNet.IoC
{
    public class SedcContainer
    {
        private readonly ConcurrentDictionary<Type, Type> _registrations;
        private object sync = new object();

        public SedcContainer() => _registrations = new ConcurrentDictionary<Type, Type>();

        public void Register<TImplementation>()
        {
            Register<TImplementation, TImplementation>();
        }

        public void Register<TService, TImplementation>()
        {
            while (!_registrations.TryAdd(typeof(TService), typeof(TImplementation))) { }
        }

        public object GetInstance(Type serviceType)
        {
            var exists = _registrations.TryGetValue(serviceType, out Type implementationType);
            if (exists)
            {
                var constructors = implementationType.GetConstructors().ToList();
                if (constructors.Count > 1)
                    throw new Exception($"In type \"{implementationType.FullName}\" cannot have more than one constructors");
                var constructor = constructors.First();
                var constructorParameters = constructor.GetParameters().ToList();
                if (constructorParameters.Count == 0)
                    return Activator.CreateInstance(implementationType);
                else
                {
                    var newParameters = new List<object> { };
                    foreach (var constructorParameter in constructorParameters)
                    {
                        var newParameter = GetInstance(constructorParameter.ParameterType);
                        newParameters.Add(newParameter);
                    }
                    return Activator.CreateInstance(implementationType, newParameters);
                }
            }
            throw new Exception($"registration for type \"{serviceType.FullName}\"does not exist");
        }
    }
}
