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
            List<string> gereinigteListe = new List<string>();
            foreach (var line in rawLines)
            {
                string gereinigteZeile = zeileReinigen.CleaneLine(line);
                gereinigteListe.Add(gereinigteZeile);
            }
            string gereingteDatei = string.Empty;
            foreach (var item in gereinigteListe)
            {
                gereingteDatei += item;
            }
            GesäubertesPunkteFenster.Text = gereingteDatei;
            string newFile1 = @"C:\Users\stefa\OneDrive\Dokumente\Forster\Auswertung1\";
            string newFile2 = @"C:\Users\stefa\OneDrive\Dokumente\Forster\Auswertung2\";
            newFile1 += Path.GetFileName(FileNameCleanedFile);
            newFile2 += Path.GetFileName(FileNameCleanedFile);

            using (StreamWriter writer = new StreamWriter(newFile1))
            {
                foreach (var line in gereinigteListe) writer.WriteLine(line);
            }
            using (StreamWriter writer = new StreamWriter(newFile2))
            {
                foreach (var line in gereinigteListe) writer.WriteLine(line);
            }
            //if (line.Count() < 3) continue;
            //    if (line.Count() == 3)
            //    {
            //        line.Insert(1, "205");
            //        line.Insert(4, "     0");
            //    }
            //    if (line.Count() == 4 && line[1].Length == 2)
            //    {
            //        cleanedLineItems[1] = " " + cleanedLineItems[1];
            //        cleanedLineItems.Insert(4, "     0");
            //    }
        }

    
        }
    }

