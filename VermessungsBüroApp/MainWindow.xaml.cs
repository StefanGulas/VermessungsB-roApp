using Microsoft.CodeAnalysis;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Path = System.IO.Path;

namespace VermessungsBüroApp
{

    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        private OpenFileDialog publicOpenFileDialog;
        private Brush newDarkBlue;
        private Brush newLightBlue;
        public MainViewModel ViewMdel
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
            Stationierung.Visibility = Visibility.Hidden;
            newDarkBlue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#173753"));
            newLightBlue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#007EA7"));
            MessPunkteListeButton.Background = newDarkBlue;
            StationierungButton.Background = newDarkBlue;
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

        public string OpenedFileName { get; set; }
        public string FileNameCleanedFile { get; set; }
        OpenFileDialog PublicOpenFileDialog { get => publicOpenFileDialog; set => publicOpenFileDialog = value; }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            PunkteFenster.Document.Blocks.Clear();
            GesäubertesPunkteFenster.Document.Blocks.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            var canOpen = openFileDialog.ShowDialog();
            try
            {

                using (FileStream stream = File.OpenRead(openFileDialog.FileName))
                {
                    TextRange documentTextRange = new TextRange(PunkteFenster.Document.ContentStart, PunkteFenster.Document.ContentEnd);

                    string dataFormat = DataFormats.Text;
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName);
                    if (String.Compare(extension, ".xaml", true) == 0)
                    {
                        dataFormat = DataFormats.Xaml;
                    }
                    else if (String.Compare(extension, ".txt", true) == 0)
                    {
                        dataFormat = DataFormats.Text;
                    }
                    documentTextRange.Load(stream, dataFormat);
                }
            }
            catch (Exception)
            {
            }

        }

        private void CleanFileButton_Click(object sender, RoutedEventArgs e)
        {
            var zeileReinigen = new ZeileReinigen();
            TextRange rawDocumentTextRange = new TextRange(PunkteFenster.Document.ContentStart, PunkteFenster.Document.ContentEnd);
            TextRange cleanedDocumentTextRange = new TextRange(GesäubertesPunkteFenster.Document.ContentStart, GesäubertesPunkteFenster.Document.ContentEnd);
            string cleanedStream = zeileReinigen.CleaneText(rawDocumentTextRange.Text);
            cleanedDocumentTextRange.Text = cleanedStream;
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange cleanedTextRange = new TextRange(GesäubertesPunkteFenster.Document.ContentStart, GesäubertesPunkteFenster.Document.ContentEnd);
            string cleanedText = cleanedTextRange.Text;
            if (!string.IsNullOrWhiteSpace(cleanedText))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FileName = OpenedFileName;
                if (saveFileDialog.ShowDialog() == true)
                {
                    var zeileReinigen = new ZeileReinigen();

                    string textFileText = zeileReinigen.FinalClean(cleanedText);
                    File.WriteAllText(saveFileDialog.FileName, textFileText);
                }
                PunkteFenster.Document.Blocks.Clear();
                GesäubertesPunkteFenster.Document.Blocks.Clear();
            }
        }

        private void MessPunkteListeButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessPunkteListeButton.Background == newDarkBlue)
            {
                StationierungButton.Background = newDarkBlue;
                MessPunkteListeButton.Background = newLightBlue;
            }
            else MessPunkteListeButton.Background = newDarkBlue;


            if (MessPunkteListe.Visibility == Visibility.Hidden)
            {
                MessPunkteListe.Visibility = Visibility.Visible;
                Stationierung.Visibility = Visibility.Hidden;
                StationierungsFenster.Document.Blocks.Clear();
                GesäubertesStationierungsFenster.Document.Blocks.Clear();
            }
            else
            {
                MessPunkteListe.Visibility = Visibility.Hidden;
                Stationierung.Visibility = Visibility.Hidden;
                PunkteFenster.Document.Blocks.Clear();
                GesäubertesPunkteFenster.Document.Blocks.Clear();
                StationierungsFenster.Document.Blocks.Clear();
                GesäubertesStationierungsFenster.Document.Blocks.Clear();
            }
        }

        private void StationierungButton_Click(object sender, RoutedEventArgs e)
        {
            if (StationierungButton.Background == newDarkBlue)
            {
                StationierungButton.Background = newLightBlue;
                MessPunkteListeButton.Background = newDarkBlue;
            }
            else StationierungButton.Background = newDarkBlue;

            if (Stationierung.Visibility == Visibility.Hidden)
            {
                MessPunkteListe.Visibility = Visibility.Hidden;
                Stationierung.Visibility = Visibility.Visible;
                PunkteFenster.Document.Blocks.Clear();
                GesäubertesPunkteFenster.Document.Blocks.Clear();
            }
            else
            {
                MessPunkteListe.Visibility = Visibility.Hidden;
                Stationierung.Visibility = Visibility.Hidden;
                StationierungsFenster.Document.Blocks.Clear();
                GesäubertesStationierungsFenster.Document.Blocks.Clear();
                PunkteFenster.Document.Blocks.Clear();
                GesäubertesPunkteFenster.Document.Blocks.Clear();
            }
        }

        private void OpenStationierungsFileButton_Click(object sender, RoutedEventArgs e)
        {
            PunkteFenster.Document.Blocks.Clear();
            GesäubertesStationierungsFenster.Document.Blocks.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var canOpen = openFileDialog.ShowDialog();
            string testText = File.ReadAllText(openFileDialog.FileName, Encoding.UTF7);
            StationierungsFenster.AppendText(testText);
        }

        private void CleanStationierungsFileButton_Click(object sender, RoutedEventArgs e)
        {
            var stationierungReinigen = new StationierungReinigen();
            TextRange rawDocumentTextRange = new TextRange(StationierungsFenster.Document.ContentStart, StationierungsFenster.Document.ContentEnd);
            TextRange cleanedDocumentTextRange = new TextRange(GesäubertesStationierungsFenster.Document.ContentStart, GesäubertesStationierungsFenster.Document.ContentEnd);
            string cleanedStream = stationierungReinigen.Reinige(rawDocumentTextRange.Text);
            cleanedDocumentTextRange.Text = cleanedStream;
        }

        private void SaveStationierungsFileButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange cleanedTextRange = new TextRange(GesäubertesStationierungsFenster.Document.ContentStart, GesäubertesStationierungsFenster.Document.ContentEnd);
            string cleanedText = cleanedTextRange.Text;
            if (!string.IsNullOrWhiteSpace(cleanedText))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FileName = OpenedFileName;
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, cleanedText);
                }
                StationierungsFenster.Document.Blocks.Clear();
                GesäubertesStationierungsFenster.Document.Blocks.Clear();
            }
        }

        private void MaximizeWindowSize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void NormalizeWindowSize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Normal;
        }


    }

}

