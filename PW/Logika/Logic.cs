using System;
using PW.Data;
using System.Reactive;
using System.Reactive.Linq;
using System.Numerics;
using System.Threading.Tasks;

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
                Ball newBall = new Ball(random.Next(100, 500 - 100), random.Next(100, 500 - 100), 20);
                BallChanged?.Invoke(this, new BallChangedEventArgs() { Ball = newBall });
                DataLayer.balls.Add(newBall);
            }
            Task.Run(() => CheckCollisions());
        }

        public async Task CheckCollisions()
        {
            while (true)
            {
                for (int i = 0; i < DataLayer.balls.Count; ++i)
                {
                    for (int j = i + 1; j < DataLayer.balls.Count; ++j)
                    {
                        Ball ball1 = DataLayer.balls[i];
                        Ball ball2 = DataLayer.balls[j];

                        Vector2 ball1Position = new Vector2(ball1.Left, ball1.Top);
                        Vector2 ball2Position = new Vector2(ball2.Left, ball2.Top);

                        if (ball1.Diameter / 2 + ball2.Diameter / 2  >=  Vector2.Distance(ball1Position, ball2Position))
                            HandleCollision(ref ball1, ref ball2);
                    }
                }

                await Task.Delay(25);
            }
        }

        public override void HandleCollision(ref Ball ball1, ref Ball ball2)
        {

        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }
    }
}
