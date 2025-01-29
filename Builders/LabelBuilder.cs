using OrnaLibs.ConsoleUI.Abstractions;
using System;
using System.Text;

namespace OrnaLibs.ConsoleUI.Builders
{
    /// <summary>
    /// Сборщик <see cref="Label"/>
    /// </summary>
    public sealed class LabelBuilder : Builder<LabelBuilder, Label>
    {
        private StringBuilder _text = new StringBuilder();
        private ConsoleColor _fg = Console.ForegroundColor;
        private ConsoleColor _bg = Console.BackgroundColor;

        protected internal override LabelBuilder GetSelf() => this;

        /// <summary>
        /// Установка цвета фона
        /// </summary>
        public LabelBuilder BackgroundColor(ConsoleColor color)
        {
            _bg = color;
            return GetSelf();
        }

        /// <summary>
        /// Установка цвета символов
        /// </summary>
        public LabelBuilder ForegroundColor(ConsoleColor color)
        {
            _fg = color;
            return GetSelf();
        }

        /// <summary>
        /// Добавление текста
        /// </summary>
        public LabelBuilder Text(string text)
        {
            _text.Append(text);
            return GetSelf();
        }

        /// <summary>
        /// Форматирование всего текста
        /// </summary>
        public LabelBuilder Format(string key, object value)
        {
            _text.Replace($"{{{key}}}", value.ToString());
            return GetSelf();
        }

        /// <summary>
        /// Добавление строки
        /// </summary>
        public LabelBuilder Line(string text)
        {
            _text.AppendLine(text);
            return GetSelf();
        }

        /// <summary>
        /// Сборка <see cref="Label"/>
        /// </summary>
        public override Label Build() =>
            new Label(_text.ToString(), _bg, _fg)
            {
                OnCancel = onCancel,
                Position = position
            };
    }
}
