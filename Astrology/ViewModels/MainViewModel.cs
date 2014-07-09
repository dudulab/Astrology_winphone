using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Resources;
using DuduCat.Config;


namespace Astrology
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<HoroscopeViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<HoroscopeViewModel> Items { get; private set; }


        public bool IsDataLoaded
        {
            get;
            private set;
        }

        private BitmapImage LoadImg(string path)
        {
            Uri uri = new Uri(path, UriKind.Relative);
            return new BitmapImage(uri);
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Clear();
            this.Items.Add(new HoroscopeViewModel() { Name = "01白羊", SelectedImage = LoadImg("res/白羊.png"), UnselectedImage = LoadImg("res/白羊2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "02金牛", SelectedImage = LoadImg("res/金牛.png"), UnselectedImage = LoadImg("res/金牛2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "03双子", SelectedImage = LoadImg("res/双子.png"), UnselectedImage = LoadImg("res/双子2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "04巨蟹", SelectedImage = LoadImg("res/巨蟹.png"), UnselectedImage = LoadImg("res/巨蟹2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "05狮子", SelectedImage = LoadImg("res/狮子.png"), UnselectedImage = LoadImg("res/狮子2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "06处女", SelectedImage = LoadImg("res/处女.png"), UnselectedImage = LoadImg("res/处女2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "07天秤", SelectedImage = LoadImg("res/天秤.png"), UnselectedImage = LoadImg("res/天秤2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "08天蝎", SelectedImage = LoadImg("res/天蝎.png"), UnselectedImage = LoadImg("res/天蝎2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "09射手", SelectedImage = LoadImg("res/射手.png"), UnselectedImage = LoadImg("res/射手2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "10摩羯", SelectedImage = LoadImg("res/摩羯.png"), UnselectedImage = LoadImg("res/摩羯2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "11水瓶", SelectedImage = LoadImg("res/水瓶.png"), UnselectedImage = LoadImg("res/水瓶2.png") });
            this.Items.Add(new HoroscopeViewModel() { Name = "12双鱼", SelectedImage = LoadImg("res/双鱼.png"), UnselectedImage = LoadImg("res/双鱼2.png") });

            for (int i = 0; i < 12; i++)
            {
                int index = i;
                ActiveConfig.GetTextAsync("K" + (i + 1), null, (t) => Items[index].Content = t);
                ActiveConfig.GetImageAsync("K" + (i + 1), null, (p) => Items[index].Cover = p);
            }

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}