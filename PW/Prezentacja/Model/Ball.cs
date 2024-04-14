using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace PW.Model
{
    public class Ball : IBall
    {
        private double TopBackingField;
        private double LeftBackingField;

        public Ball(double top, double left)
        {
            TopBackingField = top;
            LeftBackingField = left;
        }

        public double Top
        {
            get { return TopBackingField; }
            private set
            {
                if (TopBackingField == value)
                    return;
                TopBackingField = value;
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
            }
        }

        public double Diameter { get; internal set; }
    }
}
