using PW.Data;
using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PW.Data
{
    public class Ball : IBall
    {
        private float TopBackingField;
        private float LeftBackingField;
        private Random Random = new Random();
        public Vector2 Velocity;
        public float Speed;

        public Ball(float top, float left, float diameter)
        {
            TopBackingField = top;
            LeftBackingField = left;
            Diameter = diameter;
            Task.Run(() => Move());
            Velocity = new Vector2(((float)Random.NextDouble() - 0.5f) * 2, ((float)Random.NextDouble() - 0.5f) * 2);
            Speed = (float)Random.NextDouble() * 5.0f + 1;
        }

        public float Top
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

        public float Left
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

        public float Diameter { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task Move()
        {
            while (true)
            {
                Top += Velocity.Y * Speed;
                if (Top < 0 || Top > 500 - Diameter)
                    Velocity.Y *= -1;

                Left += Velocity.X * Speed;
                if (Left < 0 || Left > 500 - Diameter)
                    Velocity.X *= -1;

                await Task.Delay(25);
            }
        }
    }
}
