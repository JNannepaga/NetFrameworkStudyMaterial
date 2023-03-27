
using System;

namespace AOPFramework.CustomInterceptors
{
    public interface IInterceptor
    {
        void SetNext(IInterceptor nextValidator);

        object Execute<T,TResult>(Func<T,TResult> request, T reqParams);
    }
}
