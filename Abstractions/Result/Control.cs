using System;

namespace OrnaLibs.ConsoleUI.Abstractions.Result
{
    /// <summary>
    /// Абстракция элемента пользовательского интерфейса с выводом при нажатии Enter
    /// </summary>
    /// <typeparam name="TResult">Тип вывода</typeparam>
    public abstract class Control<TResult> : Control
    {
        /// <summary>
        /// Действие при нажатии Enter
        /// </summary>
        protected internal Action<TResult> OnSubmit;
        /// <summary>
        /// Итоговое/текущее значение
        /// </summary>
        protected internal TResult _value;

        /// <summary>
        /// Показать элемент
        /// </summary>
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
