namespace Maxject.Core.DependencyInjection
{
    public class MaxjectResolver
    {
        private MaxjectContainer _container;
        public MaxjectResolver(MaxjectContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.GetDependency<T>();
        }
    }
}
