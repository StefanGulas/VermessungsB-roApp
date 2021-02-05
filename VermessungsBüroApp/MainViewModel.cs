using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VermessungsBüroApp
{
    public class MainViewModel
    {
        private string _selectedItem;
        private IEnumerable<string> _menuItems;

        public MainViewModel()
        {
            _menuItems = new List<string>() { "Punkteliste", "Stationierung" };
            
        }
        private string _punkteAusgabe;
            
        public string PunkteAusgabe
        {
            get { return _punkteAusgabe; }
            set 
            { 
                _punkteAusgabe = value; 
            }
        }

        public IEnumerable<string> MenuItems { get => _menuItems; set => _menuItems = value; }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
