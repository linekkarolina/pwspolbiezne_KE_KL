using System;
using System.Collections.Generic;
using PW.Model;

namespace PW.ViewModel
{
    public class ViewModel
    {
        private ModelAbstractApi ModelLayer;
        public List<Ball> Balls { get; } = new List<Ball>();

        public ViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            ModelLayer.Start();
            foreach (var ball in ModelLayer.Balls)
            {
                Balls.Add(new Ball(ball.Top, ball.Left));
            }
        }
    }
}
