using System;

namespace OrnaLibs.ConsoleUI.Abstractions.Result
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <typeparam name="TBase"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class Builder<TChild, TBase, TResult> : Builder<TChild, TBase>
        where TChild : Builder<TChild, TBase, TResult>
        where TBase : Control<TResult>
    {
        protected internal Action<TResult> onSubmit = _ => { };

        public TChild OnSubmit(Action<TResult> action)
        {
            onSubmit += action;
            return GetSelf();
        }
    }
}
