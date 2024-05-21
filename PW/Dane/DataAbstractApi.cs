using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PW.Data
{
    public interface IBall : INotifyPropertyChanged
    {
        float Top { get; }
        float Left { get; }
        float Diameter { get; }
    }

    public abstract class DataAbstractApi
    {
        public List<Ball> balls = new List<Ball>();

        public static DataAbstractApi CreateApi()
        {
            Data logic = new Data();
            return logic;
        }
    }
}
