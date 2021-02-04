using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Path = System.IO.Path;

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

        public string[] rawLines { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
            string[] rawLines = new string[] { };
            MessPunkteListe.Visibility = Visibility.Hidden;
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
        public string FileNameCleanedFile { get; set; }
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                PunkteFenster.Text = File.ReadAllText(openFileDialog.FileName);
                FileNameCleanedFile = openFileDialog.FileName;
                rawLines = File.ReadAllLines(openFileDialog.FileName);

            }
        }


        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CleanFileButton_Click(object sender, RoutedEventArgs e)
        {
            var zeileReinigen = new ZeileReinigen();
            GesäubertesPunkteFenster.Text = zeileReinigen.CleaneText(PunkteFenster.Text);
            //PunkteFenster.Text = GesäubertesPunkteFenster.Text;
        }


        private void MessPunkteListeButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessPunkteListe.Visibility == Visibility.Hidden) MessPunkteListe.Visibility = Visibility.Visible;
            else MessPunkteListe.Visibility = Visibility.Hidden;
        }

        private void StationierungButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }

