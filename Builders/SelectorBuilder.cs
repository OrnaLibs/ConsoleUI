using OrnaLibs.ConsoleUI.Abstractions.Result;
using System.Collections.Generic;

namespace OrnaLibs.ConsoleUI.Builders
{
    public sealed class SelectorBuilder<T>: Builder<SelectorBuilder<T>, Selector<T>, int>
    {
        private string _title = "";
        private IEnumerable<T> _items;

        public SelectorBuilder<T> Title(string title)
        {
            _title = title;
            return this;
        }

        public SelectorBuilder<T> Items(IEnumerable<T> items)
        {
            _items = items;
            return this;
        }

        protected internal override SelectorBuilder<T> GetSelf() => this;

        public override Selector<T> Build()
        {
            var obj = new Selector<T>(_title, _items);
            obj.OnSubmit += onSubmit;
            obj.OnCancel += onCancel;
            return obj;
        }
    }
}