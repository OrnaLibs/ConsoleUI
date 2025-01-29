using OrnaLibs.ConsoleUI.Abstractions.Result;
using System;
using System.Collections.Generic;

namespace OrnaLibs.ConsoleUI
{
    /// <summary>
    /// Элемент выбора элемента
    /// </summary>
    public sealed class Selector<T> : Control<int>
    {
        private readonly string _title;
        private readonly List<T> _items;

        internal Selector(string title, IEnumerable<T> items)
        {
            _title = title;
            _items = new List<T>(items);
        }

        private void RenderCursor(int newPos)
        {
            if (_value == newPos || newPos < 0 || newPos >= _items.Count) return;
            Console.SetCursorPosition(Position.x + 2, Position.y + _value + 1);
            Console.Write(_items[_value].ToString());
            Console.SetCursorPosition(Position.x + 2, Position.y + newPos + 1);
            (Console.BackgroundColor, Console.ForegroundColor) = (Console.ForegroundColor, Console.BackgroundColor);
            Console.Write(_items[newPos].ToString());
            _value = newPos;
            Console.ResetColor();
        }

        protected internal override void Render()
        {
            Console.Clear();
            Write($"{_title}: ", Position.x, Position.y);
            for (var i = 0; i < _items.Count; i++)
            {
                Write(
                    _items[i].ToString(), Position.x + 2, Position.y + i + 1,
                    i == 0 ? Console.BackgroundColor : Console.ForegroundColor,
                    i == 0 ? Console.ForegroundColor : Console.BackgroundColor);
            }
        }

        protected internal override void OnPressed(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow) // DownArrow - Пункт ниже
                RenderCursor(_value + 1);
            if (key.Key == ConsoleKey.UpArrow) // UpArrow - Пункт выше
                RenderCursor(_value - 1);
            if (key.Key == ConsoleKey.PageDown) // PageDown - Последний пункт
                RenderCursor(_items.Count - 1);
            if (key.Key == ConsoleKey.PageUp) // PageUp - Первый пункт 
                RenderCursor(0);
        }
    }
}