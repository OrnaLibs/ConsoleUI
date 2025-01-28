using System;

namespace OrnaLibs.ConsoleUI.Abstractions.Result
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class Control<TResult> : Control
    {
        protected internal Action<TResult> OnSubmit;
        protected internal TResult _value;

        public override void Show()
        {
            Render();

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                OnPressed(key);
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.Enter)
                OnSubmit.Invoke(_value);
            if (key.Key == ConsoleKey.Escape)
                OnCancel.Invoke();
            Dispose();
        }
    }
}
