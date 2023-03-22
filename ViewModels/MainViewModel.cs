using CSharpPractice1.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace CSharpPractice1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #region Properties

        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get => this._birthDate;
            set {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private int? _age;

        public int? Age
        {
            get => this._age;
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        private bool _displayAdditionalInfo;

        public bool DisplayAdditionalInfo
        {
            get => this._displayAdditionalInfo;
            set
            {
                _displayAdditionalInfo = value;
                OnPropertyChanged("DisplayAdditionalInfo");
            }
        }

        private string? _chineseSign;

        public string? ChineseSign
        {
            get => _chineseSign;
            set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }

        private string? _westSign;

        public string? WestSign
        {
            get => _westSign;
            set
            {
                _westSign = value;
                OnPropertyChanged("WestSign");
            }
        }

        #endregion

        #region Commands

        public ICommand CalculateCommand { get; private set; }

        #endregion

        #region StaticData

        string[] chineseSigns = new string[]
        {
            "Monkey",
            "Rooster",
            "Dog",
            "Pig",
            "Rat",
            "Ox",
            "Tiger",
            "Rabbit",
            "Dragon",
            "Snake",
            "Horse",
            "Goat"
        };

        #endregion

        private void CalculateAge()
        {
            DateTime now = DateTime.Now;

            int age = (int)((now - BirthDate).TotalDays / 365.25);

            if(age > 135)
            {
                MessageBox.Show(
                    "Error! You're too old! Don't lie to me!", 
                    "A liar... or a dead one...", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
            }

            Age = age;

            if(now.Day == BirthDate.Day && now.Month == BirthDate.Month)
            {
                MessageBox.Show(
                    "HEPPY BERTHDAY!!!",
                    "OOOH WE HAVE A BIRTHDAY ONE HERE",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }

        private string CalculateChineseSign()
        {
            int remainder = BirthDate.Year % 12;
            return chineseSigns[remainder];
        }

        private string CalculateWestSign()
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;

            if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
            {
                return "Aries";
            }
            else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
            {
                return "Taurus";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Gemini";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Cancer";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
            {
                return "Leo";
            }
            else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
            {
                return "Virgo";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Libra";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Scorpio";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Sagittarius";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                return "Capricorn";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Aquarius";
            }
            else
            {
                return "Pisces";
            }
        }

        private void Calculate(object input)
        {
            CalculateAge();
            ChineseSign = CalculateChineseSign();
            WestSign = CalculateWestSign();

            DisplayAdditionalInfo = true;
        }

        public MainViewModel()
        {
            _birthDate = DateTime.Now;
            _age = null;
            _displayAdditionalInfo = false;

            CalculateCommand = new RelayCommand(Calculate);
        }
    }
}
