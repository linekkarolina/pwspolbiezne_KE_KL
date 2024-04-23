using System;
using System.Windows.Input;
using PW.Model;

namespace PW.ViewModel
{
    public class MainWindowViewModel : global::ViewModel.ViewModel
    {
        public ModelAbstractApi ModelLayer { get; }
        private ICommand mUpdater;

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            ModelLayer.Start();
            ModelLayer.CreateBalls(1);
        }

        public void UpdateBalls(String amount)
        {
            try {
                ModelLayer.CreateBalls(int.Parse(amount));
            } catch (Exception e) {

            }
        }

        public ICommand UpdateBallsCommand
        {
            get
            {
                return new RelayCommand((amount) =>
                {
                    if (amount != null) { UpdateBalls((string)amount); }
                });
            }
            set
            {
                mUpdater = value;
            }
        }
    }
}