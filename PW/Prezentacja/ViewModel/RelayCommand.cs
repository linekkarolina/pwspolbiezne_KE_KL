﻿using System;
using System.Windows.Input;

namespace PW.ViewModel
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            this.m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.m_CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.m_CanExecute == null)
                return true;
            if (parameter == null)
                return this.m_CanExecute();
            return this.m_CanExecute();
        }

        public virtual void Execute(object parameter)
        {
            this.m_Execute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private readonly Action<object> m_Execute;
        private readonly Func<bool> m_CanExecute;
    }
}
