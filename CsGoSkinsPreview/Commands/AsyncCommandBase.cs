using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsGoSkinsPreview.Commands
{
    public abstract class AsyncCommandBase<T1, T2> : ICommand
    {

        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting && (typeof(T1) == typeof(EmptyArgument) || parameter is T1);
        }

        public async void Execute(object parameter)
        {
            if (typeof(T1) == typeof(EmptyArgument))
                parameter = new EmptyArgument();
            if (parameter is T1 param)
            {
                IsExecuting = true;

                var res = await ExecuteAsync(param);
                IsExecuting = false;
            }
            else
                throw new ArgumentException($"Passed parameter of type {parameter.GetType()} is not supported by this method. You need to pass object of type {typeof(T1)}.");

        }

        public abstract Task<T2> ExecuteAsync(T1 parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }

    public class EmptyArgument
    {

    }
}
