﻿using System;

namespace OrnaLibs.ConsoleUI.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <typeparam name="TBase"></typeparam>
    public abstract class Builder<TChild, TBase>
        where TChild : Builder<TChild, TBase>
        where TBase : Control
    {
        protected internal Action onCancel = () => { };

        protected internal abstract TChild GetSelf();
        public abstract TBase Build();

        public TChild OnCancel(Action action)
        {
            onCancel += action;
            return GetSelf();
        }
    }
}
