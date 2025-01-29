using System;

namespace OrnaLibs.ConsoleUI.Abstractions
{
    /// <summary>
    /// Абстракция элемента пользовательского интерфейса
    /// </summary>
    public abstract class Control : IDisposable
    {
        /// <summary>
        /// Действие при отмене
        /// </summary>
        protected internal Action OnCancel;
        /// <summary>
        /// Расположение элемента
        /// </summary>
        protected internal (int x, int y) Position;

        /// <summary>
        /// Показать элемент
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

        /// <summary>
        /// Отображение элемента
        /// </summary>
        protected internal abstract void Render();

        /// <summary>
        /// Действия при нажатии определённых клавиш
        /// </summary>
        /// <param name="key">Нажатая клавиша</param>
        protected internal abstract void OnPressed(ConsoleKeyInfo key);

        /// <summary>
        /// Освобждение объекта
        /// </summary>
        public void Dispose() => GC.SuppressFinalize(this);

        /// <summary>
        /// Вывод строки с настройкми
        /// </summary>
        /// <param name="text">Текст отображения</param>
        /// <param name="x">Смещение вправо по количеству символов</param>
        /// <param name="y">Смещение вниз по количеству символов</param>
        /// <param name="fgColor">Цвет символов</param>
        /// <param name="bgColor">Цвет фона</param>
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
