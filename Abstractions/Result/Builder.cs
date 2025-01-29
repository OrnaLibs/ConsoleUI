using System;

namespace OrnaLibs.ConsoleUI.Abstractions.Result
{
    /// <summary>
    /// Сборщик элемента пользовательского интерфейса
    /// </summary>
    /// <typeparam name="TChild">Реализация <see cref="Builder{TChild, TBase, TResult}"/></typeparam>
    /// <typeparam name="TBase">Реализация <see cref="Control{TResult}"/></typeparam>
    /// <typeparam name="TResult">Тип вывода TBase</typeparam>
    public abstract class Builder<TChild, TBase, TResult> : Builder<TChild, TBase>
        where TChild : Builder<TChild, TBase, TResult>
        where TBase : Control<TResult>
    {
        /// <summary>
        /// Действие при нажатии Enter
        /// </summary>
        protected internal Action<TResult> onSubmit = _ => { };

        /// <summary>
        /// Установка действия при нажатии Enter
        /// </summary>
        public TChild OnSubmit(Action<TResult> action)
        {
            onSubmit += action;
            return GetSelf();
        }
    }
}
