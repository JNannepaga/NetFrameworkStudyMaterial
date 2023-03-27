using System;

namespace AOPFramework.CustomInterceptors
{
    public abstract class InterceptingHandler : IInterceptor
    {
        private IInterceptor _nextValidator;

        public void SetNext(IInterceptor nextValidator)
        {
            _nextValidator = nextValidator;
        }

        public virtual object Intercept<T, TResult>(Func<T, TResult> request, T reqParams)
        {
            if (_nextValidator != null)
                return _nextValidator.Execute(request, reqParams);

            return null;
        }
    }
}
