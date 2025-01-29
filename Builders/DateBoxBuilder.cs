using OrnaLibs.ConsoleUI.Abstractions.Result;
using System;

namespace OrnaLibs.ConsoleUI.Builders
{
    /// <summary>
    /// Сборщик <see cref="DateBox"/>
    /// </summary>
    public class DateBoxBuilder : Builder<DateBoxBuilder, DateBox, DateTime>
    {
        private string _title = "";
        private DateTime? _date = null;

        protected internal override DateBoxBuilder GetSelf() => this;

        /// <summary>
        /// Установка заголовка
        /// </summary>
        public DateBoxBuilder Title(string title)
        {
            _title = title;
            return GetSelf();
        }

        /// <summary>
        /// Установка начальной даты
        /// </summary>
        public DateBoxBuilder Date(DateTime date)
        {
            _date = date;
            return GetSelf();
        }

        /// <summary>
        /// Сборка <see cref="DateBox"/>
        /// </summary>
        public override DateBox Build() =>
            new DateBox(_title, _date)
            {
                OnCancel = onCancel,
                OnSubmit = onSubmit,
                Position = position
            };
    }
}
