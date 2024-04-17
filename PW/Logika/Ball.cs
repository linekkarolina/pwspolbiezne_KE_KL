using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PW.Logic
{
    internal class Ball : IBall
    {
        private double TopBackingField;
        private double LeftBackingField;
        private Timer MoveTimer;
        private Random Random = new Random();
        private Vector2 Velocity;
        private float Speed;

        public Ball(double top, double left)
        {
            TopBackingField = top;
            LeftBackingField = left;
            MoveTimer = new Timer(Move, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(25));
            Velocity = new Vector2(((float)Random.NextDouble() - 0.5f) * 2, ((float)Random.NextDouble() - 0.5f) * 2);
            Speed = (float)Random.NextDouble() * 5.0f + 1;
        }

        public double Top
        {
            get { return TopBackingField; }
            private set
            {
                if (TopBackingField == value)
                    return;
                TopBackingField = value;
                RaisePropertyChanged();
            }
        }

        public double Left
        {
            get { return LeftBackingField; }
            private set
            {
                if (LeftBackingField == value)
                    return;
                LeftBackingField = value;
                RaisePropertyChanged();
            }
        }

        public double Diameter { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Move(object state)
        {
            if (state != null)
                throw new ArgumentOutOfRangeException(nameof(state));

            Top += Velocity.Y * Speed;
            if (Top < 0 || Top > 500 - Diameter)
                Velocity.Y *= -1;

            Left += Velocity.X * Speed;
            if (Left < 0 || Left > 500 - Diameter)
                Velocity.X *= -1;
        }
    }
}
