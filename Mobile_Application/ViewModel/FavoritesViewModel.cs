﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mobile_Application.Exceptions;
using Mobile_Application.Model;
using Mobile_Application.Services;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;

namespace Mobile_Application.ViewModel 
{
    public class FavoritesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        public FavoritesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public void OnNavigatedTo()
        {
            LoadFavorites();
        }


        public void Favorite_Click(ItemClickEventArgs e)
        {
            SelectedPerson = (Person)((ItemClickEventArgs)e).ClickedItem;
            _navigationService.NavigateTo("FavoriteDetails", SelectedPerson);
        }


        private async void LoadFavorites()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var email = (string)localSettings.Values["Email"];
            FavoriteService service = new FavoriteService();
            try {
                FavoritesList = await service.getFavoritesAsync(email);
            }catch (NoNetworkException e)
            {
                ShowToast(e.ToString());
            }
        }
        public void ShowToast(String value)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            ToastVisual visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {
                    Text = loader.GetString(value)
                },
            };

            ToastContent content = new ToastContent();
            content.Visual = visual;
            var toast = new ToastNotification(content.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        /* Navigation command */

        private ICommand _search;
        public ICommand Search
        {
            get
            {
                if (_search == null) {
                    _search = new RelayCommand(() => Search_Tapped());
                }
                return _search;
            }
        }

        private ICommand _account;
        public ICommand Account
        {
            get
            {
                if (_account == null) {
                    _account = new RelayCommand(() => Account_Tapped());
                }
                return _account;
            }
        }

        private void Account_Tapped()
        {
            _navigationService.NavigateTo("Account");
        }

        private void Search_Tapped()
        {
            _navigationService.NavigateTo("SearchPage");
        }

        /* gettors & settors */

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                RaisePropertyChanged("SelectedPerson");
            }
        }

        private IEnumerable<Person> _favoritesList;
        public IEnumerable<Person> FavoritesList
        {
            get { return _favoritesList; }
            set
            {
                _favoritesList = value;
                RaisePropertyChanged("FavoritesList");
            }
        }
    }
}
