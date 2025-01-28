using System;

namespace OrnaLibs.ConsoleUI.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Control : IDisposable
    {
        protected internal Action OnCancel;

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
    }
}
