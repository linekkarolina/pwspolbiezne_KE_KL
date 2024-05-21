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
                Ball newBall = new Ball(random.Next(100, 500 - 100), random.Next(100, 500 - 100), random.Next(15, 25));
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

                        if (BallsCollide(ball1, ball2))
                        {
                            HandleCollision(ref ball1, ref ball2);
                        }
                    }
                }

                await Task.Delay(25);
            }
        }

        public override bool BallsCollide(Ball ball1, Ball ball2)
        {
            Vector2 ball1Position = new Vector2(ball1.Left, ball1.Top);
            Vector2 ball2Position = new Vector2(ball2.Left, ball2.Top);

            if (ball1.Diameter / 2 + ball2.Diameter / 2 >= Vector2.Distance(ball1Position, ball2Position))
                return true;
            else
                return false;
        }

        public override void HandleCollision(ref Ball ball1, ref Ball ball2)
        {
            Vector2 collisionNormal = Vector2.Normalize(new Vector2(ball2.Left - ball1.Left, ball2.Top - ball1.Top));
            Vector2 relativeVelocity = ball2.Velocity - ball1.Velocity;
            float velocityAlongNormal = Vector2.Dot(relativeVelocity, collisionNormal);

            if (velocityAlongNormal > 0)
                return;

            float restitution = 1.0f;
            float impulseMagnitude = -(1 + restitution) * velocityAlongNormal;
            impulseMagnitude /= 1 / ball1.Mass + 1 / ball2.Mass;

            Vector2 impulse = impulseMagnitude * collisionNormal;

            ball1.Velocity -= impulse / ball1.Mass;
            ball2.Velocity += impulse / ball2.Mass;

            CorrectPositions(ref ball1, ref ball2);
        }

        private void CorrectPositions(ref Ball ball1, ref Ball ball2)
        {
            Vector2 collisionNormal = Vector2.Normalize(new Vector2(ball2.Left - ball1.Left, ball2.Top - ball1.Top));
            float overlap = ball1.Diameter / 2 + ball2.Diameter / 2 - Vector2.Distance(new Vector2(ball1.Left, ball1.Top), new Vector2(ball2.Left, ball2.Top));

            Vector2 correction = collisionNormal * overlap / 2;

            ball1.Left -= correction.X;
            ball1.Top -= correction.Y;
            ball2.Left += correction.X;
            ball2.Top += correction.Y;

            // Prevent balls from getting stuck by nudging them slightly apart
            ball1.Left += collisionNormal.X * 0.01f;
            ball1.Top += collisionNormal.Y * 0.01f;
            ball2.Left -= collisionNormal.X * 0.01f;
            ball2.Top -= collisionNormal.Y * 0.01f;
        }

        public override IDisposable Subscribe(IObserver<IBall> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }
    }
}
