using OrnaLibs.ConsoleUI.Abstractions.Result;
using System;
using System.Collections.Generic;

namespace OrnaLibs.ConsoleUI
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Selector<T> : Control<int>// IDisposable
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
            Console.SetCursorPosition(2, _value + 1);
            Console.Write(_items[_value].ToString());
            Console.SetCursorPosition(2, newPos + 1);
            (Console.BackgroundColor, Console.ForegroundColor) = (Console.ForegroundColor, Console.BackgroundColor);
            Console.Write(_items[newPos].ToString());
            _value = newPos;
            Console.ResetColor();
        }

        protected internal override void Render()
        {
            Console.Clear();
            Console.WriteLine($"{_title}: ");
            for (var i = 0; i < _items.Count; i++)
            {
                Console.Write("  ");
                if (i == 0)
                    (Console.BackgroundColor, Console.ForegroundColor) = (Console.ForegroundColor, Console.BackgroundColor);
                Console.WriteLine(_items[i].ToString());
                if (i == 0) Console.ResetColor();
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