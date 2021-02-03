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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VermessungsBüroApp
{
    
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) this.DragMove();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTurnOff_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
