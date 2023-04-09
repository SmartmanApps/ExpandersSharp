using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ExpandersSharp
{
	public class NewSharpPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<PropertyItem> myPropertyItems;
        public ObservableCollection<PropertyItem> MyPropertyItems
        {
            get { return myPropertyItems; }
            set
            {
                myPropertyItems = value;
                OnPropertyChanged(nameof(MyPropertyItems));
            }
        }


        public NewSharpPageViewModel()
        {
            MyPropertyItems = new ObservableCollection<PropertyItem>
             {
                new PropertyItem(){Header = "JPMorgan Chase", MyPropertyItems = new List<PropertyItemDetails>{ new PropertyItemDetails { Address = "270 Park Avenue, New York, NY 10017, U.S.", Reserve = "2.87 Trillion" } } },
                new PropertyItem(){Header = "Bank of America", MyPropertyItems = new List<PropertyItemDetails>{ new PropertyItemDetails { Address = "Charlotte, North Carolina, United States", Reserve = "2.16 Trillion" } } },
                new PropertyItem(){Header = "Wells Fargo  Co", MyPropertyItems = new List<PropertyItemDetails>{ new PropertyItemDetails { Address = "San Francisco, California, United States", Reserve = "2.10 Trillion" } } }

            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

