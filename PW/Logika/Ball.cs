using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PW.Logic
{
    public class Ball : IBall
    {
        private double TopBackingField;
        private double LeftBackingField;
        private Timer MoveTimer;
        private Random Random = new Random();
        public Vector2 Velocity;
        public float Speed;

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
            set
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
            set
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

            Ball thisBall = this;
            Logic.MoveBall(ref thisBall);
        }
    }
}
