using System;

namespace OrnaLibs.ConsoleUI.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Control : IDisposable
    {
        protected internal Action OnCancel;
        protected internal (int x, int y) Position;

        /// <summary>
        /// 
        /// </summary>
        public virtual void Show()
        {
            Render();

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                OnPressed(key);
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            OnCancel.Invoke();
            Dispose();
        }

        protected internal abstract void Render();

        protected internal abstract void OnPressed(ConsoleKeyInfo key);

        public void Dispose() => GC.SuppressFinalize(this);
        protected internal void Write(string text, int x, int y, ConsoleColor? fgColor = null, ConsoleColor? bgColor = null)
        {
            Console.SetCursorPosition(x, y);
            if(!(fgColor is null)) Console.ForegroundColor = fgColor.Value;
            if(!(bgColor is null)) Console.BackgroundColor = bgColor.Value;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
