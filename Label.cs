using OrnaLibs.ConsoleUI.Abstractions;
using System;

namespace OrnaLibs.ConsoleUI
{
    public sealed class Label : Control
    {
        private string _text;
        private ConsoleColor _background;
        private ConsoleColor _foreground;

        internal Label(string text, ConsoleColor bgColor, ConsoleColor fgColor)
        {
            _text = text;
            _background = bgColor;
            _foreground = fgColor;
        }

        protected internal override void OnPressed(ConsoleKeyInfo key) { }

        protected internal override void Render()
        {
            Console.Clear();
            var lines = _text.Split('\n');
            for (var i = 0; i < lines.Length; i++)
                Write(lines[i], Position.x, Position.y + i, _foreground, _background);
        }
    }
}
