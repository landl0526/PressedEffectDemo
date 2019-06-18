using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PressedEffectDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }


    public class MainPageViewModel
    {
        public ICommand TapCommand { set; get; }
        public ICommand LongTapCommand { set; get; }

        public MainPageViewModel()
        {
            TapCommand = new Command(() =>
            {
                Debug.WriteLine("single tap executed");
            });

            LongTapCommand = new Command(() =>
            {
                Debug.WriteLine("long tap executed");
            });
        }
    }
}
