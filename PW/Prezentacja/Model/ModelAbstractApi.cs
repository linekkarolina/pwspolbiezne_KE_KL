using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PW.Model
{
    public interface IBall
    {
        double Top { get; }
        double Left { get; }
        double Diameter { get; }
    }

    public abstract class ModelAbstractApi
    {
        public List<Ball> Balls { get; } = new List<Ball>();

        public static ModelAbstractApi CreateApi()
        {
            Model model = new Model();
            return model;
        }

        public abstract void Start();
    }
}
