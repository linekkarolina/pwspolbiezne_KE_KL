using PW.Data;
using System;
using System.ComponentModel;

namespace PW.Logic
{
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
        public abstract void CreateBalls(int amount);
        public abstract bool BallsCollide(Ball ball1, Ball ball2);
        public abstract void HandleCollision(ref Ball ball1, ref Ball ball2);
        public abstract IDisposable Subscribe(IObserver<IBall> observer);
    }
}
