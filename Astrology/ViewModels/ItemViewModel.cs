using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Astrology
{
    public class HoroscopeViewModel : INotifyPropertyChanged
    {
        public bool IsLoading
        {
            get { return String.IsNullOrEmpty(Content) || Cover == null; }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                NotifyPropertyChanged("Content");
                NotifyPropertyChanged("IsLoading");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private BitmapImage _selectedImage;
        private BitmapImage _unselectedImage;
        private BitmapImage _cover;

        public BitmapImage Cover
        {
            get { return _cover; }
            set
            {
                _cover = value;
                NotifyPropertyChanged("IsLoading");
                NotifyPropertyChanged("Cover");
            }
        }

        public BitmapImage SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                _selectedImage = value;
                NotifyPropertyChanged("SelectedImage");
            }
        }

        public BitmapImage UnselectedImage
        {
            get { return _unselectedImage; }
            set
            {
                _unselectedImage = value;
                NotifyPropertyChanged("UnselectedImage");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}