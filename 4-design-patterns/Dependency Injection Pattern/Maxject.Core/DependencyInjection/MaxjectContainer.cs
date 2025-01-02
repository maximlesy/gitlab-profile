using Maxject.Core.DependencyInjection.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maxject.Core.DependencyInjection
{
    public class MaxjectContainer
    {
        //Dictionary<Interface, Class>
        protected Dictionary<Type, Type> _dependencies;

        public MaxjectContainer()
        {
            _dependencies = new Dictionary<Type, Type>();
        }

        public void Register<TInterface, TClass>() where TClass : TInterface
        {
            _dependencies.Add(typeof(TInterface), typeof(TClass));
        }

        public T GetDependency<T>()
        {
            return (T)FetchDependency(typeof(T));
        }

        private object FetchDependency(Type type)
        {
            if (_dependencies.ContainsKey(type))
            {
                var constructors = _dependencies[type].GetConstructors();
                if (constructors.Length == 0) return Activator.CreateInstance(_dependencies[type]);

                // When using D.I. we should only have one ctor else, we'll throw an error here
                var constructor = constructors.Single();
                var parameters = constructor.GetParameters().ToArray();

                var implementations = new object[parameters.Length];

                //does it have a ctor?
                if (parameters.Length > 0)
                {
                    for (int i = 0; i < implementations.Length; i++)
                    {

                        var abstraction = _dependencies.FirstOrDefault(type => type.Value == _dependencies[parameters[i].ParameterType]).Key;
                        implementations[i] = FetchDependency(abstraction);
                    }
                }

                return Activator.CreateInstance(_dependencies[type], implementations);
            }
            else
            {
                throw new DependencyNotImplementedException("Dependency could not be found. Have you registered it?");
            }
        }
    }
}
