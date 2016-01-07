﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mobile_Application.Model;
using Mobile_Application.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Mobile_Application.ViewModel
{
    public class AddClientViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;

        public AddClientViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private async void RegisterClick()
        {
            try {
                Person newUser = new Person();
                newUser.Email = Email;
                newUser.Password = Password;
                newUser.FirstName = FirstLetterToUpperCase(FirstName);
                newUser.LastName = FirstLetterToUpperCase(LastName);
                newUser.KeyLength = ConvertKey();
                newUser.KeyUsed = KeyUsed;
                newUser.Company.NameCompany = FirstLetterToUpperCase(CompanyName);
                newUser.TypeAlgo.Type = SelectedAlgorithm;

                PersonService peopleService = new PersonService();
                await peopleService.AddPersonAsync(newUser);

                //return to login page
                _navigationService.GoBack();
            } catch (Exception e) {
                //create toast message wrong input
            }
        }

        private int ConvertKey()
        {
            // clean la cle si il a mis "128 bits" en 128
            // bug si la chaine na pas de chiffres
            string cleanKey = Regex.Replace(KeyLength, @"[^\d]", "");
            return int.Parse(cleanKey);
        }

        private string FirstLetterToUpperCase(string str)
        {
            if (string.IsNullOrEmpty(str)) {
                return string.Empty;
            }

            char[] tabStr = str.ToCharArray();
            tabStr[0] = char.ToUpper(tabStr[0]);

            return new string(tabStr);
        }
        

        public void OnNavigatedTo()
        {
            LoadAlgorithms();
        }

        private ICommand _register;
        public ICommand Register
        {
            get
            {
                if (_register == null) {
                    _register = new RelayCommand(() => RegisterClick());
                }
                return _register;
            }
        }

        private ICommand _back;
        public ICommand Back
        {
            get
            {
                if (_back == null) {
                    _back = new RelayCommand(() => GoBack());
                }
                return _back;
            }
        }

        private void GoBack()
        {
            _navigationService.GoBack();
        }

        private async void LoadAlgorithms()
        {
            AlgorithmService service = new AlgorithmService();
            AlgorithmsList = await service.GetAlgorithmsAsync();
        }

        //gettors & settors of each box
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordCheck { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string KeyLength { get; set; }

        public string KeyUsed { get; set; }

        public string CompanyName { get; set; }

        private string _selectedAlgorithm;
        public string SelectedAlgorithm
        {
            get { return _selectedAlgorithm; }
            set
            {
                _selectedAlgorithm = value;
                RaisePropertyChanged("SelectedAlgorithm");
            }
        }

        private IEnumerable<Algorithm> _algorithmsList;
        public IEnumerable<Algorithm> AlgorithmsList
        {
            get { return _algorithmsList; }
            set
            {
                _algorithmsList = value;
                RaisePropertyChanged("AlgorithmsList");
            }
        }
    }
}
