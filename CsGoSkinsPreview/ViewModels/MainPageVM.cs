using CsGoSkinsPreview.Commands;
using CsGoSkinsPreview.Models;
using CsGoSkinsPreview.Remote.Interfaces;
using CsGoSkinsPreview.Remote.Models;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsGoSkinsPreview.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private readonly IApiCaller _apiCaller;
        private readonly MainPage _mainPage;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Skin> _csGoWeapons;
        public ObservableCollection<Skin> CsGoWeapons 
        { 
          get { return _csGoWeapons; }
          set
          {
                _csGoWeapons = value;
                OnPropertyChanged(nameof(CsGoWeapons));
          }
        }

        private ObservableCollection<Skin> _csGoFilteredWeapons;
        public ObservableCollection<Skin> FilteredCsGoWeapons
        {
            get { return _csGoFilteredWeapons; }
            set
            {
                _csGoFilteredWeapons = value;
                OnPropertyChanged(nameof(FilteredCsGoWeapons));
            }
        }

        private List<string> _weaponTypes;
        public List<string> WeaponTypes 
        { 
            get { return _weaponTypes; }
            set
            {
                _weaponTypes = value;
                OnPropertyChanged(nameof(WeaponTypes));
            }
        }

        public MainPageVM(IApiCaller apiCaller, MainPage mainPage)
        {
            _apiCaller = apiCaller;
            _mainPage = mainPage;
        }

        public async Task Initialize()
        {
            var allCsItems = await _apiCaller.GetAllItems();
            var allCsWeapons = allCsItems.ItemsList?.Where(x => x.Type == "Weapon" && !string.IsNullOrEmpty(x.Type));
            allCsWeapons.ToList().ForEach( x => { x.RarityColor = "#" + x.RarityColor; x.IconUrl = $"https://steamcommunity-a.akamaihd.net/economy/image/{x.IconUrl}"; });
            CsGoWeapons = new ObservableCollection<Skin>(allCsWeapons);
            WeaponTypes = allCsWeapons.Select(x => x.WeaponType).Distinct().ToList();
            FilteredCsGoWeapons = new ObservableCollection<Skin>(allCsWeapons);
        }

        public async Task SearchCommandExecute()
        {
            var searchCommand = new SearchCommand(this);
            await searchCommand.ExecuteAsync(new SearchCommandArguments()
            {
                PriceFrom = _mainPage.PriceFrom.Text,
                PriceTo = _mainPage.PriceTo.Text,
                WeaponType = _mainPage.WeaponTypes.SelectedItem == null ? "" : _mainPage.WeaponTypes.SelectedItem.ToString(),
                SkinName = _mainPage.SkinByName.Text
            });
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        private void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
