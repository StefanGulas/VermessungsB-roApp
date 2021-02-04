using Microsoft.CodeAnalysis;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Path = System.IO.Path;

namespace VermessungsBüroApp
{

    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        private OpenFileDialog publicOpenFileDialog;

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

        public string OpenedFileName { get; set; }
        public string FileNameCleanedFile { get; set; }
        OpenFileDialog PublicOpenFileDialog { get => publicOpenFileDialog; set => publicOpenFileDialog = value; }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            var canOpen = openFileDialog.ShowDialog();
            openFileDialog.RestoreDirectory = true;
            //if (canOpen == true)
            //{
            //    LoadTextDocument(openFileDialog.FileName);
            //    //PunkteFenster.Text = File.ReadAllText(openFileDialog.FileName);
            //    FileNameCleanedFile = openFileDialog.FileName;
            //    rawLines = File.ReadAllLines(openFileDialog.FileName);
            //    OpenedFileName = Path.GetFileName(openFileDialog.FileName);
            //    publicOpenFileDialog = openFileDialog;
            //}
            //open the file for reading
            using (FileStream stream = File.OpenRead(openFileDialog.FileName))
            {
                // create a TextRange around the entire document
                TextRange documentTextRange = new TextRange(PunkteFenster.Document.ContentStart, PunkteFenster.Document.ContentEnd);

                // sniff out what data format you've got
                string dataFormat = DataFormats.Text;
                string ext = System.IO.Path.GetExtension(openFileDialog.FileName);
                if (String.Compare(ext, ".xaml", true) == 0)
                {
                    dataFormat = DataFormats.Xaml;
                }
                else if (String.Compare(ext, ".rtf", true) == 0)
                {
                    dataFormat = DataFormats.Rtf;
                }
                documentTextRange.Load(stream, dataFormat);
            }

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //var result = dlg.ShowDialog();
            //if (result.Value)
            //{
            //    TextRange t = new TextRange(Workspace. .ContentStart, Workspace.Document.ContentEnd);
            //    FileStream file = new FileStream(publicOpenFileDialog.FileName, FileMode.Open);
            //    t.Load(file, System.Windows.DataFormats.Rtf);
            //}
            //openFileDialog.RestoreDirectory = true;
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    LoadTextDocument(openFileDialog.FileName);
            //    //PunkteFenster.Text = File.ReadAllText(openFileDialog.FileName);
            //    FileNameCleanedFile = openFileDialog.FileName;
            //    rawLines = File.ReadAllLines(openFileDialog.FileName);
            //    OpenedFileName = Path.GetFileName(openFileDialog.FileName);
            //    publicOpenFileDialog = openFileDialog;
            //}
        }

        //private void LoadTextDocument(string fileName)
        //{
        //    TextRange range;
        //    System.IO.FileStream fStream;
        //    if (System.IO.File.Exists(fileName))
        //    {
        //        range = newTextRange(PunkteFenster.Document.ContentStart, PunkteFenster.Document.ContentEnd);
        //        fStream = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate);
        //        range.Load(fStream, System.Windows.DataFormats.Text);
        //        fStream.Close();
        //    }
        //}
        //private TextRange newTextRange(TextPointer contentStart, TextPointer contentEnd)
        //{
        //    TextRange textRange = new TextRange(publicOpenFileDialog.Document.ContentStart, rtb.Document.ContentEnd);
        //    return textRange.Text;
        //}

        private void CleanFileButton_Click(object sender, RoutedEventArgs e)
        {
            var zeileReinigen = new ZeileReinigen();
//            GesäubertesPunkteFenster. = zeileReinigen.CleaneText(PunkteFenster.Text);
            //PunkteFenster.Text = GesäubertesPunkteFenster.Text;
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FileName = OpenedFileName;
//            if (saveFileDialog.ShowDialog() == true)
//                File.WriteAllText(saveFileDialog.FileName, GesäubertesPunkteFenster.Text);
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

