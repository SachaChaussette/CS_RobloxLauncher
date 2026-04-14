using CS_RobloxLauncher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CS_RobloxLauncher.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Page
    {
        GameViewModel vm = null;
        public GameWindow()
        {
            InitializeComponent();
            vm = new GameViewModel();

            DataContext = vm;

            Loaded += OnLoaded;
        }

        void OnLoaded(object? sender, RoutedEventArgs e)
        {
            vm.OnExitGame += ((MainWindow)Window.GetWindow(this)).NavigateToChartsPage;
        }
    }
}