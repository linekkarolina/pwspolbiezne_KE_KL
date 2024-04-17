using System;
using PW.Model;

namespace PW.ViewModel
{
    public class MainWindowViewModel : global::ViewModel.ViewModel
    {
        public ModelAbstractApi ModelLayer { get; }

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            ModelLayer.Start();
        }
    }
}