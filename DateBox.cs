using OrnaLibs.ConsoleUI.Abstractions.Result;
using System;
using System.Globalization;

namespace OrnaLibs.ConsoleUI
{
    /// <summary>
    /// Элемент ввода даты
    /// </summary>
    public class DateBox : Control<DateTime>
    {
        private readonly char[] _date;
        private int index = 0;
        private readonly string _title;

        internal DateBox(string title, DateTime? date = null)
        {
            _title = title;
            var d = (date ?? DateTime.MinValue);
            var _d = d.ToString("yyyyMMdd");
            _date = (date ?? DateTime.MinValue).ToString("yyyyMMdd").ToCharArray();
        }

        protected internal override void OnPressed(ConsoleKeyInfo key)
        {
            if((key.Key >= ConsoleKey.NumPad0 && key.Key <= ConsoleKey.NumPad9 ||
                key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) && index <= 7)
            {
                var temp = _date[index];
                _date[index] = key.KeyChar;
                if (CheckFormat(string.Concat(_date)))
                {
                    index++;
                    RenderDate();
                }
                else
                {
                    _date[index] = temp;
                }
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                index--;
                RenderDate();
            }
            if(key.Key == ConsoleKey.RightArrow)
            {
                index++;
                RenderDate();
            }
            if (key.Key == ConsoleKey.Enter) 
                _value = DateTime.ParseExact(string.Concat(_date), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
        
        private bool CheckFormat(string date) =>
            DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);

        private void RenderDate()
        {
            for(var i = 0; i < 8; i++)
            {
                Write(
                    $"{_date[i]}", Position.x + i + (i < 4 ? 2 : i < 6 ? 3 : 4), Position.y + 1,
                    i == index ? Console.BackgroundColor : Console.ForegroundColor,
                    i == index ? Console.ForegroundColor : Console.BackgroundColor);
            }
        }

        protected internal override void Render()
        {
            Console.Clear();
            Write($"{_title}: ", Position.x, Position.y);
            Write("[", Position.x + 1, Position.y + 1);
            Write("-", Position.x + 6, Position.y + 1);
            Write("-", Position.x + 9, Position.y + 1);
            Write("]", Position.x + 12, Position.y + 1);
            RenderDate();
        }
    }
}
