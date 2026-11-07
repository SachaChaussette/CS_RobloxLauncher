using RobloxLauncher.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace RobloxLauncher.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ChartsPage ChartsPage { get; set; } = null;

        public MainWindowViewModel()
        {
            ChartsPage = new ChartsPage();
        }
        
    }
}
