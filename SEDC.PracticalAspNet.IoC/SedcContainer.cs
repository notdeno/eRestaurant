using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace SEDC.PracticalAspNet.IoC
{
    public class SedcContainer
    {
        private readonly Assembly _controllersAssebly;
        private readonly ConcurrentDictionary<Type, Type> _registrations;
        private object sync = new object();
        private ConcurrentBag<Type> controllerTypes = new ConcurrentBag<Type>();

        public SedcContainer(Assembly controllersAssebly)
        {
            _controllersAssebly = controllersAssebly;
            _registrations = new ConcurrentDictionary<Type, Type>();
            GetControllerTypes().ForEach(t => controllerTypes.Add(t));
            foreach (var controllerType in controllerTypes)
            {
                Register(controllerType);
            }
        }

        public Controller GetController(string controllerName)
        {
            var controllerType = controllerTypes.FirstOrDefault(x => x.Name.Substring(0, x.Name.Length - 10) == controllerName);
            if (controllerType == null)
                throw new Exception($"no controller found with name \"{controllerName}\"");
            var controllerInstance = GetInstance(controllerType);
            return controllerInstance as Controller;
        }

        public void Register(Type implementationType)
        {
            Register(implementationType, implementationType);
        }

        public void Register(Type serviceType, Type implementationType)
        {
            while (!_registrations.TryAdd(serviceType, implementationType)) { }
        }

        public void Register<TImplementation>()
        {
            Register<TImplementation, TImplementation>();
        }

        public void Register<TService, TImplementation>()
        {
            Register(typeof(TService), typeof(TImplementation));
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
                    return Activator.CreateInstance(implementationType, newParameters.ToArray());
                }
            }
            
            throw new Exception($"registration for type \"{serviceType.FullName}\"does not exist");
        }

        private List<Type> GetControllerTypes()
        {
            var controllerTypes = new List<Type>();

            _controllersAssebly.GetExportedTypes().ToList().ForEach(t =>
            {
                if (typeof(IController).IsAssignableFrom(t))
                {
                    controllerTypes.Add(t);
                }
            });

            return controllerTypes;
        }
    }

}
