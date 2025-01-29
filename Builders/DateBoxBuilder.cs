using OrnaLibs.ConsoleUI.Abstractions.Result;
using System;

namespace OrnaLibs.ConsoleUI.Builders
{
    public class DateBoxBuilder : Builder<DateBoxBuilder, DateBox, DateTime>
    {
        private string _title = "";
        private DateTime? _date = null;

        protected internal override DateBoxBuilder GetSelf() => this;

        public DateBoxBuilder Title(string title)
        {
            _title = title;
            return GetSelf();
        }

        public DateBoxBuilder Date(DateTime date)
        {
            _date = date;
            return GetSelf();
        }

        public override DateBox Build() =>
            new DateBox(_title, _date)
            {
                OnCancel = onCancel,
                OnSubmit = onSubmit,
                Position = position
            };
    }
}
