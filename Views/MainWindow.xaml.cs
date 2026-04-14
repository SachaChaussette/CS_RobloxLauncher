using CS_RobloxLauncher.Models;
using CS_RobloxLauncher.ViewModels;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_RobloxLauncher.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm = null;

        public MainWindow()
        {
            InitializeComponent();

            vm = new MainWindowViewModel();

            DataContext = vm;

            MainWindowFrame.Navigate(new ChartsPage());
            //MainWindowFrame.Navigate(new GameWindow());
        }
    }
}