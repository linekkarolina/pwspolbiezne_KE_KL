using System;
using System.Collections.ObjectModel;
using PW.Model;

namespace PW.ViewModel
{
    public class MainWindowViewModel : global::ViewModel.ViewModel
    {
        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            ModelLayer.Start();
            ModelLayer.Balls.ForEach(ball => Balls.Add(ball));
        }

        public ObservableCollection<IBall> Balls { get; } = new ObservableCollection<IBall>();

        private ModelAbstractApi ModelLayer;
    }
}