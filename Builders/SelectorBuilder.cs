using OrnaLibs.ConsoleUI.Abstractions.Result;
using System.Collections.Generic;

namespace OrnaLibs.ConsoleUI.Builders
{
    /// <summary>
    /// Сборщик <see cref="Selector{T}"/>
    /// </summary>
    public sealed class SelectorBuilder<T>: Builder<SelectorBuilder<T>, Selector<T>, int>
    {
        private string _title = "";
        private IEnumerable<T> _items;

        /// <summary>
        /// Установка заголовка
        /// </summary>
        public SelectorBuilder<T> Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// Установка элементов
        /// </summary>
        public SelectorBuilder<T> Items(IEnumerable<T> items)
        {
            _items = items;
            return this;
        }

        protected internal override SelectorBuilder<T> GetSelf() => this;

        /// <summary>
        /// Сборка <see cref="Selector{T}"/>
        /// </summary>
        public override Selector<T> Build()
        {
            var obj = new Selector<T>(_title, _items)
            {
                OnSubmit = onSubmit,
                OnCancel = onCancel,
                Position = position
            };
            return obj;
        }
    }
}