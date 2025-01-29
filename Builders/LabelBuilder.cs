using OrnaLibs.ConsoleUI.Abstractions;
using System;
using System.Text;

namespace OrnaLibs.ConsoleUI.Builders
{
    public sealed class LabelBuilder : Builder<LabelBuilder, Label>
    {
        private StringBuilder _text = new StringBuilder();
        private ConsoleColor _fg = Console.ForegroundColor;
        private ConsoleColor _bg = Console.BackgroundColor;

        protected internal override LabelBuilder GetSelf() => this;

        public LabelBuilder BackgroundColor(ConsoleColor color)
        {
            _bg = color;
            return GetSelf();
        }

        public LabelBuilder ForegroundColor(ConsoleColor color)
        {
            _fg = color;
            return GetSelf();
        }

        public LabelBuilder Text(string text)
        {
            _text.Append(text);
            return GetSelf();
        }

        public LabelBuilder Format(string key, object value)
        {
            _text.Replace($"{{{key}}}", value.ToString());
            return GetSelf();
        }

        public LabelBuilder Line(string text)
        {
            _text.AppendLine(text);
            return GetSelf();
        }

        public override Label Build() =>
            new Label(_text.ToString(), _bg, _fg)
            {
                OnCancel = onCancel,
                Position = position
            };
    }
}
