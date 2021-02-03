using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void OpenFileButton_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SaveFileButton_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); 
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true) 
            { 
                PunkteFenster.Text = File.ReadAllText(openFileDialog.FileName);
                
            }
        }
        

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CleanFileButton_Click(object sender, RoutedEventArgs e)
        {
            
                string line;
                List<string> rawLines = new List<string>();
                //while ((line = PunkteFenster.Text.ToList()) != null)
                //{
                //    rawLines.Add(line);
                //}
                //foreach (var file in rawLines)
                //{
                //    GesäubertesPunkteFenster.Text = file;
                //}
            
        }
    }
}
