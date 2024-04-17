using System;
using System.ComponentModel;

namespace PW.Logic
{
    public interface IBall : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        double Diameter { get; }
    }

    public class BallChangedEventArgs : EventArgs
    {
        public IBall Ball { get; internal set; }
    }

    public abstract class LogicAbstractApi : IObservable<IBall>
    {
        public static LogicAbstractApi CreateApi()
        {
            Logic logic = new Logic();
            return logic;
        }

        public abstract void Start();
        public abstract void CreateBalls();
        public abstract IDisposable Subscribe(IObserver<IBall> observer);
    }
}
