using System;

namespace OrnaLibs.ConsoleUI.Abstractions
{
    /// <summary>
    /// Сборщик элемента пользовательского интерфейса
    /// </summary>
    /// <typeparam name="TChild">Реализация <see cref="Builder{TChild, TBase}"/></typeparam>
    /// <typeparam name="TBase">Реализация <see cref="Control"/></typeparam>
    public abstract class Builder<TChild, TBase>
        where TChild : Builder<TChild, TBase>
        where TBase : Control
    {
        /// <summary>
        /// Действие при отмене
        /// </summary>
        protected internal Action onCancel = () => { };
        /// <summary>
        /// Расположение элемента
        /// </summary>
        protected internal (int, int) position = (0, 0);

        /// <summary>
        /// Ссылка на текущую реализацию
        /// </summary>
        protected internal abstract TChild GetSelf();

        /// <summary>
        /// Сборка в элемент пользовательского интерфейса
        /// </summary>
        /// <returns>Готовый элемент пользовательского интерфейса</returns>
        public abstract TBase Build();

        /// <summary>
        /// Установка действия при отмене
        /// </summary>
        public TChild OnCancel(Action action)
        {
            onCancel += action;
            return GetSelf();
        }

        /// <summary>
        /// Установка расположения элемента
        /// </summary>
        /// <param name="x">Смещение вправо по количеству символов</param>
        /// <param name="y">Смещение вниз по количеству символов</param>
        public TChild Position(int x, int y)
        {
            position = (x, y);
            return GetSelf();
        }
    }
}
