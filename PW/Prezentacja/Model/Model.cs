using System;
using PW.Logic;
using System.Collections.ObjectModel;

namespace PW.Model
{
    public class Model : ModelAbstractApi
    {
        private LogicAbstractApi LogicLayer;
        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        public override void Start()
        {
            LogicLayer = LogicAbstractApi.CreateApi();
            LogicLayer.Subscribe<IBall>(x => Balls.Add(x));
            LogicLayer.Start();
        }

        public override void CreateBalls(int amount)
        {
            Balls.Clear();
            LogicLayer.CreateBalls(amount);
        }
    }
}
