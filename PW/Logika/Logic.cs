using System;
using PW.Data;
using System.Reactive;
using System.Reactive.Linq;

namespace PW.Logic
{
    public class Logic : LogicAbstractApi
    {
        private DataAbstractApi DataLayer;
        public event EventHandler<BallChangedEventArgs> BallChanged;
        private IObservable<EventPattern<BallChangedEventArgs>> eventObservable = null;

        public Logic()
        {
            eventObservable = Observable.FromEventPattern<BallChangedEventArgs>(this, "BallChanged");
        }

        public override void Start()
        {
            DataLayer = DataAbstractApi.CreateApi();
        }

        public override void CreateBalls(int amount)
        {
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                Ball newBall = new Ball(random.Next(100, 500 - 100), random.Next(100, 500 - 100)) { Diameter = 20 };
                BallChanged?.Invoke(this, new BallChangedEventArgs() { Ball = newBall });
            }
        }

        public static void MoveBall(ref Ball ball)
        {
            ball.Top += ball.Velocity.Y * ball.Speed;
            if (ball.Top < 0 || ball.Top > 500 - ball.Diameter)
                ball.Velocity.Y *= -1;

            ball.Left += ball.Velocity.X * ball.Speed;
            if (ball.Left < 0 || ball.Left > 500 - ball.Diameter)
                ball.Velocity.X *= -1;
        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }
    }
}
